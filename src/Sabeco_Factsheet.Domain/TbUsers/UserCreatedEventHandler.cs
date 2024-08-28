using AutoMapper;
using AutoMapper.Internal.Mappers; 
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus;
using Volo.Abp.Identity;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace Sabeco_Factsheet.TbUsers
{
	public class UserCreatedEventHandler : 
		ILocalEventHandler<EntityCreatedEventData<IdentityUser>>,
		ITransientDependency
	{ 
		private readonly ITbUserRepository _tbUserRepository;
		private readonly IIdentityUserRepository _identityUserRepository;
		private readonly IdentityUserManager _identityUserManager;

		public UserCreatedEventHandler(
            IdentityUserManager identityUserManager,
			IIdentityUserRepository identityUserRepository,
			ITbUserRepository tbUserRepository)
		{ 
			_identityUserManager = identityUserManager;
			_identityUserRepository = identityUserRepository;
            _tbUserRepository = tbUserRepository;
        }
         

        public async Task HandleEventAsync(EntityCreatedEventData<IdentityUser> eventData)
        {
            try
            {
                if (eventData.Entity.Id == Guid.Empty)
                {
                    throw new ArgumentException("User ID is null or empty.");
                }

                // Kiểm tra xem entity đã tồn tại chưa
                var existingUser = await _tbUserRepository.AnyAsync(x => x.AbpUserId == eventData.Entity.Id || x.UserName == eventData.Entity.UserName); 
                if (existingUser)
                {
                    // Nếu tồn tại thì không cần xử lý
                    return;
                }

                var newExtendedUser = new TbUser
                {
                    AbpUserId = eventData.Entity.Id,
                    Email = eventData.Entity.Email,
                    UserName = eventData.Entity.UserName,
                    FullName = eventData.Entity.Name,
                    IsActive = eventData.Entity.IsActive,
                    UserPrincipalName = eventData.Entity.Email, 
                    crt_date = eventData.Entity.CreationTime,
                };

                await _tbUserRepository.InsertAsync(newExtendedUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating User: {ex.Message}");
            }
        }
         
    }

}