using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sabeco_Factsheet.Blazor.Client.Pages;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.Account.ExternalProviders;
using Volo.Abp.Account.Public.Web.Pages.Account;
using Volo.Abp.Account.Public.Web;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;
using Volo.Abp;
using Volo.Abp.Account.Settings;
using Volo.Abp.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;
using Volo.Abp.Uow;
using Owl.reCAPTCHA;
using Volo.Abp.Account.Security.Recaptcha;
using Volo.Abp.Identity;
using Volo.Abp.Account;
using Volo.Abp.Identity.AspNetCore;
using System;
using Volo.Abp.BackgroundWorkers;
using Volo.Saas.Tenants;
using IdentityUser = Volo.Abp.Identity.IdentityUser;
using Sabeco_Factsheet.TbUsers;
using Volo.Abp.Domain.Repositories;
using System.Collections.Generic;


namespace Sabeco_Factsheet.Blazor.Pages.Account
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(LoginModel))]
    public class MyLoginModel : LoginModel
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly ITbUserRepository _tbUserRepository;

        public MyLoginModel(IAuthenticationSchemeProvider schemeProvider,
             IOptions<AbpAccountOptions> accountOptions,
             IAbpRecaptchaValidatorFactory recaptchaValidatorFactory,
             IAccountExternalProviderAppService accountExternalProviderAppService,
             ICurrentPrincipalAccessor currentPrincipalAccessor,
             IOptions<IdentityOptions> identityOptions,
             IOptionsSnapshot<reCAPTCHAOptions> reCaptchaOptions,
             ITenantRepository tenantRepository, ITbUserRepository tbUserRepository)
             : base(schemeProvider, accountOptions, recaptchaValidatorFactory,
                   accountExternalProviderAppService, currentPrincipalAccessor, identityOptions, reCaptchaOptions)
        {
            _tenantRepository = tenantRepository;
            _tbUserRepository = tbUserRepository;
        }

        public override async Task<IActionResult> OnPostAsync(string action)
        {
            var user = await FindUserAsync(LoginInput.UserNameOrEmailAddress);
            using (CurrentTenant.Change(user?.TenantId))
            {
                return await base.OnPostAsync(action);
            }
        }

        protected virtual async Task<IdentityUser> FindUserAsync(string uniqueUserNameOrEmailAddress)
        {
            IdentityUser user = null;

            // Thay đổi Tenant hiện tại thành null để tìm kiếm trong Tenant mặc định
            using (CurrentTenant.Change(null))
            {
                // Tìm người dùng theo tên đăng nhập hoặc email trong Tenant mặc định
                user = await UserManager.FindByNameAsync(LoginInput.UserNameOrEmailAddress) ??
                       await UserManager.FindByEmailAsync(LoginInput.UserNameOrEmailAddress);

                // Nếu tìm thấy người dùng, trả về người dùng
                if (user != null)
                {
                    return user;
                }
            }

            // Lặp qua tất cả các Tenant để tìm người dùng
            foreach (var tenant in await _tenantRepository.GetListAsync())
            {
                // Thay đổi Tenant hiện tại thành Tenant đang lặp
                using (CurrentTenant.Change(tenant.Id))
                {
                    // Tìm người dùng theo tên đăng nhập hoặc email trong Tenant hiện tại
                    user = await UserManager.FindByNameAsync(LoginInput.UserNameOrEmailAddress) ??
                           await UserManager.FindByEmailAsync(LoginInput.UserNameOrEmailAddress);

                    // Nếu tìm thấy người dùng, trả về người dùng
                    if (user != null)
                    {
                        return user;
                    }
                }
            }

            // Trả về null nếu không tìm thấy người dùng trong tất cả các Tenant
            return null;
        }


        public override async Task<IActionResult> OnGetAsync()
        {
            // Lấy danh sách các nhà cung cấp đăng nhập bên ngoài và gán cho ExternalProviders
            ExternalProviders = await GetExternalProviders();

            // Kiểm tra nếu chỉ cho phép đăng nhập từ các nhà cung cấp bên ngoài
            if (IsExternalLoginOnly)
            {
                // Lấy thông tin đăng nhập từ nhà cung cấp bên ngoài
                var externalLoginInfo = await SignInManager.GetExternalLoginInfoAsync();

                // Nếu không có thông tin đăng nhập bên ngoài
                if (externalLoginInfo == null)
                {
                    // Ghi log cảnh báo về việc không có thông tin đăng nhập bên ngoài
                    Logger.LogWarning("External login info is not available");

                    // Thêm lỗi vào ModelState để hiển thị thông báo lỗi trên giao diện người dùng
                    ModelState.AddModelError(string.Empty, "External login info is not available");

                    // Giữ người dùng ở lại trang hiện tại và hiển thị thông báo lỗi
                    return Page();
                }

                // Lấy danh sách các identity từ thông tin đăng nhập bên ngoài
                var identity = externalLoginInfo.Principal.Identities.First();

                // Tìm claim email trong identity, nếu không có thì tìm trong danh sách claim chuẩn
                var emailClaim = identity.FindFirst(AbpClaimTypes.Email) ?? identity.FindFirst(ClaimTypes.Email);

                // Nếu không tìm thấy claim email
                if (emailClaim == null)
                {
                    // Thêm lỗi vào ModelState để hiển thị thông báo lỗi trên giao diện người dùng
                    ModelState.AddModelError(string.Empty, L["Could not find an email address for the user!"]);

                    // Giữ người dùng ở lại trang hiện tại và hiển thị thông báo lỗi
                    return Page();
                }
            }

            // Trả về trang hiện tại
            return Page();
        }


        public async Task<TbUser> FindByEmailAsync(string email)
        {
            return await _tbUserRepository.FindAsync(p => p.Email == email);
        }

        // Lấy xử lý phản hồi sau khi người dùng đăng nhập thông qua một nhà cung cấp đăng nhập bên ngoài (Microsoft, Facebook, ...)
        public override async Task<IActionResult> OnGetExternalLoginCallbackAsync(string remoteError = null)
        {
            // Kiểm tra lỗi từ remote và chuyển hướng đến trang đăng nhập nếu có lỗi
            if (remoteError != null)
            {
                Logger.LogWarning($"External login callback error: {remoteError}");
                return RedirectToPage("./Login");
            }

            // Thiết lập các tùy chọn định danh
            await IdentityOptions.SetAsync();

            // Lấy thông tin đăng nhập từ bên ngoài
            var loginInfo = await SignInManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                Logger.LogWarning("External login info is not available");
                return RedirectToPage("./Login");
            }

            // Kiểm tra xem đây có phải là đăng nhập liên kết không
            IsLinkLogin = await VerifyLinkTokenAsync();

            // Thực hiện đăng nhập từ bên ngoài
            var result = await SignInManager.ExternalLoginSignInAsync(
                loginInfo.LoginProvider,
                loginInfo.ProviderKey,
                isPersistent: true,
                bypassTwoFactor: true
            );

            // Ghi lại nhật ký bảo mật nếu đăng nhập không thành công
            if (!result.Succeeded)
            {
                await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
                {
                    Identity = IdentitySecurityLogIdentityConsts.IdentityExternal,
                    Action = "Login" + result
                });
            }

            // Xử lý trường hợp tài khoản bị khóa
            if (result.IsLockedOut)
            {
                Logger.LogWarning($"Cannot proceed because user is locked out!");
                return RedirectToPage("./LockedOut", new
                {
                    returnUrl = ReturnUrl,
                    returnUrlHash = ReturnUrlHash
                });
            }

            // Xử lý trường hợp tài khoản không được phép đăng nhập
            if (result.IsNotAllowed)
            {
                Logger.LogWarning($"External login callback error: User is Not Allowed!");

                var user = await UserManager.FindByLoginAsync(loginInfo.LoginProvider, loginInfo.ProviderKey);
                if (user == null)
                {
                    Logger.LogWarning($"External login callback error: User is Not Found!");
                    return RedirectToPage("./Login");
                }

                // Nếu người dùng phải thay đổi mật khẩu trong lần đăng nhập tiếp theo
                if (user.ShouldChangePasswordOnNextLogin || await UserManager.ShouldPeriodicallyChangePasswordAsync(user))
                {
                    await StoreChangePasswordUser(user);
                    return RedirectToPage("./ChangePassword", new
                    {
                        returnUrl = ReturnUrl,
                        returnUrlHash = ReturnUrlHash
                    });
                }

                // Nếu tài khoản đang hoạt động, chuyển hướng đến trang xác nhận người dùng
                if (user.IsActive)
                {
                    await StoreConfirmUser(user);
                    return RedirectToPage("./ConfirmUser", new
                    {
                        returnUrl = ReturnUrl,
                        returnUrlHash = ReturnUrlHash
                    });
                }

                return RedirectToPage("./Login");
            }

            // Xử lý trường hợp đăng nhập thành công
            if (result.Succeeded)
            {
                var user = await UserManager.FindByLoginAsync(loginInfo.LoginProvider, loginInfo.ProviderKey);
                if (IsLinkLogin)
                {
                    using (CurrentPrincipalAccessor.Change(await SignInManager.CreateUserPrincipalAsync(user)))
                    {
                        // Liên kết người dùng nếu đây là đăng nhập liên kết
                        await IdentityLinkUserAppService.LinkAsync(new LinkUserInput
                        {
                            UserId = LinkUserId.Value,
                            TenantId = LinkTenantId,
                            Token = LinkToken
                        });

                        // Ghi lại nhật ký bảo mật
                        await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
                        {
                            Identity = IdentitySecurityLogIdentityConsts.Identity,
                            Action = IdentityProSecurityLogActionConsts.LinkUser,
                            UserName = user.UserName,
                            ExtraProperties =
                    {
                        { IdentityProSecurityLogActionConsts.LinkTargetTenantId, LinkTenantId },
                        { IdentityProSecurityLogActionConsts.LinkTargetUserId, LinkUserId }
                    }
                        });

                        using (CurrentTenant.Change(LinkTenantId))
                        {
                            var targetUser = await UserManager.GetByIdAsync(LinkUserId.Value);
                            using (CurrentPrincipalAccessor.Change(await SignInManager.CreateUserPrincipalAsync(targetUser)))
                            {
                                await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
                                {
                                    Identity = IdentitySecurityLogIdentityConsts.Identity,
                                    Action = IdentityProSecurityLogActionConsts.LinkUser,
                                    UserName = targetUser.UserName,
                                    ExtraProperties =
                            {
                                { IdentityProSecurityLogActionConsts.LinkTargetTenantId, targetUser.TenantId },
                                { IdentityProSecurityLogActionConsts.LinkTargetUserId, targetUser.Id }
                            }
                                });
                            }
                        }
                    }
                }

                // Ghi lại nhật ký bảo mật sau khi đăng nhập thành công
                await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
                {
                    Identity = IdentitySecurityLogIdentityConsts.IdentityExternal,
                    Action = result.ToIdentitySecurityLogAction(),
                    UserName = user.UserName
                });

                // Xóa bộ nhớ cache của các dynamic claims
                await IdentityDynamicClaimsPrincipalContributorCache.ClearAsync(user.Id, user.TenantId);

                return await RedirectSafelyAsync(ReturnUrl, ReturnUrlHash);
            }
  
            // Kiểm tra và xử lý trường hợp không tìm thấy email trong db
            var email = loginInfo.Principal.FindFirstValue(AbpClaimTypes.Email) ?? loginInfo.Principal.FindFirstValue(ClaimTypes.Email);
            if (email.IsNullOrWhiteSpace())
            {
                ModelState.AddModelError(string.Empty, "The user is not registered. Please contact the administrator.");
                return RedirectToPage("./Login"); // Chuyển hướng lại trang đăng nhập hoặc trang khác phù hợp
            }

            //// Tìm người dùng theo email trong bảng TbUser
            //var tbUserEmail = await FindByEmailAsync(email);
            //if (tbUserEmail == null)
            //{
            //    TempData["ErrorMessage"] = "TbUser The email account does not exist. Please contact the administrator.";
            //    return RedirectToPage("./Login"); // Chuyển hướng lại trang đăng nhập hoặc trang khác phù hợp
            //}

            // Tìm người dùng theo email
            var externalUser = await UserManager.FindByEmailAsync(email);
            if (externalUser == null)
            {
                TempData["ErrorMessage"] = "The user is not registered. Please contact the administrator.";
                return RedirectToPage("./Login"); // Chuyển hướng lại trang đăng nhập hoặc trang khác phù hợp
            }

            // Thêm đăng nhập từ bên ngoài nếu chưa tồn tại
            if (await UserManager.FindByLoginAsync(loginInfo.LoginProvider, loginInfo.ProviderKey) == null)
            {
                CheckIdentityErrors(await UserManager.AddLoginAsync(externalUser, loginInfo));
            }

            // Kiểm tra các cài đặt định danh cần thiết
            if (await HasRequiredIdentitySettings())
            {
                Logger.LogWarning($"New external user is created but confirmation is required!");

                await StoreConfirmUser(externalUser);
                return RedirectToPage("./ConfirmUser", new
                {
                    returnUrl = ReturnUrl,
                    returnUrlHash = ReturnUrlHash
                });
            }

            // Đăng nhập người dùng từ bên ngoài
            await SignInManager.SignInAsync(externalUser, false, loginInfo.LoginProvider);

            // Xóa bộ nhớ cache của các dynamic claims
            await IdentityDynamicClaimsPrincipalContributorCache.ClearAsync(externalUser.Id, externalUser.TenantId);

            // Xử lý trường hợp đăng nhập liên kết
            if (IsLinkLogin)
            {
                using (CurrentPrincipalAccessor.Change(await SignInManager.CreateUserPrincipalAsync(externalUser)))
                {
                    await IdentityLinkUserAppService.LinkAsync(new LinkUserInput
                    {
                        UserId = LinkUserId.Value,
                        TenantId = LinkTenantId,
                        Token = LinkToken
                    });

                    // Ghi lại nhật ký bảo mật
                    await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
                    {
                        Identity = IdentitySecurityLogIdentityConsts.Identity,
                        Action = IdentityProSecurityLogActionConsts.LinkUser,
                        UserName = externalUser.UserName,
                        ExtraProperties =
                {
                    { IdentityProSecurityLogActionConsts.LinkTargetTenantId, LinkTenantId },
                    { IdentityProSecurityLogActionConsts.LinkTargetUserId, LinkUserId }
                }
                    });

                    using (CurrentTenant.Change(LinkTenantId))
                    {
                        var targetUser = await UserManager.GetByIdAsync(LinkUserId.Value);
                        using (CurrentPrincipalAccessor.Change(await SignInManager.CreateUserPrincipalAsync(targetUser)))
                        {
                            await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
                            {
                                Identity = IdentitySecurityLogIdentityConsts.Identity,
                                Action = IdentityProSecurityLogActionConsts.LinkUser,
                                UserName = targetUser.UserName,
                                ExtraProperties =
                        {
                            { IdentityProSecurityLogActionConsts.LinkTargetTenantId, targetUser.TenantId },
                            { IdentityProSecurityLogActionConsts.LinkTargetUserId, targetUser.Id }
                        }
                            });
                        }
                    }
                }
            }

            // Ghi lại nhật ký bảo mật sau khi đăng nhập thành công
            await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
            {
                Identity = IdentitySecurityLogIdentityConsts.IdentityExternal,
                Action = result.ToIdentitySecurityLogAction(),
                UserName = externalUser.UserName
            });

            return await RedirectSafelyAsync(ReturnUrl, ReturnUrlHash);
        }

    }
}
