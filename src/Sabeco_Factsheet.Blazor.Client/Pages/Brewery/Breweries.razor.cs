using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Web;


using Blazorise;
using Blazorise.Snackbar;
using Blazorise.DataGrid;
using DevExpress.Blazor;


using Volo.Abp;
using Volo.Abp.Content;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Application.Dtos;
using Volo.Abp.BlazoriseUI.Components;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.AspNetCore.Components.Progression;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using AutoMapper.Internal.Mappers;


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.Routing;


using Sabeco_Factsheet.TbCompanies;
using Sabeco_Factsheet.TbBrewerySkuTemps;
using Sabeco_Factsheet.TbBreweryTemps;
using Sabeco_Factsheet.TbInfoUpdates;
using Sabeco_Factsheet.Blazor.Client.Components.Toolbar;
using Sabeco_Factsheet.TbSkus;
using Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps;
using Sabeco_Factsheet.TbBreweries;
using Sabeco_Factsheet.Permissions;
using Sabeco_Factsheet.Shared;
using Sabeco_Factsheet.TbBreweryDeliveryVolumes;
using Sabeco_Factsheet.TbBrewerySkus;
using Sabeco_Factsheet.TbUsers;
using System.Reflection;
using Excubo.Blazor.TreeViews;


namespace Sabeco_Factsheet.Blazor.Client.Pages.Brewery
{
    public partial class Breweries
    {
        protected List<Volo.Abp.BlazoriseUI.BreadcrumbItem> BreadcrumbItems = new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>();
        protected PageToolbar Toolbar { get; } = new PageToolbar();
        private int PageSize { get; set; } = 5;
        private EditForm EditFormMain { get; set; } //Id of Main form
        private bool isDataEntryChanged { get; set; }
        private bool isNew { get; set; } = false;
        private string PopupHeaderText => isNew ? "AddNew" : "Details";


        private bool CanCreateBrewerySKU { get; set; }
        private bool CanEditBrewerySKU { get; set; }
        private bool CanDeleteBrewerySKU { get; set; }
        private bool CanCreateBreweryDeliveryVolume { get; set; }
        private bool CanEditBreweryDeliveryVolume { get; set; }
        private bool CanDeleteBreweryDeliveryVolume { get; set; }


        [Parameter]
        public string Id { get; set; } // Đầu vào kiểu string
        public int EditingBreweryId { get; set; }
        public int EditingBreweryTempId { get; set; }

        private DateTime? _deliveryVolumeDateTime { get; set; }
        private DateTime? _skuDateTime { get; set; }
        private bool editFormPopupVisible { get; set; } = false;


        private TbSkuUpdateDto EditingSku { get; set; } = new TbSkuUpdateDto();
        private TbBreweryUpdateDto EditingBrewery { get; set; } = new TbBreweryUpdateDto();
        private TbBreweryTempUpdateDto EditingBreweryTemp { get; set; } = new TbBreweryTempUpdateDto();
        private TbBreweryDeliveryVolumeUpdateDto EditingBreweryDeliveryVolume { get; set; }
        private TbBrewerySkuUpdateDto EditingBrewerySKU { get; set; } = new TbBrewerySkuUpdateDto();


        private List<TbCompanyDto> TbCompanyList { get; set; } = new List<TbCompanyDto>();
        private List<TbBreweryUpdateDto> BreweryList { get; set; } = new List<TbBreweryUpdateDto>();
        private List<TbUserDto> UserList { get; set; } = new List<TbUserDto>();


        ///// <summary> 
        ///// BreweryDeliveryVolumeGrid
        ///// </summary> 
        ///
        private EditContext _gridBreweryEditContext;
        private int EditingBreweryDeliveryVolumeId { get; set; } = 0;
        private IGrid BreweryDeliveryVolumeGrid { get; set; }
        private IReadOnlyList<object> selectedBreweryDeliveryVolume { get; set; } = new List<TbBreweryDeliveryVolumeUpdateDto>();


        private List<TbBreweryDeliveryVolumeUpdateDto> BreweryDeliveryVolumeList = new List<TbBreweryDeliveryVolumeUpdateDto> { };

        private List<TbBreweryDeliveryVolumeTempUpdateDto> BreweryDeliveryVolumeTempList = new List<TbBreweryDeliveryVolumeTempUpdateDto> { };
        private List<TbBreweryDeliveryVolumeTempUpdateDto> ExitsBreweryDeliveryVolumeTempList = new List<TbBreweryDeliveryVolumeTempUpdateDto> { };



        ///// <summary> 
        ///// BrewerySKUGrid
        ///// </summary> 
        ///
        private EditContext _gridBrewerySKUEditContext;
        private int EditingBrewerySKUId { get; set; } = 0;
        private IGrid BrewerySKUGrid { get; set; }
        private IReadOnlyList<object> selectedBrewerySKU { get; set; } = new List<TbBrewerySkuUpdateDto>();
        private List<TbSkuDto> TbSkuList { get; set; } = new List<TbSkuDto>();

        private List<TbBrewerySkuUpdateDto> BrewerySKUList = new List<TbBrewerySkuUpdateDto> { };

        private List<TbBrewerySkuTempUpdateDto> BrewerySKUTempList = new List<TbBrewerySkuTempUpdateDto> { };

        private List<TbBrewerySkuTempUpdateDto> ExitsBrewerySKUTempList = new List<TbBrewerySkuTempUpdateDto> { };
        private List<TbBrewerySkuUpdateDto> SelectedBrewerySKU { get; set; } = new List<TbBrewerySkuUpdateDto>();




        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                            INITIALIZE SECTION
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        #region
        public Breweries()
        {
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await _blockUiService.Block(selectors: "#lpx-content-container", busy: false);

                await LoadGridData();

                await _blockUiService.UnBlock();
            }
            await base.OnAfterRenderAsync(firstRender);
        }


        protected override async Task OnInitializedAsync()
        {
            EditingBreweryId = int.Parse(Id);
            await SetPermissionsAsync();
            await SetToolbarItemsAsync(); 
        }





        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                      ToolBar - Breadcrumb - Permission   
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        protected virtual ValueTask SetBreadcrumbItemsAsync()
        {
            BreadcrumbItems.AddRange(new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>
            {
                new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:TbBreweries"],"/breweries"),
                new Volo.Abp.BlazoriseUI.BreadcrumbItem(EditingBrewery.BreweryCode)
            });
            return ValueTask.CompletedTask;
        }

        protected virtual ValueTask SetToolbarItemsAsync()
        {
            Toolbar.AddButton(L["Back"], async () =>
            {
                NavigationManager.NavigateTo($"/breweries");
                await Task.CompletedTask;
            },
             IconName.Undo,
            Blazorise.Color.Default);


            Toolbar.AddButton(L["Save"], async () =>
            {
                await SaveDataAsync();
                await Task.CompletedTask;
            },
            IconName.Save,
            Color.Primary,
            requiredPolicyName: Sabeco_FactsheetPermissions.TbBreweries.Edit);


            return ValueTask.CompletedTask;
        }

        private async Task SetPermissionsAsync()
        {
            CanCreateBreweryDeliveryVolume = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbBreweries.Create);
            CanEditBreweryDeliveryVolume = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbBreweries.Edit);
            CanDeleteBreweryDeliveryVolume = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbBreweries.Delete);

            CanCreateBrewerySKU = await AuthorizationService
               .IsGrantedAsync(Sabeco_FactsheetPermissions.TbBreweries.Create);
            CanEditBrewerySKU = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbBreweries.Edit);
            CanDeleteBrewerySKU = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbBreweries.Delete);

        }

        #endregion

        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                           SELECTED VALUE CHANGED
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        private async Task OnValueChanged(int? newValue)
        {
            isDataEntryChanged = true;
            var brewerySKU = TbSkuList.FirstOrDefault(x => x.Id == newValue);
            EditingBrewerySKU.SKUId = newValue;
            EditingBrewerySKU.SKUCode = brewerySKU?.Code;
            await Task.CompletedTask;
        }





        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                              LOAD DATA LIST
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


        private async Task LoadGridData()
        {
            await GetUserListAsync();
            await GetSkuListAsync();
            await GetCompanyListAsync();
            await GetTbBrewerySkuAsync();
            await GetTbBreweryDeliveryVolumeAsync();

            await GetClassDataAsync();
            await LoadDataAsync(EditingBreweryId);
            await SetBreadcrumbItemsAsync();
        }

        private async Task LoadDataAsync(int classId)
        {
            await _pageProgressService.Go(null, options => { options.Type = UiPageProgressType.Info; });
            if (classId != 0)
            {
                EditingBrewery = ObjectMapper.Map<TbBreweryDto, TbBreweryUpdateDto>(await TbBreweriesAppService.GetAsync(classId));
            }
            else
            {
                EditingBrewery = new TbBreweryUpdateDto();

                EditingBrewerySKU.ProductionVolume = 0;
                EditingBreweryDeliveryVolume.DeliveryVolume = 0;
            }

            await InvokeAsync(StateHasChanged);
            await _pageProgressService.Go(-1);
        }

        private async Task GetClassDataAsync()
        {
            if (isDataEntryChanged == true)
            {
                var confirmed = await _uiMessageService.Confirm(L["SavingConfirmationMessage"]);
                if (confirmed)
                {
                    var result = await TbBreweriesAppService.GetListNoPagedAsync(new GetTbBreweriesInput { });
                    BreweryList = ObjectMapper.Map<List<TbBreweryDto>, List<TbBreweryUpdateDto>>((List<TbBreweryDto>)result);
                }
            }
            else
            {
                var result = await TbBreweriesAppService.GetListNoPagedAsync(new GetTbBreweriesInput { });
                BreweryList = ObjectMapper.Map<List<TbBreweryDto>, List<TbBreweryUpdateDto>>((List<TbBreweryDto>)result);
            }
        }

        private async Task GetCompanyListAsync()
        {
            TbCompanyList = await TbCompaniesAppService.GetListNoPagedAsync(new GetTbCompaniesInput { });
        }

        private async Task GetSkuListAsync()
        {
            TbSkuList = await TbSkusAppService.GetListNoPagedAsync(new GetTbSkusInput { });
        }

        private async Task GetUserListAsync()
        {
            UserList = await TbUsersAppService.GetListNoPagedAsync(new GetTbUsersInput { });
        }

        private async Task GetTbBreweryDeliveryVolumeAsync()
        {
            var result = await TbBreweryDeliveryVolumesAppService.GetListByBreweryId(EditingBreweryId);
            BreweryDeliveryVolumeList = ObjectMapper.Map<List<TbBreweryDeliveryVolumeDto>, List<TbBreweryDeliveryVolumeUpdateDto>>((List<TbBreweryDeliveryVolumeDto>)result); 
        }

        private async Task GetTbBrewerySkuAsync()
        {
            var result = await TbBrewerySkusAppService.GetListByBreweryId(EditingBreweryId);
            BrewerySKUList = ObjectMapper.Map<List<TbBrewerySkuDto>, List<TbBrewerySkuUpdateDto>>((List<TbBrewerySkuDto>)result);
        }








        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                              INSERT - UPDATE
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        private bool isSaving = false;
        private async Task SaveDataAsync()
        {
            if (isSaving)
            {
                return; // Ngăn chặn lưu liên tục
            }

            isSaving = true;

            try
            {
                if (isDataEntryChanged)
                {
                    if (EditingBreweryId != 0)
                    {
                        await _blockUiService.Block(selectors: "#lpx-content-container", busy: false);

                        var originalItem = await TbBreweriesAppService.GetAsync(EditingBreweryId);
                        var originalDto = ObjectMapper.Map<TbBreweryDto, TbBreweryUpdateDto>(originalItem);

                        if (!FileHelper.ArePropertiesEqual(EditingBrewery, originalDto))
                        {
                            //Ghi log thay đổi cho thao tác UPDATE
                            await SaveEntityChanges(
                                originalDto.Id,
                                "UPDATE",
                                originalDto,
                                EditingBrewery,
                                "tbBreweries",
                                "Brewery"
                            );

                            await _uiNotificationService.Success(L["Notification:Edit"]);
                        }
                        isDataEntryChanged = false;
                        await LoadDataAsync(EditingBreweryId);

                        await _blockUiService.UnBlock();
                    }

                }
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
                await _blockUiService.UnBlock();
            }
            finally
            {
                isSaving = false; // Đặt cờ về false khi hoàn tất
            }
        }




        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                        Controls triggers/events
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        private async Task ChangePageSize(int value)
        {
            PageSize = value;
            await Task.CompletedTask;
        }

        private async Task ResetToolbar()
        {
            Toolbar.Contributors.Clear();
            await SetToolbarItemsAsync();
        }

        private async Task ClickDeliveryVolumeEditRow()
        {
            editFormPopupVisible = true;
            await Task.CompletedTask;
        }

        private async Task ClickSKUEditRow()
        {
            editFormPopupVisible = true;
            await Task.CompletedTask;
        }




        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                                 GRID
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        #region Brewery Delivery Volume Grid

        private async Task SaveBreweryDeliveryVolumeAsync()
        {
            if (!isDataEntryChanged) return;

            await BreweryDeliveryVolumeGrid.SaveChangesAsync();
            BreweryDeliveryVolumeTempList.Clear();

            var itemsToSave = BreweryDeliveryVolumeList.Where(x => x.IsChanged).ToList();

            if (!itemsToSave.Any()) return;

            foreach (var item in itemsToSave)
            {
                var updateDto = new TbBreweryDeliveryVolumeTempUpdateDto
                {
                    Year = item.Year,
                    DeliveryVolume = item.DeliveryVolume,
                    BreweryCode = item.BreweryCode,
                    BreweryId = item.BreweryId,
                    isActive = item.isActive,
                    idBreweryDeliveryVolume = item.Id,
                };

                BreweryDeliveryVolumeTempList.Add(updateDto);

                if (item.Id == 0)
                {
                    var createDto = ObjectMapper.Map<TbBreweryDeliveryVolumeTempUpdateDto, TbBreweryDeliveryVolumeTempCreateDto>(updateDto);
                    createDto.create_date = DateTime.UtcNow;
                    createDto.create_user = item.create_user;

                    // thêm mới dữ liệu vào bảng tạm
                    var breweryDeliveryVolume = await TbBreweryDeliveryVolumeTempsAppService.CreateAsync(createDto);
                    EditingBreweryDeliveryVolumeId = breweryDeliveryVolume.Id;

                    // thêm thông tin thêm mới vào lịch sử
                    await SaveEntityChanges(
                        EditingBreweryDeliveryVolumeId,
                        "INSERT",
                        null,
                        breweryDeliveryVolume,
                        "tbBreweryDeliveryVolume_Temp",
                        "DeliveryVolumeByYear"
                    );
                    await _uiNotificationService.Success(L["Notification:Save"]);
                }
                else
                {
                    // Sử dụng hàm so sánh
                    var originalItem = await TbBreweryDeliveryVolumesAppService.GetAsync(item.Id);
                    var originalDto = ObjectMapper.Map<TbBreweryDeliveryVolumeDto, TbBreweryDeliveryVolumeUpdateDto>(originalItem);

                    if (!FileHelper.ArePropertiesEqual(item, originalDto))
                    {
                        await SaveEntityChanges(
                            originalDto.Id,
                            "UPDATE",
                            originalDto,
                            item,
                            "tbBreweryDeliveryVolume",
                            "DeliveryVolumeByYear"
                        );
                        await _uiNotificationService.Success(L["Notification:Edit"]);
                    }
                }

                item.IsChanged = false;
            }

            isDataEntryChanged = false;
            await GetTbBreweryDeliveryVolumeAsync();
        }

        private bool ArePropertiesEqual<T>(T obj1, T obj2)
        {
            // Kiểm tra trường hợp null
            if (obj1 == null || obj2 == null)
                return object.Equals(obj1, obj2);

            // So sánh các thuộc tính
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var value1 = property.GetValue(obj1);
                var value2 = property.GetValue(obj2);

                if (!object.Equals(value1, value2))
                    return false;
            }
            return true;
        }



        private async Task BreweryDeliveryVolumeGridNew_Click()
        {
            _deliveryVolumeDateTime = null;
            if (EditingBreweryDeliveryVolume == null)
            {
                EditingBreweryDeliveryVolume = new TbBreweryDeliveryVolumeUpdateDto();
            }

            await BreweryDeliveryVolumeGrid.SaveChangesAsync();
            BreweryDeliveryVolumeGrid.ClearSelection();
            await BreweryDeliveryVolumeGrid.StartEditNewRowAsync();
        }

        private void BreweryDeliveryVolumeGrid_EditModelSaving(GridEditModelSavingEventArgs e)
        {
            TbBreweryDeliveryVolumeUpdateDto editModel = (TbBreweryDeliveryVolumeUpdateDto)e.EditModel;

            var currentUser = CurrentUser.UserName;
            var user = UserList.FirstOrDefault(x => x.UserName == currentUser);

            if (editModel != null)
            {
                // Kiểm tra trùng lặp trong danh sách chính
                var duplicateInMainList = BreweryDeliveryVolumeList
                    .Any(record => record.BreweryId == editModel.BreweryId &&
                                   record.Year == editModel.Year &&
                                   record.Id != editModel.Id); // Không tính bản ghi hiện tại

                if (duplicateInMainList)
                {
                    _uiMessageService.Error(L["Notification:DuplicateRecord"]);
                    e.Cancel = true;
                    return;
                }

                if (editModel.Year == 0)
                {
                    _uiMessageService.Error(L["Notification:IncompleteData"]);
                    e.Cancel = true;
                    return;
                }

                editModel.IsChanged = true;
                isDataEntryChanged = true;

                if (!e.IsNew)
                {
                    // Update existing model
                    editModel.mod_date = DateTime.Now;
                    editModel.mod_user = user.Id;

                    // Update the existing item in the list
                    int index = BreweryDeliveryVolumeList.FindIndex(item => item.Id == editModel.Id);
                    if (index != -1)
                    {
                        BreweryDeliveryVolumeList[index] = editModel;
                    }
                }
                else
                {
                    // Add new model
                    editModel.Idx = BreweryDeliveryVolumeList.Count > 0
                        ? BreweryDeliveryVolumeList.Max(x => x.Idx) + 1
                        : 1;

                    BreweryDeliveryVolumeList.Add(editModel);
                }
            }
        }

        private void BreweryDeliveryVolumeGrid_OnCustomizeEditModel(GridCustomizeEditModelEventArgs e)
        {
            var currentUser = CurrentUser.UserName;
            var user = UserList.FirstOrDefault(x => x.UserName == currentUser);

            if (e.IsNew)
            {
                var newRow = (TbBreweryDeliveryVolumeUpdateDto)e.EditModel;

                // Tính toán Idx tạm thời cho hàng mới
                newRow.Idx = BreweryDeliveryVolumeList.Count > 0
                    ? BreweryDeliveryVolumeList.Max(x => x.Idx) + 1
                    : 1;

                newRow.BreweryId = EditingBreweryId;
                newRow.BreweryCode = EditingBrewery.BreweryCode;
                newRow.create_date = DateTime.Now;
                newRow.create_user = user.Id;
                newRow.isActive = true;
                newRow.IsChanged = true;
            }
        }

        private void BreweryDeliveryVolumeGrid_CustomizeDataRowEditor(GridCustomizeDataRowEditorEventArgs e)
        {
            if (e.EditSettings is ITextEditSettings settings)
                settings.ShowValidationIcon = true;
        }

        #endregion BreweryDeliveryVolumeGrid



        #region Product Manufaturing Grid 
        private async Task SaveBrewerySKUAsync()
        {
            if (!isDataEntryChanged) return;

            // Lưu thay đổi và xóa danh sách tạm
            await BrewerySKUGrid.SaveChangesAsync();
            BrewerySKUTempList.Clear();

            var itemsToSave = BrewerySKUList.Where(x => x.IsChanged).ToList();

            if (!itemsToSave.Any()) return;

            foreach (var item in itemsToSave)
            {
                var updateDto = new TbBrewerySkuTempUpdateDto
                {
                    BreweryCode = item.BreweryCode,
                    DocStatus = item.DocStatus,
                    BreweryId = item.BreweryId,
                    Year = item.Year,
                    SKUId = item.SKUId,
                    SKUCode = item.SKUCode,
                    ProductionVolume = item.ProductionVolume,
                    IsActive = item.IsActive
                };

                BrewerySKUTempList.Add(updateDto);

                if (item.Id == 0)
                {
                    // Thao tác INSERT
                    var createDto = ObjectMapper.Map<TbBrewerySkuTempUpdateDto, TbBrewerySkuTempCreateDto>(updateDto);
                    createDto.crt_date = item.crt_date;
                    createDto.crt_user = item.crt_user;

                    var brewerySKU = await TbBrewerySkuTempsAppService.CreateAsync(createDto);
                    EditingBrewerySKUId = brewerySKU.Id;

                    await SaveEntityChanges(
                        EditingBrewerySKUId,
                        "INSERT",
                        null,
                        brewerySKU,
                        "tbBrewerySKU_Temp",
                        "ProductManufacturing"
                    );

                    await _uiNotificationService.Success(L["Notification:Save"]);
                }
                else
                {
                    // Thao tác UPDATE
                    var originalItem = await TbBrewerySkusAppService.GetAsync(item.Id);
                    var originalDto = ObjectMapper.Map<TbBrewerySkuDto, TbBrewerySkuUpdateDto>(originalItem);

                    if (!FileHelper.ArePropertiesEqual(item, originalDto))
                    {
                        await SaveEntityChanges(
                        item.Id,
                        "UPDATE",
                        originalDto,
                        item,
                        "tbBrewerySKU",
                        "ProductManufacturing"
                        );

                        await _uiNotificationService.Success(L["Notification:Edit"]);
                    }
                }

                updateDto.IsChanged = false;
            }

            isDataEntryChanged = false;
            await GetTbBrewerySkuAsync();
        }

        private async Task BrewerySKUGridNew_Click()
        {
            await BrewerySKUGrid.SaveChangesAsync();
            BrewerySKUGrid.ClearSelection();
            await BrewerySKUGrid.StartEditNewRowAsync();
        }

        private void BrewerySKUGrid_OnCustomizeEditModel(GridCustomizeEditModelEventArgs e)
        {
            var currentUser = CurrentUser.UserName;
            var user = UserList.FirstOrDefault(x => x.UserName == currentUser);

            if (e.IsNew)
            {
                var newRow = (TbBrewerySkuUpdateDto)e.EditModel;

                // Tính toán Idx tạm thời cho hàng mới
                newRow.Idx = BrewerySKUList.Count > 0
                    ? BrewerySKUList.Max(x => x.Idx) + 1
                    : 1;

                newRow.DocStatus = 0;
                newRow.BreweryId = EditingBreweryId;
                newRow.BreweryCode = EditingBrewery.BreweryCode;
                newRow.crt_date = DateTime.Now;
                newRow.crt_user = user.Id;
                newRow.IsActive = true;
                newRow.IsChanged = true;
            }
        }
        private void BrewerySKUGrid_EditModelSaving(GridEditModelSavingEventArgs e)
        {
            TbBrewerySkuUpdateDto editModel = (TbBrewerySkuUpdateDto)e.EditModel;

            var currentUser = CurrentUser.UserName;
            var user = UserList.FirstOrDefault(x => x.UserName == currentUser);

            if (editModel != null)
            {
                // Kiểm tra trùng lặp trong danh sách chính
                var duplicateInMainList = BrewerySKUList
                    .Any(record => record.BreweryId == editModel.BreweryId &&
                                   record.SKUId == editModel.SKUId &&
                                   record.Year == editModel.Year &&
                                   record.Id != editModel.Id); // Không tính bản ghi hiện tại

                if (duplicateInMainList)
                {
                    _uiMessageService.Error(L["Notification:DuplicateRecord"]);
                    e.Cancel = true;
                    return;
                }

                if (editModel.Year == 0 || editModel.SKUId == null || editModel.SKUCode == null)
                {
                    _uiMessageService.Error(L["Notification:IncompleteData"]);
                    e.Cancel = true;
                    return;
                }

                editModel.IsChanged = true;
                isDataEntryChanged = true;

                if (!e.IsNew)
                {
                    // Update existing model
                    editModel.mod_date = DateTime.Now;
                    editModel.mod_user = user.Id;

                    // Update the existing item in the list
                    int index = BrewerySKUList.FindIndex(item => item.Id == editModel.Id);
                    if (index != -1)
                    {
                        BrewerySKUList[index] = editModel;
                    }
                }
                else
                {
                    // Add new model
                    editModel.Idx = BrewerySKUList.Count > 0
                        ? BrewerySKUList.Max(x => x.Idx) + 1
                        : 1;

                    BrewerySKUList.Add(editModel);
                }
            }
        }


        #endregion ProductManufacturingGrid






        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                         THÔNG BÁO - VALIDATIONS
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            bool checkSaving = await SavingConfirmAsync();
            if (!checkSaving)
                context.PreventNavigation();
        }


        #region --THÔNG BÁO KHI CÓ SỰ THAY ĐỔI NHƯNG MUỐN BACK RA NGOÀI
        private async Task<bool> SavingConfirmAsync()
        {
            if (isDataEntryChanged)
            {
                var confirmed = await _uiMessageService.Confirm(L["SavingConfirmationMessage"]);
                if (confirmed)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }
        #endregion





        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                                  HISTORY       
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        #region --History

        private bool IsColumnVisible(string columnName)
        {
            // Danh sách các cột muốn hiển thị
            var visibleColumns = new List<string>
            {
                "Year",
                "SKUId",
                "ProductionVolume",
                "DeliveryVolume",
                "SKUId",
                "ProductionVolume",
                "Note",
                "CompanyId",
                "Brewery",
                "BriefName",
                "BreweryName",
                "BreweryAdress",
                "BreweryName_EN",
                "CapacityVolume",
            };

            // Kiểm tra xem cột hiện tại có trong danh sách các cột được hiển thị không
            return visibleColumns.Contains(columnName);
        }

        private static readonly HashSet<string> DecimalColumns = new HashSet<string>
        {
            "CapacityVolume",  
            "ProductionVolume",  
            "DeliveryVolume",   
            "ProductionVolume",  
        }; 

        private async Task SaveEntityChanges<TDto>(int rowId, string command, TDto originalItem, TDto updatedItem, string tableName, string? groupName)
        where TDto : class
        {
            var changes = new List<TbInfoUpdateCreateDto>();
            var changeSetId = Guid.NewGuid();

            if (command == "INSERT")
            {
                var newValues = FileHelper.GetAllFieldValues(updatedItem);
                foreach (var field in newValues)
                {
                    // Định dạng giá trị nếu cột có kiểu decimal
                    string formattedValue = FormatDecimalValue(field.Key, field.Value);

                    var isVisible = IsColumnVisible(field.Key); // Kiểm tra xem cột có được hiển thị không
                    var infoUpdate = CreateInfoUpdateDto(field.Key, null, formattedValue, EditingBreweryId, rowId, command, tableName, changeSetId, groupName, isVisible);
                    changes.Add(infoUpdate);
                }
            }
            else if (command == "UPDATE")
            {
                var originalValues = FileHelper.GetAllFieldValues(originalItem);
                var updatedValues = FileHelper.GetAllFieldValues(updatedItem);

                foreach (var field in originalValues.Keys)
                {
                    if (originalValues[field] != updatedValues[field])
                    {
                        string formattedLastValue = FormatDecimalValue(field, originalValues[field]);
                        string formattedNewValue = FormatDecimalValue(field, updatedValues[field]);

                        // Xử lý trường hợp dữ liệu cũ là chuỗi rỗng và dữ liệu mới là null
                        if (originalValues[field] == null && updatedValues[field] == "")
                        {
                            return;
                        }

                        var isVisible = IsColumnVisible(field); // Kiểm tra xem cột có được hiển thị không
                        var infoUpdate = CreateInfoUpdateDto(field, formattedLastValue, formattedNewValue, EditingBreweryId, rowId, command, tableName, changeSetId, groupName, isVisible);
                        changes.Add(infoUpdate);
                    }
                }
            }

            foreach (var change in changes)
            {
                await TbInfoUpdatesAppService.CreateAsync(change);
            }
        }

        private string FormatDecimalValue(string columnName, string? value)
        {
            // Kiểm tra nếu cột có kiểu decimal
            if (DecimalColumns.Contains(columnName))
            {
                if (decimal.TryParse(value, out var decimalValue))
                {
                    return decimalValue.ToString("F2"); // Định dạng giá trị với 2 chữ số thập phân
                }
            }
            return value ?? "null"; // Trả về giá trị gốc nếu không phải là cột kiểu decimal hoặc không thể chuyển đổi
        }
         

        private TbInfoUpdateCreateDto CreateInfoUpdateDto(string columnName, string? lastValue, string? newValue, int screenId, int rowId, string command, string tableName, Guid changeSetId, string? groupName, bool isVisible)
        {
            var currentUser = UserList.FirstOrDefault(x => x.UserName == CurrentUser.UserName);

            return new TbInfoUpdateCreateDto
            {
                ChangeSetId = changeSetId,
                TableName = tableName,
                ColumnName = columnName,
                ScreenName = "Breweries",
                ScreenId = screenId,
                GroupName = groupName,
                RowId = rowId,
                Command = command,
                LastValue = lastValue,
                NewValue = newValue,
                DocStatus = 0,
                Comment = "",
                IsActive = 1,
                IsVisible = isVisible, // hiển thị thông tin của column đó lên màn hình history => true: hiện , false: ẩn
                TimeAssessment = null,
                crt_user = currentUser?.Id,
                crt_date = DateTime.Now,
                mod_user = null,
                mod_date = null
            };
        }


        #endregion History-- 

    }
}
