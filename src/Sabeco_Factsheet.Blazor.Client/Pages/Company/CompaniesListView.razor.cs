using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Web;
using Blazorise;
using Blazorise.DataGrid;
using Volo.Abp.BlazoriseUI.Components;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using Sabeco_Factsheet.TbCompanies;
using Sabeco_Factsheet.Permissions;
using Sabeco_Factsheet.Shared;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Volo.Abp;
using Volo.Abp.Content;
using Volo.Abp.AspNetCore.Components.BlockUi;
using Blazorise.Snackbar;
using Volo.Abp.AspNetCore.Components.Messages;
using Sabeco_Factsheet.TbUserMappingCompanies;
using Sabeco_Factsheet.TbUsers;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;
using Sabeco_Factsheet.TbInfoUpdates;
using Sabeco_Factsheet.TbBreweries;
using Sabeco_Factsheet.TbPersons;
using Sabeco_Factsheet.TsClasses;



namespace Sabeco_Factsheet.Blazor.Client.Pages.Company
{
    public partial class CompaniesListView
    {

        protected List<Volo.Abp.BlazoriseUI.BreadcrumbItem> BreadcrumbItems = new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>();
        protected PageToolbar Toolbar { get; } = new PageToolbar();
        private int PageSize { get; set; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentPage { get; set; } = 1;
        private string CurrentSorting { get; set; } = string.Empty;
        private int TotalCount { get; set; }


        private bool CanCreateTbCompany { get; set; }
        private bool CanEditTbCompany { get; set; }
        private bool CanDeleteTbCompany { get; set; }


        private GetTbCompaniesInput Filter { get; set; }

        private TbCompanyDto? SelectedTbCompany = new TbCompanyDto();

        private List<TsClassDto> TypeClassList = new List<TsClassDto> { };
        private List<TsClassDto> ReportClassList = new List<TsClassDto> { };
        private List<TsClassDto> ReportKindClassList = new List<TsClassDto> { };
        private List<TbCompanyDto> SelectedTbCompanies { get; set; } = new List<TbCompanyDto>();
        private List<TbUserDto> TbUserList { get; set; } = new List<TbUserDto>();
        private List<TbUserMappingCompanyDto> TbUserMappingCompaniesList { get; set; } = new List<TbUserMappingCompanyDto>();
        private IReadOnlyList<TbCompanyDto> TbCompanyList { get; set; }

         
        protected bool showAdvancedFilters { get; set; }

        private IReadOnlyList<TbInfoUpdateDto> TbInfoUpdateList { get; set; } = new List<TbInfoUpdateDto>();
        private IEnumerable<IGrouping<Guid?, TbInfoUpdateDto>> GroupedChanges { get; set; }

        public string screenName { get; set; } = "Companies";
        public int screenId { get; set; }
        public bool isColumn1Visible { get; set; } = true;
        public bool isColumn2Visible { get; set; } = false;



        //================================== Initialize Section ==================================

        // Constructor không tham số
        public CompaniesListView()
        {
            // Constructor không tham số
            Filter = new GetTbCompaniesInput
            {
                MaxResultCount = PageSize,
                SkipCount = (CurrentPage - 1) * PageSize,
                Sorting = CurrentSorting
            };

            TbCompanyList = new List<TbCompanyDto>(); 
        }

        protected override async Task OnInitializedAsync()
        { 
            await SetPermissionsAsync();
            await SetToolbarItemsAsync();
            await SetBreadcrumbItemsAsync();

            await GetTbUserListAsync();
            await GetClassDataAsync(); 
        }

        //================================== ToolBar - Breadcrumb - Permission =======================================

        protected virtual ValueTask SetBreadcrumbItemsAsync()
        {
            BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["TbCompanies"]));
            return ValueTask.CompletedTask;
        }

        protected virtual ValueTask SetToolbarItemsAsync()
        {
            Toolbar.AddButton(L["Refresh"], async () => await Refresh(),
            icon: "fa fa-sync",
            Color.Default);

            return ValueTask.CompletedTask;
        }

        private async Task SetPermissionsAsync()
        {
            CanCreateTbCompany = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbCompanies.Create);
            CanEditTbCompany = await AuthorizationService
                            .IsGrantedAsync(Sabeco_FactsheetPermissions.TbCompanies.Edit);
            CanDeleteTbCompany = await AuthorizationService
                            .IsGrantedAsync(Sabeco_FactsheetPermissions.TbCompanies.Delete);
        }

        //================================== Load Data, Search, New, Delete ==================================



        private async Task Refresh()
        {
            Filter.Code = null;
            Filter.BriefName = null;
            Filter.Name = null;
            Filter.ContactInfo_01 = null;
            Filter.ContactInfo_02 = null;
            Filter.ContactInfo_04 = null;

            await GetClassDataAsync();
        }

        private async Task GetClassDataAsync()
        {
            Filter.MaxResultCount = PageSize;
            Filter.SkipCount = (CurrentPage - 1) * PageSize;
            Filter.Sorting = CurrentSorting;

            // Lấy danh sách UserMappingCompanies của người dùng hiện tại
            await GetTbUserMappingCompaniesListAsync();

            // Lấy tất cả dữ liệu mà không phân trang để tính TotalCount
            var allCompaniesResult = await TbCompaniesAppService.GetListNoPagedAsync(Filter);

            // Lọc danh sách dựa trên quyền truy cập của người dùng
            var filteredCompanies = allCompaniesResult
                .Where(x => TbUserMappingCompaniesList.Any(mapping => mapping.companyid == x.Id))
                .ToList();

            // Áp dụng bộ lọc FilterText cho các trường không phân biệt dấu và hoa thường
            if (!string.IsNullOrEmpty(Filter.FilterText))
            {
                string lowerFilterText = Filter.FilterText.ToLower().RemoveDiacritics();

                filteredCompanies = filteredCompanies
                    .Where(x =>
                        (x.Code != null && x.Code.ToLower().RemoveDiacritics().Contains(lowerFilterText)) ||
                        (x.Name != null && x.Name.ToLower().RemoveDiacritics().Contains(lowerFilterText)) ||
                        (x.BriefName != null && x.BriefName.ToLower().RemoveDiacritics().Contains(lowerFilterText)) ||
                        (x.ContactInfo_01 != null && x.ContactInfo_01.ToLower().RemoveDiacritics().Contains(lowerFilterText)) ||
                        (x.ContactInfo_02 != null && x.ContactInfo_02.ToLower().RemoveDiacritics().Contains(lowerFilterText)) ||
                        (x.ContactInfo_04 != null && x.ContactInfo_04.ToLower().RemoveDiacritics().Contains(lowerFilterText)))
                    .ToList();
            }


            // Tính TotalCount dựa trên danh sách đã lọc
            TotalCount = filteredCompanies.Count();

            // Áp dụng phân trang cho dữ liệu đã lọc
            var pagedCompanies = filteredCompanies
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            TbCompanyList = pagedCompanies;
        }


        private async Task GetTbUserMappingCompaniesListAsync()
        {
            var currentUserName = CurrentUser.UserName;
            var userId = TbUserList.FirstOrDefault(x => x.UserName == currentUserName)?.Id;

            if (userId != null)
            {
                var result = await TbUserMappingCompaniesAppService.GetListNoPagedAsync(new GetTbUserMappingCompaniesInput { });
                TbUserMappingCompaniesList = result.Where(x => x.userid == userId && x.IsActive == true).ToList();
            }
        }

        private async Task GetTbUserListAsync()
        {
            TbUserList = await TbUsersAppService.GetListNoPagedAsync(new GetTbUsersInput { });
        }




        //============================ Controls triggers/events =========================================

        #region --History List View

        private List<TbInfoUpdateDto> _cachedInfoUpdates;

        private async Task FetchInfoUpdatesAsync()
        {
            if (_cachedInfoUpdates == null)
            {
                var result = await InfoUpdatesAppService.GetListNoPagedAsync(new GetTbInfoUpdatesInput { });
                _cachedInfoUpdates = result
                    .Where(x => x.ScreenName == screenName && x.IsVisible == true)
                    .OrderByDescending(x => x.crt_date)
                    .ToList();
            }
        }

        private async Task GetHistoryAsync(TbCompanyDto context)
        {
            await _blockUiService.Block(selectors: "#lpx-content-container", busy: false);

            await GetListCompanyTypeAsync();
            await GetListCompanyTypeReportAsync();
            await GetListCompanyTypeReportKindAsync();

            await FetchInfoUpdatesAsync();
            TbInfoUpdateList = _cachedInfoUpdates
                .Where(x => x.ScreenId == context.Id && x.IsVisible == true)
                .OrderByDescending(x => x.crt_date)
                .ToList();

            screenId = context.Id;

            if (TbInfoUpdateList.Any())
            {
                GroupedChanges = TbInfoUpdateList
                    .Where(x => x.ChangeSetId.HasValue)
                    .GroupBy(x => x.ChangeSetId)
                    .ToList();

                isColumn1Visible = false;
                isColumn2Visible = true;
            }
            else
            {
                await _uiNotificationService.Warn(L["NoHistoryAvailable"]);
            }

            await _blockUiService.UnBlock();
            await InvokeAsync(StateHasChanged);
        }

        private async Task GetTbInfoUpdateListAsync()
        {
            await FetchInfoUpdatesAsync();
            TbInfoUpdateList = _cachedInfoUpdates;

            await InvokeAsync(StateHasChanged);
        }

        private async Task GetListCompanyTypeAsync()
        {
            var parentCode = "COMPANY_TYPE";
            TypeClassList = await TsClassesAppService.GetListByParentCode(parentCode);
        }

        private async Task GetListCompanyTypeReportKindAsync()
        {
            var parentCode = "TYPE_REPORT_KIND_COMPANY";
            ReportKindClassList = await TsClassesAppService.GetListByParentCode(parentCode);
        }

        private async Task GetListCompanyTypeReportAsync()
        {
            var parentCode = "TYPE_REPORT";
            ReportClassList = await TsClassesAppService.GetListByParentCode(parentCode);
        }
 
        private async Task HideHistory()
        {
            isColumn1Visible = true;
            isColumn2Visible = false;

            await InvokeAsync(StateHasChanged);
        }

        #endregion History List View--

        private async Task ChangePageSize(int value)
        {
            PageSize = value;
            await Task.CompletedTask;
        }
 
        protected void GotoEditPage(TbCompanyDto context)
        {
            NavigationManager.NavigateTo($"companies/{context.Id}");
        }

        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<TbCompanyDto> e)
        {
            CurrentSorting = e.Columns
                .Where(c => c.SortDirection != SortDirection.Default)
                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentPage = e.Page;
            await GetClassDataAsync();
            await InvokeAsync(StateHasChanged);
        }

        public static string TruncateText(string text, int maxLength)
        {
            if (text != null)
            {
                if (text.Length <= maxLength)
                    return text;
                return text.Substring(0, maxLength) + "...";
            }
            return "";
        }

        private async Task OnFilterChanged<T>(string filterName, T filterValue)
        {
            typeof(GetTbCompaniesInput).GetProperty(filterName)?.SetValue(Filter, filterValue);
            await GetClassDataAsync();
        }

        private async Task DownloadAsExcelAsync()
        {
            string code = "";
            string currentDate = DateTime.Now.ToString("yyyyMMdd");
            string currentTime = DateTime.Now.ToString("HHmm");

            string fileName = code + currentDate + currentTime;

            var token = (await TbCompaniesAppService.GetDownloadTokenAsync()).Token;
            var remoteService = await RemoteServiceConfigurationProvider.GetConfigurationOrDefaultOrNullAsync("Sabeco_Factsheet") ?? await RemoteServiceConfigurationProvider.GetConfigurationOrDefaultOrNullAsync("Default");
            var culture = CultureInfo.CurrentUICulture.Name ?? CultureInfo.CurrentCulture.Name;
            if (!culture.IsNullOrEmpty())
            {
                culture = "&culture=" + culture;
            }
            await RemoteServiceConfigurationProvider.GetConfigurationOrDefaultOrNullAsync("Default");
            NavigationManager.NavigateTo($"{remoteService?.BaseUrl.EnsureEndsWith('/') ?? string.Empty}api/app/tb-companies/as-excel-file?DownloadToken={token}&FilterText={HttpUtility.UrlEncode(Filter.FilterText)}{culture}&FileName={fileName}&ParentIdMin={Filter.ParentIdMin}&ParentIdMax={Filter.ParentIdMax}&IsGroup={Filter.IsGroup}&Code={HttpUtility.UrlEncode(Filter.Code)}&Name={HttpUtility.UrlEncode(Filter.Name)}&Name_EN={HttpUtility.UrlEncode(Filter.Name_EN)}&BriefName={HttpUtility.UrlEncode(Filter.BriefName)}&ContactInfo_01={HttpUtility.UrlEncode(Filter.ContactInfo_01)}&ContactInfo_02={HttpUtility.UrlEncode(Filter.ContactInfo_02)}&ContactInfo_03={HttpUtility.UrlEncode(Filter.ContactInfo_03)}&ContactInfo_04={HttpUtility.UrlEncode(Filter.ContactInfo_04)}&ContactInfo_05={HttpUtility.UrlEncode(Filter.ContactInfo_05)}&ContactInfo_06={HttpUtility.UrlEncode(Filter.ContactInfo_06)}&StockCode={HttpUtility.UrlEncode(Filter.StockCode)}&StockExchange={HttpUtility.UrlEncode(Filter.StockExchange)}&StockRegistrationDateMin={Filter.StockRegistrationDateMin?.ToString("O")}&StockRegistrationDateMax={Filter.StockRegistrationDateMax?.ToString("O")}&IsPublicCompany={Filter.IsPublicCompany}&LicenseNo={HttpUtility.UrlEncode(Filter.LicenseNo)}&License={HttpUtility.UrlEncode(Filter.License)}&RegistrationOrderMin={Filter.RegistrationOrderMin}&RegistrationOrderMax={Filter.RegistrationOrderMax}&RegistrationDate0Min={Filter.RegistrationDate0Min?.ToString("O")}&RegistrationDate0Max={Filter.RegistrationDate0Max?.ToString("O")}&RegistrationDateMin={Filter.RegistrationDateMin?.ToString("O")}&RegistrationDateMax={Filter.RegistrationDateMax?.ToString("O")}&LatestAmendmentMin={Filter.LatestAmendmentMin?.ToString("O")}&LatestAmendmentMax={Filter.LatestAmendmentMax?.ToString("O")}&LegalRepresent={HttpUtility.UrlEncode(Filter.LegalRepresent)}&CompanyType={HttpUtility.UrlEncode(Filter.CompanyType)}&CharteredCapitalMin={Filter.CharteredCapitalMin}&CharteredCapitalMax={Filter.CharteredCapitalMax}&TotalShareMin={Filter.TotalShareMin}&TotalShareMax={Filter.TotalShareMax}&ListedShareMin={Filter.ListedShareMin}&ListedShareMax={Filter.ListedShareMax}&ParValueMin={Filter.ParValueMin}&ParValueMax={Filter.ParValueMax}&ContactName1={HttpUtility.UrlEncode(Filter.ContactName1)}&ContactDept1={HttpUtility.UrlEncode(Filter.ContactDept1)}&ContactMail1={HttpUtility.UrlEncode(Filter.ContactMail1)}&ContactPosition1={HttpUtility.UrlEncode(Filter.ContactPosition1)}&ContactPhone1={HttpUtility.UrlEncode(Filter.ContactPhone1)}&ContactName2={HttpUtility.UrlEncode(Filter.ContactName2)}&ContactDept2={HttpUtility.UrlEncode(Filter.ContactDept2)}&ContactMail2={HttpUtility.UrlEncode(Filter.ContactMail2)}&ContactPosition2={HttpUtility.UrlEncode(Filter.ContactPosition2)}&ContactPhone2={HttpUtility.UrlEncode(Filter.ContactPhone2)}&LongtitudeMin={Filter.longtitudeMin}&LongtitudeMax={Filter.longtitudeMax}&LatitudeMin={Filter.latitudeMin}&LatitudeMax={Filter.latitudeMax}&Note={HttpUtility.UrlEncode(Filter.Note)}&DocStatusMin={Filter.DocStatusMin}&DocStatusMax={Filter.DocStatusMax}&DirectShareholdingMin={Filter.DirectShareholdingMin}&DirectShareholdingMax={Filter.DirectShareholdingMax}&ConsolidatedShareholdingMin={Filter.ConsolidatedShareholdingMin}&ConsolidatedShareholdingMax={Filter.ConsolidatedShareholdingMax}&ConsolidateNoted={HttpUtility.UrlEncode(Filter.ConsolidateNoted)}&VotingRightDirectMin={Filter.VotingRightDirectMin}&VotingRightDirectMax={Filter.VotingRightDirectMax}&VotingRightTotalMin={Filter.VotingRightTotalMin}&VotingRightTotalMax={Filter.VotingRightTotalMax}&Image={HttpUtility.UrlEncode(Filter.Image)}&IsActive={Filter.IsActive}&BravoCode={HttpUtility.UrlEncode(Filter.BravoCode)}&LegacyCode={HttpUtility.UrlEncode(Filter.LegacyCode)}&idCompanyTypeMin={Filter.idCompanyTypeMin}&idCompanyTypeMax={Filter.idCompanyTypeMax}", forceLoad: true);
        }


    }
}
