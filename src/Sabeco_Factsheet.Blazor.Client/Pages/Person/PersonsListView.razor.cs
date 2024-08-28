using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Web;

using Blazorise;
using Blazorise.DataGrid;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

using Volo.Abp.BlazoriseUI.Components;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;

using Sabeco_Factsheet.TbCompanyPersons;
using Sabeco_Factsheet.TbCompanies;
using Sabeco_Factsheet.TbNationalities;
using Sabeco_Factsheet.TbPersons;
using Sabeco_Factsheet.Permissions;
using Volo.Abp.Application.Dtos;
using Sabeco_Factsheet.TbUserMappingPersons;
using Sabeco_Factsheet.TbUsers;
using Sabeco_Factsheet.TbInfoUpdates;
using Sabeco_Factsheet.TbBreweries;
using Microsoft.JSInterop;
using Sabeco_Factsheet.TbFileUploads;
using Sabeco_Factsheet.TbFileUploadTemps;
using static Sabeco_Factsheet.Permissions.Sabeco_FactsheetPermissions;



namespace Sabeco_Factsheet.Blazor.Client.Pages.Person
{
    public partial class PersonsListView
    {

        protected List<Volo.Abp.BlazoriseUI.BreadcrumbItem> BreadcrumbItems = new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>();
        protected PageToolbar Toolbar { get; } = new PageToolbar();
        private int PageSize { get; set; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentPage { get; set; } = 1;
        private string CurrentSorting { get; set; } = string.Empty;
        private int TotalCount { get; set; }


        private bool CanCreateTbCompanyPerson { get; set; }
        private bool CanCreateTbPerson { get; set; }

        private bool CanEditTbCompanyPerson { get; set; }
        private bool CanEditTbPerson { get; set; }

        private bool CanDeleteTbCompanyPerson { get; set; }
        private bool CanDeleteTbPerson { get; set; }


        private int EditingTbCompanyPersonId { get; set; }
        private GetTbCompanyPersonsInput Filter { get; set; }
        private GetTbPersonsInput FilterPerson { get; set; }
        private TbCompanyPersonDto? SelectedTbCompanyPerson;


        private bool isSelected { get; set; } = false;
        protected bool showAdvancedFilters { get; set; }


        private List<TbCompanyPersonDto> SelectedTbCompanyPersons { get; set; } = new();
        private List<TbPersonDto> SelectedTbPersons { get; set; } = new();


        private IReadOnlyList<TbCompanyPersonDto> TbCompanyPersonList { get; set; }
        private IReadOnlyList<TbPersonDto> TbPersonList { get; set; }
        private IReadOnlyList<TbUserMappingPersonDto> TbUserMappingPersonList { get; set; } = new List<TbUserMappingPersonDto>();

        private List<TbFileUploadDto> TbFileUploadList = new List<TbFileUploadDto> { };
        private List<TbNationalityDto> TbNationalityList { get; set; }
        private List<TbUserDto> TbUserList { get; set; } = new List<TbUserDto>();
        private List<TbCompanyDto> TbCompanyList { get; set; } = new List<TbCompanyDto>();
        private List<GenderItem> GenderList { get; set; } = new List<GenderItem>();

        private IReadOnlyList<TbInfoUpdateDto> TbInfoUpdateList { get; set; } = new List<TbInfoUpdateDto>();
        private IEnumerable<IGrouping<Guid?, TbInfoUpdateDto>> GroupedChanges { get; set; }

        public int screenId { get; set; }
        public string screenName { get; set; } = "Persons";
        public bool isColumn1Visible { get; set; } = true;
        public bool isColumn2Visible { get; set; } = false;



        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                              Initialize Section
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        public PersonsListView()
        {
            Filter = new GetTbCompanyPersonsInput
            {
                MaxResultCount = PageSize,
                SkipCount = (CurrentPage - 1) * PageSize,
                Sorting = CurrentSorting
            };

            FilterPerson = new GetTbPersonsInput
            {
                MaxResultCount = PageSize,
                SkipCount = (CurrentPage - 1) * PageSize,
                Sorting = CurrentSorting
            };

            TbCompanyPersonList = new List<TbCompanyPersonDto>();
            TbPersonList = new List<TbPersonDto>();
            TbNationalityList = new List<TbNationalityDto>();
        }

        protected override async Task OnInitializedAsync()
        { 
            await SetPermissionsAsync();
            await SetToolbarItemsAsync();
            await SetBreadcrumbItemsAsync();

            await GetTbUserListAsync();
            await GetCompanyListAsync();
            await GetTbFileUploadListAsync();
            await GetTbUserMappingPersonListAsync();
            await GetPersonClassDataAsync();
            await GetTbInfoUpdateListAsync();

            GenderList = new List<GenderItem>
            {
                new GenderItem { Value = "0", DisplayName = "Male" },
                new GenderItem { Value = "1", DisplayName = "Female" }
            }; 
        }



        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                       ToolBar - Breadcrumb - Permission
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        protected virtual ValueTask SetBreadcrumbItemsAsync()
        {
            BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:TbPersons"]));
            return ValueTask.CompletedTask;
        }

        protected virtual ValueTask SetToolbarItemsAsync()
        {
            Toolbar.AddButton(L["Refresh"], async () => await Refresh(),
            icon: "fa fa-sync",
            Color.Default);

            Toolbar.AddButton(L[""], async () => await GetHistoryAsync(),
            icon: "fa fa-history",
            Color.Default);

            Toolbar.AddButton(L["New"], async () => await New(),
            icon: "fa fa-plus",
            Color.Primary);

            return ValueTask.CompletedTask;
        }

        private async Task SetPermissionsAsync()
        {
            CanCreateTbCompanyPerson = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbCompanyPersons.Create);
            CanEditTbCompanyPerson = await AuthorizationService
                            .IsGrantedAsync(Sabeco_FactsheetPermissions.TbCompanyPersons.Edit);
            CanDeleteTbCompanyPerson = await AuthorizationService
                            .IsGrantedAsync(Sabeco_FactsheetPermissions.TbCompanyPersons.Delete);

            CanCreateTbPerson = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbPersons.Create);
            CanEditTbPerson = await AuthorizationService
                            .IsGrantedAsync(Sabeco_FactsheetPermissions.TbPersons.Edit);
            CanDeleteTbPerson = await AuthorizationService
                            .IsGrantedAsync(Sabeco_FactsheetPermissions.TbPersons.Delete);
        }




        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                              LOAD DATA LIST
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        private async Task GetTbFileUploadListAsync()
        {
            TbFileUploadList = await TbFileUploadsAppService.GetListNoPagedAsync(new GetTbFileUploadsInput { });
        }

        private async Task GetClassDataAsync()
        {
            Filter.MaxResultCount = PageSize;
            Filter.SkipCount = (CurrentPage - 1) * PageSize;
            Filter.Sorting = CurrentSorting;

            // Lấy danh sách UserMappingPerson của người dùng hiện tại
            await GetTbUserMappingPersonListAsync();

            var result = await TbCompanyPersonsAppService.GetListAsync(Filter);

            // Sử dụng Contains để kiểm tra x.Id có trong danh sách TbUserMappingPersonList hay không
            TbCompanyPersonList = result.Items
                .Where(x => TbUserMappingPersonList.Any(mapping => mapping.personid == x.Id))
                .ToList();
        }

        private async Task GetPersonClassDataAsync()
        {
            FilterPerson.MaxResultCount = PageSize;
            FilterPerson.SkipCount = (CurrentPage - 1) * PageSize;
            FilterPerson.Sorting = CurrentSorting;

            // Lấy danh sách UserMappingPerson của người dùng hiện tại
            await GetTbUserMappingPersonListAsync();

            // Lấy tất cả dữ liệu mà không phân trang để tính TotalCount
            var allPersonsResult = await TbPersonsAppService.GetListNoPagedAsync(FilterPerson);

            // Lọc danh sách dựa trên quyền truy cập của người dùng
            var filteredPersons = allPersonsResult
                .Where(x => TbUserMappingPersonList.Any(mapping => mapping.personid == x.Id))
                .ToList();

            // Áp dụng bộ lọc FilterText cho các trường Code, FullName, Address, NationalityCode không phân biệt hoa thường
            if (!string.IsNullOrEmpty(FilterPerson.FilterText))
            {
                string lowerFilterText = FilterPerson.FilterText.ToLower();

                filteredPersons = filteredPersons
                    .Where(x => (x.Code != null && x.Code.ToLower().Contains(lowerFilterText)) ||
                                (x.FullName != null && x.FullName.ToLower().Contains(lowerFilterText)) ||
                                (x.Address != null && x.Address.ToLower().Contains(lowerFilterText)) ||
                                (x.NationalityCode != null && x.NationalityCode.ToLower().Contains(lowerFilterText)))
                    .ToList();
            }

            // Tính TotalCount dựa trên danh sách đã lọc
            TotalCount = filteredPersons.Count();

            // Áp dụng phân trang cho dữ liệu đã lọc
            var pagedPersons = filteredPersons
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            TbPersonList = pagedPersons;
        }


        private async Task ChangePageSize(int value)
        {
            PageSize = value;
            await Task.CompletedTask;
        }

        private async Task GetTbUserMappingPersonListAsync()
        {
            var currentUser = CurrentUser.UserName;
            var user = TbUserList.FirstOrDefault(x => x.UserName == currentUser);

            if (user != null)
            {
                var result = await TbUserMappingPersonsAppService.GetListNoPagedAsync(new GetTbUserMappingPersonsInput { });
                TbUserMappingPersonList = result.Where(x => x.userid == user.Id && x.IsActive == true).ToList();
            }
        }

        private async Task GetTbUserListAsync()
        {
            TbUserList = await TbUsersAppService.GetListNoPagedAsync(new GetTbUsersInput { });
        }


        private async Task GetCompanyListAsync()
        {
            TbCompanyList = await TbCompaniesAppService.GetListNoPagedAsync(new GetTbCompaniesInput { });
        }

        private async Task GetTbNationalitiesAsync()
        {
            TbNationalityList = await TbNationalitiesAppService.GetListNoPagedAsync(new GetTbNationalitiesInput { });
        }

        private async Task GetCompanysAsync()
        {
            TbCompanyList = await TbCompaniesAppService.GetListNoPagedAsync(new GetTbCompaniesInput { });
        }

        private string GetNationalityName(string? nationalityCode)
        {
            var nationality = TbNationalityList?.FirstOrDefault(n => n.Code == nationalityCode);
            return nationality?.Name_vn ?? "Unknown";
        }


        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                          Controls triggers/events  
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        private async Task Refresh()
        {
            FilterPerson.Code = null;
            FilterPerson.FullName = null;
            FilterPerson.Gender = null;
            FilterPerson.NationalityCode = null;

            await GetPersonClassDataAsync();
        }

        private async Task New()
        {
            NavigationManager.NavigateTo($"/persons/{0}");
        }


        // Download file
        private async Task DownloadAsync(TbPersonDto context)
        {
            var file = TbFileUploadList.FirstOrDefault(x => x.personId == context.Id);

            if (file != null)
            {
                string? fileUrl = file?.fileLink;
                string script = GenerateDownloadScript(fileUrl);

                // Thực thi script bằng cách sử dụng JavaScript interop
                await JSRuntime.InvokeVoidAsync("eval", script);
            }
            else
            {
                await _uiNotificationService.Warn(L["NoDataAvailable"]);
            }
        }

        private string GenerateDownloadScript(string? fileUrl)
        {
            // Tạo script JavaScript để tải xuống tệp
            return @"
                (function() {
                    var a = document.createElement('a');
                    a.href = '" + fileUrl + @"';
                    a.download = ''; 
                    document.body.appendChild(a);
                    a.click();
                    document.body.removeChild(a);
                })();
            ";
        }



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

        private async Task GetHistoryAsync(TbPersonDto context)
        {
            await _blockUiService.Block(selectors: "#lpx-content-container", busy: false);

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
             
            await InvokeAsync(StateHasChanged);
            await _blockUiService.UnBlock();
        }

        private async Task GetTbInfoUpdateListAsync()
        {
            await FetchInfoUpdatesAsync();
            TbInfoUpdateList = _cachedInfoUpdates;

            await InvokeAsync(StateHasChanged);
        }

        private async Task GetHistoryAsync()
        {
            await _blockUiService.Block(selectors: "#lpx-content-container", busy: false);
            screenId = 0;
 
            await GetTbInfoUpdateListAsync();
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

            await InvokeAsync(StateHasChanged);
            await _blockUiService.UnBlock();
        } 

        private async Task HideHistory()
        {
            isColumn1Visible = true;
            isColumn2Visible = false;

            await InvokeAsync(StateHasChanged);
        }

        #endregion History List View--


        private async Task OnFilterChanged<T>(string filterName, T filterValue)
        {
            typeof(GetTbCompanyPersonsInput).GetProperty(filterName)?.SetValue(Filter, filterValue);
            typeof(GetTbPersonsInput).GetProperty(filterName)?.SetValue(FilterPerson, filterValue);
            await GetPersonClassDataAsync();
        }

        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<TbPersonDto> e)
        {
            CurrentSorting = e.Columns
                .Where(c => c.SortDirection != SortDirection.Default)
                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentPage = e.Page;
            await GetTbNationalitiesAsync();
            await GetPersonClassDataAsync();
            await InvokeAsync(StateHasChanged);
        }

        public void GotoEditPage(TbPersonDto context)
        {
            NavigationManager.NavigateTo($"/persons/{context.Id}");
        }

    }
}
