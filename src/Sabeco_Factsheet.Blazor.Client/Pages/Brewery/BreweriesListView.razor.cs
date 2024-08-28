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
using Sabeco_Factsheet.TbBreweries;
using Sabeco_Factsheet.Permissions;
using Sabeco_Factsheet.Shared;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Volo.Abp;
using Volo.Abp.Content;
using Volo.Abp.Http.Client;
using Blazorise.Snackbar;
using Volo.Abp.AspNetCore.Components.BlockUi;
using Volo.Abp.AspNetCore.Components.Messages;
using Sabeco_Factsheet.TbCompanies;
using Sabeco_Factsheet.Blazor.Client.Components.Toolbar;
using DevExpress.ReportServer.ServiceModel.DataContracts;
using Sabeco_Factsheet.Blazor.Client.Pages.History;
using Sabeco_Factsheet.TbInfoUpdates;
using Sabeco_Factsheet.TbUserMappingBreweries;
using Sabeco_Factsheet.TbUsers;
using Volo.Abp.AspNetCore.Components.Notifications;
using Sabeco_Factsheet.TbPersons;



namespace Sabeco_Factsheet.Blazor.Client.Pages.Brewery
{
    public partial class BreweriesListView
    {
        protected List<Volo.Abp.BlazoriseUI.BreadcrumbItem> BreadcrumbItems = new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>();
        protected PageToolbar Toolbar { get; } = new PageToolbar();
        private int PageSize { get; set; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentPage { get; set; } = 1;
        private string CurrentSorting { get; set; } = string.Empty;
        private int TotalCount { get; set; }


        private bool CanCreateTbBrewery { get; set; }
        private bool CanEditTbBrewery { get; set; }
        private bool CanDeleteTbBrewery { get; set; }


        private GetTbBreweriesInput Filter { get; set; }
        private TbBreweryDto SelectedTbBrewery { get; set; } = new TbBreweryDto();
        private List<TbBreweryDto> SelectedTbBreweries { get; set; } = new List<TbBreweryDto>();
        private IReadOnlyList<TbBreweryDto> TbBreweryList { get; set; }
        private IReadOnlyList<TbUserMappingBreweryDto> TbUserMappingBreweryList { get; set; }
        private List<TbCompanyDto> TbCompanyList { get; set; } = new List<TbCompanyDto>();
        private List<TbUserDto> TbUserList { get; set; } = new List<TbUserDto>();

        private IReadOnlyList<TbInfoUpdateDto> TbInfoUpdateList { get; set; } = new List<TbInfoUpdateDto>();
        private IEnumerable<IGrouping<Guid?, TbInfoUpdateDto>> GroupedChanges { get; set; }


        private SnackbarStack? _snackbarStack;
        protected bool showAdvancedFilters { get; set; }
        public string screenName { get; set; } = "Breweries"; 
        public int screenId { get; set; } 
        public bool isColumn1Visible { get; set; } = true;
        public bool isColumn2Visible { get; set; } = false;



        [Parameter]
        public int Id { get; set; }


        //================================== Initialize Section ==================================

        public BreweriesListView()
        {
            Filter = new GetTbBreweriesInput
            {
                MaxResultCount = PageSize,
                SkipCount = (CurrentPage - 1) * PageSize,
                Sorting = CurrentSorting
            };

            TbBreweryList = new List<TbBreweryDto>();
            TbUserMappingBreweryList = new List<TbUserMappingBreweryDto>();
            _snackbarStack = new SnackbarStack();
        }

        protected override async Task OnInitializedAsync()
        { 
            await SetPermissionsAsync();
            await SetToolbarItemsAsync();
            await SetBreadcrumbItemsAsync();

            await GetUserListAsync();
            await GetCompanyListAsync();
            await GetUserMappingBreweryListAsync();
            await GetClassDataAsync(); 
        }

        //================================== ToolBar - Breadcrumb - Permission =======================================

        protected virtual ValueTask SetBreadcrumbItemsAsync()
        {
            BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["TbBreweries"]));
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
            CanCreateTbBrewery = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbBreweries.Create);
            CanEditTbBrewery = await AuthorizationService
                            .IsGrantedAsync(Sabeco_FactsheetPermissions.TbBreweries.Edit);
            CanDeleteTbBrewery = await AuthorizationService
                            .IsGrantedAsync(Sabeco_FactsheetPermissions.TbBreweries.Delete);
        }

        //================================== Load Data, Search, New, Delete, Export Excel ==================================

        private async Task RefreshDataAsync(bool isRefresh)
        {
            if (isRefresh)
                Filter = new GetTbBreweriesInput(); // Clear all filter values for refresh
            await GetClassDataAsync();
            await InvokeAsync(StateHasChanged);
        }
        private async Task GetClassDataAsync()
        {
            Filter.MaxResultCount = PageSize;
            Filter.SkipCount = (CurrentPage - 1) * PageSize;
            Filter.Sorting = CurrentSorting;

            // Lấy danh sách UserMappingBrewery của người dùng hiện tại
            await GetUserMappingBreweryListAsync();

            // Lấy tất cả dữ liệu mà không phân trang để tính TotalCount
            var allCompaniesResult = await TbBreweriesAppService.GetListNoPagedAsync(Filter);

            // Lọc danh sách dựa trên quyền truy cập của người dùng
            var filteredBreweries = allCompaniesResult
                .Where(x => TbUserMappingBreweryList.Any(mapping => mapping.breweryid == x.Id))
                .ToList();

            // Áp dụng bộ lọc FilterText cho các trường không phân biệt hoa thường
            if (!string.IsNullOrEmpty(Filter.FilterText))
            {
                string lowerFilterText = Filter.FilterText.ToLower();

                filteredBreweries = filteredBreweries
                    .Where(x => (x.BreweryCode != null && x.BreweryCode.ToLower().Contains(lowerFilterText)) ||
                                (x.BreweryName != null && x.BreweryName.ToLower().Contains(lowerFilterText)) ||
                                (x.BreweryName_EN != null && x.BreweryName_EN.ToLower().Contains(lowerFilterText)) ||
                                (x.BriefName != null && x.BriefName.ToLower().Contains(lowerFilterText)) ||
                                (x.BreweryAdress != null && x.BreweryAdress.ToLower().Contains(lowerFilterText)) ||
                                (x.CapacityVolume != null && x.CapacityVolume.Value.ToString().ToLower().Contains(lowerFilterText)))
                    .ToList();
            }
 
            // Tính TotalCount dựa trên danh sách đã lọc
            TotalCount = filteredBreweries.Count();

            // Áp dụng phân trang cho dữ liệu đã lọc
            var pagedBreweries = filteredBreweries
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            TbBreweryList = pagedBreweries;
            await InvokeAsync(StateHasChanged);
        }


        private async Task Refresh()
        {
            Filter.BreweryCode = null;
            Filter.BriefName = null;
            Filter.BreweryName_EN = null;
            Filter.BreweryAdress = null;

            await GetClassDataAsync();
        }

        private async Task GetCompanyListAsync()
        {
            TbCompanyList = await TbCompaniesAppService.GetListNoPagedAsync(new GetTbCompaniesInput { });
        }

        private async Task GetUserListAsync()
        {
            TbUserList = await TbUsersAppService.GetListNoPagedAsync(new GetTbUsersInput { });
        }

        private async Task GetUserMappingBreweryListAsync()
        {
            var currentUserName = CurrentUser.UserName;
            var userId = TbUserList.FirstOrDefault(x => x.UserName == currentUserName)?.Id;

            if (userId != null)
            {
                var result = await TbUserMappingBreweriesAppService.GetListNoPagedAsync(new GetTbUserMappingBreweriesInput { });
                TbUserMappingBreweryList = result.Where(x => x.userid == userId && x.IsActive == true).ToList();
            }
        }


        //============================Controls triggers/events=========================================
        #region Controls triggers/events

        private async Task ChangePageSize(int value)
        {
            PageSize = value;
            await Task.CompletedTask;
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

        private async Task GetHistoryAsync(TbBreweryDto context)
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

            await _blockUiService.UnBlock();
            await InvokeAsync(StateHasChanged);
        }

        private async Task GetTbInfoUpdateListAsync()
        {
            await FetchInfoUpdatesAsync();
            TbInfoUpdateList = _cachedInfoUpdates;

            await InvokeAsync(StateHasChanged);
        }

        private async Task GetHistoryAsync()
        {
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
            typeof(GetTbBreweriesInput).GetProperty(filterName)?.SetValue(Filter, filterValue);
            await GetClassDataAsync();
        }

        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<TbBreweryDto> e)
        {
            CurrentSorting = e.Columns
                .Where(c => c.SortDirection != SortDirection.Default)
                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentPage = e.Page;
            await GetClassDataAsync();
            await InvokeAsync(StateHasChanged);
        }

        protected void GotoEditPage(TbBreweryDto context)
        {
            NavigationManager.NavigateTo($"breweries/{context.Id}");
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

        #endregion

    }
}
