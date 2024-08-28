using Blazorise;
using Blazorise.Snackbar;
using DevExpress.Blazor;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Sabeco_Factsheet.Permissions;
using Sabeco_Factsheet.TbAdditionInfos;
using Sabeco_Factsheet.TbCompanies;
using Sabeco_Factsheet.TbCompanyBusinesses;
using Sabeco_Factsheet.TbCompanyPersons;
using Sabeco_Factsheet.TbCompanyInvests;
using Sabeco_Factsheet.TbFileUploads;
using Sabeco_Factsheet.TbLandInfos;
using Sabeco_Factsheet.TbCompanyMajors;
using Sabeco_Factsheet.TbCompanyPersonTemps;
using Sabeco_Factsheet.TbPersons;
using Sabeco_Factsheet.TbPositions;
using Sabeco_Factsheet.EnumList;
using Sabeco_Factsheet.TsClasses;
using Sabeco_Factsheet.TbInfoUpdates;
using Sabeco_Factsheet.TbUsers;
using Sabeco_Factsheet.TbBreweryDeliveryVolumes;
using Sabeco_Factsheet.TbBrewerySkus;
using Sabeco_Factsheet.TbCompanyMappings;
using Sabeco_Factsheet.TbCompanyMajorTemps;
using Sabeco_Factsheet.TbAdditionInfoTemps;
using Sabeco_Factsheet.TbCompanyInvestTemps;
using Sabeco_Factsheet.TbFileUploadTemps;
using Sabeco_Factsheet.TbLandInfoTemps;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using Volo.Abp.AspNetCore.Components.Progression;
using DevExpress.ReportServer.ServiceModel.DataContracts;
using Volo.Abp.Application.Dtos;
using System.IO;
using Sabeco_Factsheet.Blazor.Client.Pages.Person;
using System.ComponentModel.Design;
using System.Threading;
using Volo.Abp.Users;
using Excubo.Blazor.TreeViews;
using Sabeco_Factsheet.TbUserMappingCompanies;
using Sabeco_Factsheet.TbUserMappingPersons;


namespace Sabeco_Factsheet.Blazor.Client.Pages.Company
{
    public partial class Companies
    {
        protected List<Volo.Abp.BlazoriseUI.BreadcrumbItem> BreadcrumbItems = new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>();
        protected PageToolbar Toolbar { get; } = new PageToolbar();
        private int AdditionInfoPageSize { get; set; } = 5;
        private int InvestmentPageSize { get; set; } = 5;
        private int LandInfoPageSize { get; set; } = 5;
        private int BOMPageSize { get; set; } = 5;
        private int BOSPageSize { get; set; } = 5;
        private int BODPageSize { get; set; } = 5;
        private int MemberPageSize { get; set; } = 5;
        private int MajorPageSize { get; set; } = 5;
        private int FileUploadPageSize { get; set; } = 5;
        private int TotalCount { get; set; }
        private EditForm EditFormMain { get; set; } //Id of Main form


        private bool CanCreateAdditionInfo { get; set; }
        private bool CanEditAdditionInfo { get; set; }
        private bool CanDeleteAdditionInfo { get; set; }

        private bool CanCreateLandInfomation { get; set; }
        private bool CanEditLandInfomation { get; set; }
        private bool CanDeleteLandInfomation { get; set; }

        private bool CanCreateInvestment { get; set; }
        private bool CanEditInvestment { get; set; }
        private bool CanDeleteInvestment { get; set; }

        private bool CanCreateMajor { get; set; }
        private bool CanEditMajor { get; set; }
        private bool CanDeleteMajor { get; set; }

        private bool CanCreateFileUpload { get; set; }
        private bool CanEditFileUpload { get; set; }
        private bool CanDeleteFileUpload { get; set; }


        private bool isInitialized { get; set; }
        private bool isDataSaved { get; set; }
        private bool isDataEntryChanged { get; set; }
        private bool editFormPopupVisible { get; set; } = false;
        private bool editFormBOMPopupVisible { get; set; } = false;
        private bool editFormBOSPopupVisible { get; set; } = false;
        private bool editFormTabMemberPopupVisible { get; set; } = false;


        private bool isCompanyType { get; set; }
        private bool isCompanyTypeReportKind { get; set; }
        private bool isCompanyTypeReport { get; set; }
        private bool isCompanyMajorBusiness { get; set; }
        private bool isCompanyMajorBusinessOther { get; set; }

        private bool isNew { get; set; } = false;
        private string PopupHeaderText => isNew ? "AddNew" : "Details";
        private string? fileName { get; set; }


        [Parameter]
        public string Id { get; set; } // Đầu vào kiểu string
        public int EditingCompanyId { get; set; }



        ///// <summary> 
        /////  Grid
        ///// </summary> 

        private EditContext _gridCompanyEditContext;
        private Guid EditingAdditionInfoId { get; set; } = Guid.Empty;
        private IGrid AdditionInfoGrid { get; set; }
        private IGrid LandInfomationGrid { get; set; }
        private IGrid InvestmentGrid { get; set; }
        private IGrid MajorGrid { get; set; }
        private IGrid FileUploadGrid { get; set; }

         
        private TbAdditionInfoUpdateDto EditingAdditionInfo { get; set; }
        private TbCompanyMajorUpdateDto EditingMajor { get; set; }
        private TbLandInfoUpdateDto EditingLandInfo { get; set; }
        private TbFileUploadUpdateDto EditingFileUpload { get; set; }
        private TbCompanyInvestUpdateDto EditingInvestment { get; set; }
        private TsClassUpdateDto EditingTsClass { get; set; } = new TsClassUpdateDto();
        private TbCompanyUpdateDto EditingCompanyType { get; set; } = new TbCompanyUpdateDto();
        private List<TbUserMappingPersonDto> TbUserMappingPersonList { get; set; } = new List<TbUserMappingPersonDto>();
        private TbCompanyMappingUpdateDto EditingCompanyTypeReportKind { get; set; } = new TbCompanyMappingUpdateDto();
        private TbCompanyMappingUpdateDto EditingCompanyTypeReport { get; set; } = new TbCompanyMappingUpdateDto();

        private TbCompanyBusinessUpdateDto EditingCompanyBusiness { get; set; } = new TbCompanyBusinessUpdateDto(); 
        private TbCompanyUpdateDto EditingCompany { get; set; } = new TbCompanyUpdateDto();
        private TbCompanyPersonUpdateDto EditingCompanyPerson { get; set; } = new TbCompanyPersonUpdateDto();
        private TbCompanyPersonUpdateDto EditingCompanyPersonBOM { get; set; } = new TbCompanyPersonUpdateDto();
        private TbCompanyPersonUpdateDto EditingCompanyPersonBOS { get; set; } = new TbCompanyPersonUpdateDto();
        private TbCompanyPersonUpdateDto EditingCompanyPersonMember { get; set; } = new TbCompanyPersonUpdateDto();


        private IReadOnlyList<object> selectedAdditionInfo { get; set; } = new List<TbAdditionInfoUpdateDto>();
        private IReadOnlyList<object> selectedFileUpload { get; set; } = new List<TbFileUploadUpdateDto>();
        private IReadOnlyList<object> selectedMajor { get; set; } = new List<TbCompanyMajorUpdateDto>();
        private IReadOnlyList<object> selectedLandInfo { get; set; } = new List<TbLandInfoUpdateDto>();
        private IReadOnlyList<object> selectedInvest { get; set; } = new List<TbCompanyInvestUpdateDto>();
        private IReadOnlyList<YesNoTypeList> YesNoLists { get; set; } = new List<YesNoTypeList>();
        private IReadOnlyList<TbInfoUpdateDto> TbInfoUpdateList { get; set; } = new List<TbInfoUpdateDto>();


        private List<TbUserDto> TbUserList = new List<TbUserDto>();
        private List<TbFileUploadTempDto> TbFileUploadTempList = new List<TbFileUploadTempDto>();
        private List<TbFileUploadTempUpdateDto> tempFiles = new List<TbFileUploadTempUpdateDto>();

        private List<TbCompanyDto> CompanyList { get; set; } = new List<TbCompanyDto>();
        private List<TbCompanyMappingDto> CompanyMappingList { get; set; } = new List<TbCompanyMappingDto>();
        private List<TbCompanyBusinessDto> PositionBusinessList = new List<TbCompanyBusinessDto> { };
        private List<TbAdditionInfoUpdateDto> AdditionInfoList = new List<TbAdditionInfoUpdateDto> { };

        private List<TbUserMappingCompanyDto> TbUserMappingCompaniesList { get; set; } = new List<TbUserMappingCompanyDto>();
        private List<TbAdditionInfoUpdateDto> SelectedAdditionInfo { get; set; } = new List<TbAdditionInfoUpdateDto>();

        private List<TbAdditionInfoTempUpdateDto> AdditionInfoTempList = new List<TbAdditionInfoTempUpdateDto> { };

        private List<TbLandInfoUpdateDto> LandInfoList = new List<TbLandInfoUpdateDto> { };

        private List<TbLandInfoTempUpdateDto> LandInfoTempList = new List<TbLandInfoTempUpdateDto> { };

        private List<TbCompanyInvestUpdateDto> CompanyInvestList = new List<TbCompanyInvestUpdateDto> { };

        private List<TbCompanyInvestTempUpdateDto> CompanyInvestTempList = new List<TbCompanyInvestTempUpdateDto> { };

        private List<TbCompanyMajorUpdateDto> CompanyMajorList = new List<TbCompanyMajorUpdateDto> { };

        private List<TbCompanyMajorTempUpdateDto> CompanyMajorTempList = new List<TbCompanyMajorTempUpdateDto> { };

        private List<TbFileUploadUpdateDto> FileUploadList = new List<TbFileUploadUpdateDto> { };

        private List<TbFileUploadTempUpdateDto> FileUploadTempList = new List<TbFileUploadTempUpdateDto> { };


        private List<TbPersonUpdateDto> PersonCollection = new List<TbPersonUpdateDto> { };
        private List<TbUserDto> UserList { get; set; } = new List<TbUserDto>();


        private List<TsClassDto> TsClassList = new List<TsClassDto> { };
        private List<TsClassDto> TypeOfGroupTsClassCollection = new List<TsClassDto> { };
        private List<TsClassDto> ShareholderCollection = new List<TsClassDto> { };
        private List<TsClassDto> StockCodeClassList = new List<TsClassDto> { };

        private List<TsClassDto> TypeClassList = new List<TsClassDto> { };
        private List<TsClassDto> ReportClassList = new List<TsClassDto> { };
        private List<TsClassDto> ReportKindClassList = new List<TsClassDto> { };


        private IEnumerable<IGrouping<Guid?, TbInfoUpdateDto>> GroupedChanges { get; set; }
        public int screenId { get; set; }
        public string screenName { get; set; } = "Companies";
        public bool isColumn1Visible { get; set; } = true;
        public bool isColumn2Visible { get; set; } = false;
        public bool isAmendmentValidation { get; set; } = false;
        public bool isParValueValidation { get; set; } = false;



        ///// <summary> 
        ///// BOD Master Grid
        ///// </summary>
        private IGrid CompanyPersonGrid { get; set; }
        private IReadOnlyList<object> selectedCompanyPerson { get; set; } = new List<TbCompanyPersonUpdateDto>();

        private List<TbCompanyPersonUpdateDto> CompanyPersonBODList = new List<TbCompanyPersonUpdateDto> { };

        private List<TbCompanyPersonTempUpdateDto> CompanyPersonTempList = new List<TbCompanyPersonTempUpdateDto> { };

        private List<TbPersonDto> PersonsList = new List<TbPersonDto> { };

        private List<TbPositionDto> PositionBODList = new List<TbPositionDto> { };
        private List<TbPositionDto> PositionBOMList = new List<TbPositionDto> { };
        private List<TbPositionDto> PositionBOSList = new List<TbPositionDto> { };
        private List<TbPositionDto> PositionMemberList = new List<TbPositionDto> { };

        private bool CanCreateCompanyPerson { get; set; }
        private bool CanEditCompanyPerson { get; set; }
        private bool CanDeleteCompanyPerson { get; set; }




        ///// <summary> 
        ///// BOM Master Grid
        ///// </summary>
        private IGrid CompanyPersonBOMGrid { get; set; }

        private List<TbCompanyPersonUpdateDto> CompanyPersonBOMList = new List<TbCompanyPersonUpdateDto> { };
        private bool CanCreateCompanyPersonBOM { get; set; }
        private bool CanEditCompanyPersonBOM { get; set; }
        private bool CanDeleteCompanyPersonBOM { get; set; }


        ///// <summary> 
        ///// BOS Master Grid
        ///// </summary>
        private IGrid CompanyPersonBOSGrid { get; set; }

        private List<TbCompanyPersonUpdateDto> CompanyPersonBOSList = new List<TbCompanyPersonUpdateDto> { };
        private bool CanCreateCompanyPersonBOS { get; set; }
        private bool CanEditCompanyPersonBOS { get; set; }
        private bool CanDeleteCompanyPersonBOS { get; set; }



        ///// <summary> 
        ///// TAB MEMBER Master Grid
        ///// </summary>

        private IGrid CompanyPersonTabMemberGrid { get; set; }

        private List<TbCompanyPersonUpdateDto> CompanyPersonMemberList = new List<TbCompanyPersonUpdateDto> { };
        private bool CanCreateCompanyPersonTabMember { get; set; }
        private bool CanEditCompanyPersonTabMember { get; set; }
        private bool CanDeleteCompanyPersonTabMember { get; set; }




        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                              Initial Section
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        #region
        public Companies()
        {
        }
        protected override async Task OnInitializedAsync()
        {
            EditingCompanyId = int.Parse(Id);
            await SetPermissionsAsync();
            await SetToolbarItemsAsync();
            await SetBreadcrumbItemsAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await _blockUiService.Block(selectors: "#lpx-content-container", busy: false);

                await LoadGridData();

                if (EditingCompany.StockCode != null)
                {
                    await LoadStock(EditingCompany.StockCode.Trim());
                }
                await JSRuntime.InvokeVoidAsync("eval", "document.getElementById('financial-data').innerHTML = '';");

                await _blockUiService.UnBlock();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        #endregion




        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                      ToolBar - Breadcrumb - Permission   
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        protected virtual ValueTask SetBreadcrumbItemsAsync()
        {
            BreadcrumbItems.AddRange(new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>
            {
                new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:Companies"],"/companies"),
                new Volo.Abp.BlazoriseUI.BreadcrumbItem(EditingCompany.Code)
            });
            return ValueTask.CompletedTask;
        }

        protected virtual ValueTask SetToolbarItemsAsync()
        {
            Toolbar.AddButton(L["Back"], async () =>
            {
                NavigationManager.NavigateTo($"/companies");
                await Task.CompletedTask;
            },
             IconName.Undo,
            Blazorise.Color.Default);

            Toolbar.AddButton(L[""], async () => await GetHistoryAsync(),
            icon: "fa fa-history",
            Color.Default);

            Toolbar.AddButton(L["Save"], async () =>
            {
                await SaveDataAsync();
            },
            IconName.Save,
            Color.Primary,
            requiredPolicyName: Sabeco_FactsheetPermissions.TbCompanies.Edit);


            return ValueTask.CompletedTask;
        }

        private async Task SetPermissionsAsync()
        {
            CanCreateFileUpload = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbFileUploads.Create);
            CanEditFileUpload = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbFileUploads.Edit);
            CanDeleteFileUpload = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbFileUploads.Delete);

            CanCreateAdditionInfo = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbAdditionInfos.Create);
            CanEditAdditionInfo = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbAdditionInfos.Edit);
            CanDeleteAdditionInfo = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbAdditionInfos.Delete);

            CanCreateLandInfomation = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbLandInfos.Create);
            CanEditLandInfomation = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbLandInfos.Edit);
            CanDeleteLandInfomation = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbLandInfos.Delete);

            CanCreateInvestment = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbCompanyInvests.Create);
            CanEditInvestment = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbCompanyInvests.Edit);
            CanDeleteInvestment = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbCompanyInvests.Delete);

            CanCreateMajor = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbCompanyMajors.Create);
            CanEditMajor = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbCompanyMajors.Edit);
            CanDeleteMajor = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbCompanyMajors.Delete);

            CanCreateCompanyPerson = await AuthorizationService
          .IsGrantedAsync(Sabeco_FactsheetPermissions.TbAdditionInfos.Create);
            CanEditCompanyPerson = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbAdditionInfos.Edit);
            CanDeleteCompanyPerson = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbAdditionInfos.Delete);

            CanCreateCompanyPersonBOM = await AuthorizationService
          .IsGrantedAsync(Sabeco_FactsheetPermissions.TbAdditionInfos.Create);
            CanEditCompanyPersonBOM = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbAdditionInfos.Edit);
            CanDeleteCompanyPersonBOM = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbAdditionInfos.Delete);

            CanCreateCompanyPersonBOS = await AuthorizationService
        .IsGrantedAsync(Sabeco_FactsheetPermissions.TbAdditionInfos.Create);
            CanEditCompanyPersonBOS = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbAdditionInfos.Edit);
            CanDeleteCompanyPersonBOS = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbAdditionInfos.Delete);


            CanCreateCompanyPersonTabMember = await AuthorizationService
        .IsGrantedAsync(Sabeco_FactsheetPermissions.TbAdditionInfos.Create);
            CanEditCompanyPersonTabMember = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbAdditionInfos.Edit);
            CanDeleteCompanyPersonTabMember = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbAdditionInfos.Delete);
        }


        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                          Load Data List & Others  
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        private async Task LoadGridData()
        {
            await GetUserListAsync();
            await GetTsClassList();
            await GetShareholderType();
            await GetPersonCollection();
            await GetTypeOfGroupTsClassCollection();
            await GetTbMajorAsync(EditingCompanyId);
            await GetTbInvestAsync(EditingCompanyId);
            await GetLandInfoAsync(EditingCompanyId);
            await GetFileUploadListAsync(EditingCompanyId);
            await GetTbAdditionInfoAsync(EditingCompanyId);

            await GetPersonAsync();
            await GetListCompanyTypeAsync();
            await GetListPositionBODChanged();
            await GetListPositionBOMChanged();
            await GetListPositionBOSChanged();
            await GetListPositionMemberChanged();
            await GetListPositionBusinessAsync();

            await GetCompanyPersonBODAsync();
            await GetCompanyPersonBOMAsync();
            await GetCompanyPersonBOSAsync();
            await GetCompanyPersonMemberAsync();

            await GetListCompanyTypeReportAsync();
            await GetYesNoLookupAsync();
            await GetListStockCodeAsyc();
            await GetListCompanyTypeReportKindAsync();
            await GetListCompanyMappingAsync(EditingCompanyId);
            await LoadDataAsync(EditingCompanyId);

            // Nếu có mã Stock Code của công ty thì gọi để load thông tin lên
            if (EditingCompany.StockCode != null)
            {
                // Đánh dấu là đã khởi tạo
                isInitialized = true;

                await LoadStock(EditingCompany.StockCode.Trim());
            }
        }

        private async Task LoadDataAsync(int classId)
        {
            await _pageProgressService.Go(null, options =>
            {
                options.Type = UiPageProgressType.Info;
            });

            if (classId != 0)
            {
                EditingCompany = ObjectMapper.Map<TbCompanyDto, TbCompanyUpdateDto>(await TbCompaniesAppService.GetAsync(classId));
                isDataEntryChanged = false;
                await GetCompanyAsync();

                // Kiểm tra và gán giá trị cho idCompanyType nếu khác null
                if (EditingCompany?.idCompanyType != null)
                {
                    EditingCompanyType.idCompanyType = EditingCompany.idCompanyType;
                }

                // Kiểm tra EditingCompanyId và CompanyMappingList
                if (EditingCompanyId != 0 && CompanyMappingList.Any())
                {
                    var firstMapping = CompanyMappingList.FirstOrDefault(); 
                    if (firstMapping != null)
                    {
                        EditingCompanyTypeReportKind.idCompanyTypesCode = firstMapping.idCompanyTypesCode;
                        EditingCompanyTypeReport.idCompanyTypeShareholdingCode = firstMapping.idCompanyTypeShareholdingCode;
                    }
                }
            }
            else
            {
                EditingCompany = new TbCompanyUpdateDto();
                EditingCompany.StockRegistrationDate = DateTime.Now;
                EditingCompany.Note = YesNoType.Yes.ToString();
            }

            await GetListPositionBusinessAsync();
            await InvokeAsync(StateHasChanged);
            await _pageProgressService.Go(-1);
        }

        private async Task GetListCompanyMappingAsync(int classId)
        {
            CompanyMappingList = await TbCompanyMappingsAppService.GetListByCompanyId(classId);
        }

        private async Task GetTbUserMappingCompaniesListAsync()
        {
            var currentUser = TbUserList.FirstOrDefault(x => x.UserName == CurrentUser.UserName);

            if (currentUser != null)
            {
                var result = await TbUserMappingCompaniesAppService.GetListNoPagedAsync(new GetTbUserMappingCompaniesInput { });
                TbUserMappingCompaniesList = result.Where(x => x.userid == currentUser.Id && x.IsActive == true).ToList();
            }
        }

        private async Task GetCompanyAsync()
        {
            await GetTbUserMappingCompaniesListAsync();

            // Lấy tất cả dữ liệu mà không phân trang để tính TotalCount
            var allCompaniesResult = await TbCompaniesAppService.GetListNoPagedAsync(new GetTbCompaniesInput { });

            // Lọc danh sách dựa trên quyền truy cập của người dùng
            CompanyList = allCompaniesResult
                .Where(x => TbUserMappingCompaniesList.Any(mapping => mapping.companyid == x.Id) && x.Id != EditingCompanyId)
                .ToList();
        }

        private async Task GetTbUserMappingPersonListAsync()
        {
            var user = TbUserList.FirstOrDefault(x => x.UserName == CurrentUser.UserName);

            if (user != null)
            {
                var result = await TbUserMappingPersonsAppService.GetListNoPagedAsync(new GetTbUserMappingPersonsInput { });
                TbUserMappingPersonList = result.Where(x => x.userid == user.Id && x.IsActive == true).ToList();
            }
        }

        private async Task GetPersonAsync()
        {
            await GetTbUserMappingPersonListAsync();

            // Lấy tất cả dữ liệu mà không phân trang để tính TotalCount
            var allPersonsResult = await TbPersonsAppService.GetListNoPagedAsync(new GetTbPersonsInput { });

            // Lọc danh sách dựa trên quyền truy cập của người dùng
            PersonsList = allPersonsResult
                .Where(x => TbUserMappingPersonList.Any(mapping => mapping.personid == x.Id))
                .ToList();
        }

        private async Task GetUserListAsync()
        {
            TbUserList = await TbUsersAppService.GetListNoPagedAsync(new GetTbUsersInput());
        }

        private async Task CompanyParentChanged(int item)
        {
            isDataEntryChanged = true;
            var value = CompanyList.FirstOrDefault(x => x.Id == item);
            EditingCompany.ParentId = item;
            isCompanyType = true;
            await Task.CompletedTask;
        }

        private async Task CompanyTypeReportKindChanged(int? item)
        {
            isDataEntryChanged = true;
            var value = ReportKindClassList.FirstOrDefault(x => x.Id == item);
            EditingCompanyTypeReportKind.idCompanyTypesCode = item;
            EditingCompanyTypeReportKind.CompanyTypesCode = value?.Code;
            isCompanyTypeReportKind = true;
            await Task.CompletedTask;
        }

        private async Task CompanyTypeReportChanged(int? item)
        {
            isDataEntryChanged = true;
            var value = ReportClassList.FirstOrDefault(x => x.Id == item);
            EditingCompanyTypeReport.idCompanyTypeShareholdingCode = item;
            EditingCompanyTypeReport.CompanyTypeShareholdingCode = value?.Code;
            isCompanyTypeReport = true;
            await Task.CompletedTask;
        }

        private async Task StockExchangeChanged(string item)
        {
            isDataEntryChanged = true;
            var value = StockCodeClassList.FirstOrDefault(x => x.Code == item);
            EditingCompany.StockExchange = item;
            await Task.CompletedTask;
        }

        private async Task CompanyTypeChanged(int? item)
        {
            isDataEntryChanged = true;
            var value = TypeClassList.FirstOrDefault(x => x.Id == item);
            EditingCompanyType.idCompanyType = item;
            EditingCompanyType.CompanyType = value?.Code;
            isCompanyType = true;
            await Task.CompletedTask;
        }
        

        private async Task TypeOfGroupChanged(string item)
        {
            isDataEntryChanged = true; 
            EditingAdditionInfo.TypeOfGroup = item;
            await Task.CompletedTask;
        }

        private async Task GetListPositionBusinessAsync()
        {
            var result = await TbCompanyBusinessesAppService.GetListNoPagedAsync(new GetTbCompanyBusinessesInput { });
            PositionBusinessList = result.Where(x => x.CompanyId == EditingCompanyId).OrderByDescending(x => x.crt_date).ToList(); // Sắp xếp theo ngày giảm dần 

            EditingCompanyBusiness.MajorBusiness = PositionBusinessList.FirstOrDefault()?.MajorBusiness;
            EditingCompanyBusiness.OtherActivity = PositionBusinessList.FirstOrDefault()?.OtherActivity;
        }

        private async Task GetTbAdditionInfoAsync(int classId)
        {
            var input = new GetTbAdditionInfosInput
            {
                MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount,
                CompanyIdMin = classId,
                CompanyIdMax = classId
            };
            var result = await TbAdditionInfosAppService.GetListAsync(input);
            AdditionInfoList = ObjectMapper.Map<List<TbAdditionInfoDto>, List<TbAdditionInfoUpdateDto>>(result.Items.ToList());
        }

        private async Task GetTsClassList()
        {
            TsClassList = await TsClassesAppService.GetListNoPagedAsync(new GetTsClassesInput { });
        }

        private async Task GetShareholderType()
        {
            var result = await TsClassesAppService.GetListNoPagedAsync(new GetTsClassesInput { });
            ShareholderCollection = result.Where(x => x.ParentCode == "COMPANY_TYPE").ToList();
        }
        
        private async Task GetTypeOfGroupTsClassCollection()
        {
            var result = await TsClassesAppService.GetListNoPagedAsync(new GetTsClassesInput { });
            TypeOfGroupTsClassCollection = result.Where(x => x.ParentCode == "AdditionGroup").ToList();
        }

        private async Task GetPersonCollection()
        {
            var result = await TbPersonsAppService.GetListNoPagedAsync(new GetTbPersonsInput { });
            PersonCollection = ObjectMapper.Map<List<TbPersonDto>, List<TbPersonUpdateDto>>(result.ToList());
        }

        private async Task GetTbMajorAsync(int classId)
        {
            var input = new GetTbCompanyMajorsInput
            {
                MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount,
                CompanyIdMin = classId,
                CompanyIdMax = classId
            };

            var result = await TbCompanyMajorsAppService.GetListAsync(input);
            CompanyMajorList = ObjectMapper.Map<List<TbCompanyMajorDto>, List<TbCompanyMajorUpdateDto>>(result.Items.ToList());
        }

        private async Task GetTbInvestAsync(int classId)
        {
            var input = new GetTbCompanyInvestsInput
            {
                MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount,
                CompanyIdMin = classId,
                CompanyIdMax = classId
            };
            var result = await TbCompanyInvestsAppService.GetListAsync(input);
            CompanyInvestList = ObjectMapper.Map<List<TbCompanyInvestDto>, List<TbCompanyInvestUpdateDto>>(result.Items.ToList());
        }

        private async Task GetLandInfoAsync(int classId)
        {
            var input = new GetTbLandInfosInput
            {
                MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount,
                CompanyIdMin = classId,
                CompanyIdMax = classId,
            };
            var result = await TbLandInfosAppService.GetListAsync(input);
            LandInfoList = ObjectMapper.Map<List<TbLandInfoDto>, List<TbLandInfoUpdateDto>>(result.Items.ToList());
        }

        private async Task GetFileUploadListAsync(int classId)
        {
            var input = new GetTbFileUploadsInput
            {
                MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount,
                companyIdMin = classId,
                companyIdMax = classId,
            };
            var result = await TbFileUploadsAppService.GetListAsync(input);
            FileUploadList = ObjectMapper.Map<List<TbFileUploadDto>, List<TbFileUploadUpdateDto>>(result.Items.ToList());
        }

        private async Task GetTbAdditionInfoAsync()
        {
            var result = await TbAdditionInfosAppService.GetListNoPagedAsync(new GetTbAdditionInfosInput { });
            AdditionInfoList = ObjectMapper.Map<List<TbAdditionInfoDto>, List<TbAdditionInfoUpdateDto>>((List<TbAdditionInfoDto>)result);
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

        private async Task GetListStockCodeAsyc()
        {
            var parentCode = "STOCK_EXCHANGE";
            StockCodeClassList = await TsClassesAppService.GetListByParentCode(parentCode);
        }

        private async Task GetListPositionBOMChanged()
        {
            var result = await TbPositionsAppService.GetListNoPagedAsync(new GetTbPositionsInput { });
            PositionBOMList = result.Where(x => x.PositionType == 2).ToList();
        }

        private async Task GetListPositionBOSChanged()
        {
            var result = await TbPositionsAppService.GetListNoPagedAsync(new GetTbPositionsInput { });
            PositionBOSList = result.Where(x => x.PositionType == 3).ToList();
        }

        private async Task GetListPositionMemberChanged()
        {
            var result = await TbPositionsAppService.GetListNoPagedAsync(new GetTbPositionsInput { });
            PositionMemberList = result.Where(x => x.PositionType == 4).ToList();
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
                if (!isDataEntryChanged)
                {
                    return;
                }

                if (EditingCompanyId == 0)
                {
                    return;
                }

                var originalItem = await TbCompaniesAppService.GetAsync(EditingCompanyId);
                var originalDto = ObjectMapper.Map<TbCompanyDto, TbCompanyUpdateDto>(originalItem);

                await _blockUiService.Block(selectors: "#lpx-content-container", busy: false);

                await ProcessCompanyTypeChange(originalDto);
                await ProcessCompanyTypeReportKindChange();
                await ProcessCompanyTypeReportChange();
                await ProcessCompanyMajorBusinessChange();

                if (!FileHelper.ArePropertiesEqual(EditingCompany, originalDto))
                {
                    await SaveEntityChanges(
                        EditingCompanyId,
                        "UPDATE",
                        originalDto,
                        EditingCompany,
                        "tbCompany",
                        "Company"
                    );

                    isDataSaved = true;
                    await GetTbInfoUpdateListAsync();
                    isDataEntryChanged = false;
                }

                if (isDataSaved == true)
                {
                    await _uiNotificationService.Success(L["Notification:Edit"]);
                    await LoadDataAsync(EditingCompanyId);
                    isDataSaved = false;
                }

                await _blockUiService.UnBlock();
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
            finally
            {
                isSaving = false; // Đặt cờ về false khi hoàn tất
            }
        }


        private async Task ProcessCompanyTypeChange(TbCompanyUpdateDto originalDto)
        {
            if (!isCompanyType) return;

            if (EditingCompanyType.CompanyType != originalDto.CompanyType ||
                EditingCompanyType.idCompanyType != originalDto.idCompanyType)
            {
                var oldValue = new TbCompanyUpdateDto
                {
                    CompanyType = originalDto.CompanyType,
                    idCompanyType = originalDto.idCompanyType
                };

                var newValue = new TbCompanyUpdateDto
                {
                    CompanyType = EditingCompanyType.CompanyType,
                    idCompanyType = EditingCompanyType.idCompanyType
                };

                if (!FileHelper.ArePropertiesEqual(newValue, originalDto))
                {
                    await SaveEntityChanges(
                        EditingCompanyId,
                        "UPDATE",
                        oldValue,
                        newValue,
                        "tbCompany",
                        "CompanyType"
                    );

                    isCompanyType = false;
                    isDataSaved = true;
                }
            }
        }

        private async Task ProcessCompanyTypeReportKindChange()
        {
            if (!isCompanyTypeReportKind) return;

            var originalItem = await TbCompanyMappingsAppService.GetAsync(EditingCompanyId);
            var originalDto = ObjectMapper.Map<TbCompanyMappingDto, TbCompanyMappingUpdateDto>(originalItem);

            var oldValue = new TbCompanyMappingUpdateDto
            {
                CompanyTypesCode = originalDto.CompanyTypesCode,
                idCompanyTypesCode = originalDto.idCompanyTypesCode
            };

            if (EditingCompanyTypeReportKind.CompanyTypesCode != originalDto.CompanyTypesCode ||
                EditingCompanyTypeReportKind.idCompanyTypesCode != originalDto.idCompanyTypesCode)
            {
                var newValue = new TbCompanyMappingUpdateDto
                {
                    CompanyTypesCode = EditingCompanyTypeReportKind.CompanyTypesCode,
                    idCompanyTypesCode = EditingCompanyTypeReportKind.idCompanyTypesCode
                };

                if (!FileHelper.ArePropertiesEqual(newValue, originalDto))
                {
                    await SaveEntityChanges(
                        EditingCompanyId,
                        "UPDATE",
                        oldValue,
                        newValue,
                        "tbCompanyMapping",
                        "CompanyType"
                    );
                    isDataSaved = true;
                }
            }
        }

        private async Task ProcessCompanyTypeReportChange()
        {
            if (!isCompanyTypeReport) return;

            var originalItem = await TbCompanyMappingsAppService.GetAsync(EditingCompanyId);
            var originalDto = ObjectMapper.Map<TbCompanyMappingDto, TbCompanyMappingUpdateDto>(originalItem);

            var oldValue = new TbCompanyMappingUpdateDto
            {
                CompanyTypeShareholdingCode = originalDto.CompanyTypeShareholdingCode,
                idCompanyTypeShareholdingCode = originalDto.idCompanyTypeShareholdingCode
            };

            if (EditingCompanyTypeReport.CompanyTypeShareholdingCode != originalDto.CompanyTypeShareholdingCode ||
                EditingCompanyTypeReport.idCompanyTypeShareholdingCode != originalDto.idCompanyTypeShareholdingCode)
            {
                var newValue = new TbCompanyMappingUpdateDto
                {
                    CompanyTypeShareholdingCode = EditingCompanyTypeReport.CompanyTypeShareholdingCode,
                    idCompanyTypeShareholdingCode = EditingCompanyTypeReport.idCompanyTypeShareholdingCode
                };

                if (!FileHelper.ArePropertiesEqual(newValue, originalDto))
                {
                    await SaveEntityChanges(
                        EditingCompanyId,
                        "UPDATE",
                        oldValue,
                        newValue,
                        "tbCompanyMapping",
                        "CompanyType"
                    );
                    isDataSaved = true;
                }
            }
        }

        private async Task ProcessCompanyMajorBusinessChange()
        {
            if (!isCompanyMajorBusiness) return;

            var originalItems = await TbCompanyBusinessesAppService.GetListNoPagedAsync(new GetTbCompanyBusinessesInput());
            var originalItem = originalItems.FirstOrDefault(x => x.CompanyId == EditingCompanyId);

            if (originalItem == null) return;

            var originalDto = ObjectMapper.Map<TbCompanyBusinessDto, TbCompanyBusinessUpdateDto>(originalItem);

            var oldValue = new TbCompanyBusinessUpdateDto
            {
                MajorBusiness = originalDto.MajorBusiness,
                OtherActivity = originalDto.OtherActivity
            };

            var newData = new TbCompanyBusinessUpdateDto
            {
                MajorBusiness = EditingCompanyBusiness.MajorBusiness,
                OtherActivity = EditingCompanyBusiness.OtherActivity
            };

            if (!FileHelper.ArePropertiesEqual(newData, originalDto))
            {
                await SaveEntityChanges(
                    EditingCompanyId,
                    "UPDATE",
                    oldValue,
                    newData,
                    "tbCompanyBusiness",
                    "BussinessRegistration"
                );
                isDataSaved = true;
            }
        }






        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                              DATA GRID
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        #region MajorGrid
        private async Task MajorGrid_Click()
        {
            isNew = true;
            await MajorGrid.SaveChangesAsync();
            MajorGrid.ClearSelection();
            await MajorGrid.StartEditNewRowAsync();
        }

        private void MajorGrid_EditModelSaving(GridEditModelSavingEventArgs e)
        {
            TbCompanyMajorUpdateDto editModel = (TbCompanyMajorUpdateDto)e.EditModel;

            if (editModel != null)
            {
                if (!e.IsNew)
                {
                    editModel.IsChanged = true;
                    isDataEntryChanged = true;
                    int index = CompanyMajorList.FindIndex(item => item.Id == editModel.Id);
                    if (index != -1)
                    {
                        CompanyMajorList[index] = editModel;
                    }
                }
                if (e.IsNew)
                {
                    editModel.Idx = CompanyMajorList.Count > 0
                            ? CompanyMajorList.Max(x => x.Idx) + 1
                            : 1;
                    editModel.IsChanged = true;
                    isDataEntryChanged = true;
                    CompanyMajorList.Add(editModel);
                }
            }
        }

        private void MajorGrid_OnCustomizeEditModel(GridCustomizeEditModelEventArgs e)
        {
            if (e.IsNew)
            {
                var newRow = (TbCompanyMajorUpdateDto)e.EditModel;
                newRow.Idx = CompanyMajorList.Count > 0
                    ? CompanyMajorList.Max(x => x.Idx) + 1
                    : 1;

                newRow.CompanyId = EditingCompanyId;
                newRow.IsChanged = true;
            }
        }

        private async Task SaveMajorAsync()
        {
            // Kiểm tra nếu dữ liệu không thay đổi thì không thực hiện gì
            if (!isDataEntryChanged)
                return;

            await MajorGrid.SaveChangesAsync();
            // Xóa danh sách tạm để chuẩn bị cho dữ liệu mới
            CompanyMajorTempList.Clear();

            // Lọc các mục đã thay đổi
            var itemsToSave = CompanyMajorList.Where(x => x.IsChanged).ToList();

            // Nếu không có mục nào để lưu thì thoát
            if (!itemsToSave.Any())
                return;

            // Duyệt qua từng mục đã thay đổi
            foreach (var item in itemsToSave)
            {
                // Tạo đối tượng DTO cập nhật cho danh sách tạm
                var updateDto = new TbCompanyMajorTempUpdateDto
                {
                    ShareHolderMajor = item.ShareHolderMajor,
                    FromDate = item.FromDate,
                    ToDate = item.ToDate,
                    ShareHolderType = item.ShareHolderType,
                    ShareHolderValue = item.ShareHolderValue,
                    ShareHolderRate = item.ShareHolderRate,
                    Note = item.Note,
                };

                // Thêm vào danh sách tạm để xử lý sau
                CompanyMajorTempList.Add(updateDto);

                // Kiểm tra nếu Id của mục là 0, nghĩa là đây là bản ghi mới
                if (item.Id == 0)
                {
                    // Xử lý thao tác INSERT
                    var createDto = ObjectMapper.Map<TbCompanyMajorTempUpdateDto, TbCompanyMajorTempCreateDto>(updateDto);
                    createDto.crt_date = DateTime.Now;
                    createDto.crt_user = item.crt_user;
                    var major = await TbCompanyMajorTempsAppService.CreateAsync(createDto);
                    updateDto.Id = major.Id;

                    // Ghi log thay đổi cho thao tác INSERT
                    await SaveEntityChanges(
                        updateDto.Id,
                        "INSERT",
                        null,
                        updateDto,
                        "tbCompanyMajor_Temp",
                        "MajorShareholder"
                    );

                    await _uiNotificationService.Success(L["Notification:Save"]);
                }
                else
                {
                    // Xử lý thao tác UPDATE
                    var originalItem = await TbCompanyMajorsAppService.GetAsync(item.Id);
                    var originalDto = ObjectMapper.Map<TbCompanyMajorDto, TbCompanyMajorUpdateDto>(originalItem);

                    if (!FileHelper.ArePropertiesEqual(item, originalDto))
                    {
                        // Ghi log thay đổi cho thao tác UPDATE
                        await SaveEntityChanges(
                            item.Id,
                            "UPDATE",
                            originalDto,
                            item,
                            "tbCompanyMajor",
                            "MajorShareholder"
                        );
                        await _uiNotificationService.Success(L["Notification:Edit"]);
                    }
                }

                // Đánh dấu mục đã xử lý xong
                item.IsChanged = false;
            }

            // Đặt lại cờ cho biết dữ liệu đã thay đổi
            isDataEntryChanged = false;
            await GetTbMajorAsync(EditingCompanyId);
        }

        #endregion MajorGrid


        #region LandInfoGrid
        private async Task LandInfomationGridNew_Click()
        {
            isNew = true;
            await LandInfomationGrid.SaveChangesAsync();
            LandInfomationGrid.ClearSelection();
            await LandInfomationGrid.StartEditNewRowAsync();
        }

        private void LandInfomationGrid_EditModelSaving(GridEditModelSavingEventArgs e)
        {
            TbLandInfoUpdateDto editModel = (TbLandInfoUpdateDto)e.EditModel;
            if (editModel != null)
            {
                if (!e.IsNew)
                {
                    editModel.IsChanged = true;
                    isDataEntryChanged = true;
                    int index = LandInfoList.FindIndex(item => item.Id == editModel.Id);
                    if (index != -1)
                    {
                        LandInfoList[index] = editModel;
                    }
                }
                if (e.IsNew)
                {
                    editModel.Idx = LandInfoList.Count > 0
                            ? LandInfoList.Max(x => x.Idx) + 1
                            : 1;
                    editModel.IsChanged = true;
                    isDataEntryChanged = true;
                    LandInfoList.Add(editModel);
                }
            }
        }

        private void LandInfomationGrid_OnCustomizeEditModel(GridCustomizeEditModelEventArgs e)
        {
            if (e.IsNew)
            {

                var newRow = (TbLandInfoUpdateDto)e.EditModel;
                newRow.Idx = LandInfoList.Count > 0
                    ? CompanyMajorList.Max(x => x.Idx) + 1
                    : 1;


                newRow.CompanyId = EditingCompanyId;
                newRow.IsChanged = true;
            }
        }
        private async Task SaveLandInfoAsync()
        {
            // Kiểm tra nếu dữ liệu không thay đổi thì không thực hiện gì
            if (!isDataEntryChanged)
                return;

            await LandInfomationGrid.SaveChangesAsync();
            // Xóa danh sách tạm để chuẩn bị cho dữ liệu mới
            LandInfoTempList.Clear();

            // Lọc các mục đã thay đổi
            var itemsToSave = LandInfoList.Where(x => x.IsChanged).ToList();

            // Nếu không có mục nào để lưu thì thoát
            if (!itemsToSave.Any())
                return;

            // Duyệt qua từng mục đã thay đổi
            foreach (var item in itemsToSave)
            {
                // Tạo đối tượng DTO cập nhật cho danh sách tạm
                var updateDto = new TbLandInfoTempUpdateDto
                {
                    Description = item.Description,
                    Address = item.Address,
                    TypeOfLand = item.TypeOfLand,
                    Area = item.Area,
                    SupportingDocument = item.SupportingDocument
                };

                // Thêm vào danh sách tạm để xử lý sau
                LandInfoTempList.Add(updateDto);

                // Kiểm tra nếu Id của mục là 0, nghĩa là đây là bản ghi mới
                if (item.Id == 0)
                {
                    // Xử lý thao tác INSERT
                    var createDto = ObjectMapper.Map<TbLandInfoTempUpdateDto, TbLandInfoTempCreateDto>(updateDto);
                    createDto.create_date = DateTime.Now;
                    createDto.create_user = item.create_user;
                    var major = await TbLandInfoTempsAppService.CreateAsync(createDto);
                    updateDto.Id = major.Id;

                    // Ghi log thay đổi cho thao tác INSERT
                    await SaveEntityChanges(
                        updateDto.Id,
                        "INSERT",
                        null,
                        updateDto,
                        "tbLandInfo_Temp",
                      "LandInformation"
                    );
                    await _uiNotificationService.Success(L["Notification:Save"]);
                }
                else
                {
                    var originalItem = await TbLandInfosAppService.GetAsync(item.Id);
                    var originalDto = ObjectMapper.Map<TbLandInfoDto, TbLandInfoUpdateDto>(originalItem);

                    if (!FileHelper.ArePropertiesEqual(item, originalDto))
                    {
                        // Ghi log thay đổi cho thao tác UPDATE
                        await SaveEntityChanges(
                            item.Id,
                            "UPDATE",
                            originalDto,
                            item,
                            "tbLandInfo",
                          "LandInformation"
                        );
                        await _uiNotificationService.Success(L["Notification:Edit"]);
                    }
                }

                // Đánh dấu mục đã xử lý xong
                item.IsChanged = false;
            }

            // Đặt lại cờ cho biết dữ liệu đã thay đổi
            isDataEntryChanged = false;
            await GetLandInfoAsync(EditingCompanyId);
        }
        #endregion LandInfoGrid


        #region InvestmentGrid

        private async Task InvestmentGrid_Click()
        {
            isNew = true;
            await InvestmentGrid.SaveChangesAsync();
            InvestmentGrid.ClearSelection();
            await InvestmentGrid.StartEditNewRowAsync();
        }

        private void InvestmentGrid_EditModelSaving(GridEditModelSavingEventArgs e)
        {
            TbCompanyInvestUpdateDto editModel = (TbCompanyInvestUpdateDto)e.EditModel;
            if (editModel != null)
            {
                if (!e.IsNew)
                {
                    editModel.IsChanged = true;
                    isDataEntryChanged = true;
                    int index = CompanyInvestList.FindIndex(item => item.Id == editModel.Id);
                    if (index != -1)
                    {
                        CompanyInvestList[index] = editModel;
                    }
                }
                if (e.IsNew)
                {
                    editModel.IsChanged = true;
                    isDataEntryChanged = true;
                    editModel.Idx = CompanyInvestList.Count > 0
                            ? CompanyInvestList.Max(x => x.Idx) + 1
                            : 1;

                    CompanyInvestList.Add(editModel);
                }
            }
        }

        private void InvestmentGrid_OnCustomizeEditModel(GridCustomizeEditModelEventArgs e)
        {
            if (e.IsNew)
            {
                var newRow = (TbCompanyInvestUpdateDto)e.EditModel;
                newRow.Idx = CompanyInvestList.Count > 0
                    ? CompanyInvestList.Max(x => x.Idx) + 1
                    : 1;

                newRow.CompanyId = EditingCompanyId;
                newRow.IsChanged = true;
            }
        }

        private async Task SaveInvestAsync()
        {
            if (!isDataEntryChanged)
                return;

            await InvestmentGrid.SaveChangesAsync();
            CompanyInvestTempList.Clear();
            var itemsToSave = CompanyInvestList.Where(x => x.IsChanged).ToList();

            if (!itemsToSave.Any())
                return;

            foreach (var item in itemsToSave)
            {
                var updateDto = new TbCompanyInvestTempUpdateDto
                {
                    CompanyName = item.CompanyName,
                    Shares = item.Shares,
                    Holding = item.Holding
                };
                CompanyInvestTempList.Add(updateDto);

                if (item.Id == 0)
                {
                    // Xử lý thao tác INSERT
                    var createDto = ObjectMapper.Map<TbCompanyInvestTempUpdateDto, TbCompanyInvestTempCreateDto>(updateDto);
                    var landInfo = await TbCompanyInvestTempsAppService.CreateAsync(createDto);
                    updateDto.Id = landInfo.Id;

                    await SaveEntityChanges(
                        updateDto.Id,
                        "INSERT",
                        null,
                        updateDto,
                        "tbCompanyInvest_Temp",
                        "Investment"
                    );
                    await _uiNotificationService.Success(L["Notification:Save"]);
                }
                else
                {
                    // Xử lý thao tác UPDATE
                    var originalItem = await TbCompanyInvestsAppService.GetAsync(item.Id);
                    var originalDto = ObjectMapper.Map<TbCompanyInvestDto, TbCompanyInvestUpdateDto>(originalItem);

                    if (!FileHelper.ArePropertiesEqual(item, originalDto))
                    {
                        await SaveEntityChanges(
                            item.Id,
                            "UPDATE",
                            originalDto,
                            item,
                            "tbCompanyInvest",
                            "Investment"
                        );
                        await _uiNotificationService.Success(L["Notification:Edit"]);
                    }
                }
                item.IsChanged = false;
            }

            isDataEntryChanged = false;
            await GetTbInvestAsync(EditingCompanyId);
            await InvokeAsync(StateHasChanged);
        }

        #endregion InvestmentGrid


        #region itionInfo

        private async Task AdditionInfoGridNew_Click()
        {
            isNew = true;
            await AdditionInfoGrid.SaveChangesAsync();
            AdditionInfoGrid.ClearSelection();
            await AdditionInfoGrid.StartEditNewRowAsync();
        }

        private void AdditionInfoGrid_EditModelSaving(GridEditModelSavingEventArgs e)
        {
            TbAdditionInfoUpdateDto editModel = (TbAdditionInfoUpdateDto)e.EditModel;
            if (editModel != null)
            {
                if (!e.IsNew)
                {
                    editModel.IsChanged = true;
                    isDataEntryChanged = true;
                    int index = AdditionInfoList.FindIndex(item => item.Id == editModel.Id);
                    if (index != -1)
                    {
                        AdditionInfoList[index] = editModel;
                    }
                }
                if (e.IsNew)
                {
                    editModel.IsChanged = true;
                    isDataEntryChanged = true;
                    editModel.Idx = AdditionInfoList.Count > 0
                            ? AdditionInfoList.Max(x => x.Idx) + 1
                            : 1;

                    AdditionInfoList.Add(editModel);
                }
            }
        }

        private void AdditionInfoGrid_OnCustomizeEditModel(GridCustomizeEditModelEventArgs e)
        {
            if (e.IsNew)
            {
                var newRow = (TbAdditionInfoUpdateDto)e.EditModel;
                newRow.Idx = AdditionInfoList.Count > 0
                    ? AdditionInfoList.Max(x => x.Idx) + 1
                    : 1;

                newRow.CompanyId = EditingCompanyId;
                newRow.IsChanged = true;
            }
        }

        private async Task SaveAdditionInfoAsync()
        {
            if (!isDataEntryChanged)
                return;

            await AdditionInfoGrid.SaveChangesAsync();
            AdditionInfoTempList.Clear();
            var itemsToSave = AdditionInfoList.Where(x => x.IsChanged).ToList();

            if (!itemsToSave.Any())
                return;

            foreach (var item in itemsToSave)
            {
                var updateDto = new TbAdditionInfoTempUpdateDto
                {
                    DocDate = item.DocDate,
                    TypeOfGroup = item.TypeOfGroup,
                    TypeOfEvent = item.TypeOfEvent,
                    Description = item.Description,
                    NoOfDocument = item.NoOfDocument,
                    Remark = item.Remark,
                };
                AdditionInfoTempList.Add(updateDto);

                if (item.Id == 0)
                {
                    // Xử lý thao tác INSERT
                    var createDto = ObjectMapper.Map<TbAdditionInfoTempUpdateDto, TbAdditionInfoTempCreateDto>(updateDto);
                    var landInfo = await TbAdditionInfoTempsAppService.CreateAsync(createDto);
                    updateDto.Id = landInfo.Id;

                    await SaveEntityChanges(
                        updateDto.Id,
                        "INSERT",
                        null,
                        updateDto,
                        "tbAdditionInfo_Temp",
                      "AdditionalInformation"
                    );
                    await _uiNotificationService.Success(L["Notification:Save"]);
                }
                else
                {
                    // Xử lý thao tác UPDATE
                    var originalItem = await TbAdditionInfosAppService.GetAsync(item.Id);
                    var originalDto = ObjectMapper.Map<TbAdditionInfoDto, TbAdditionInfoUpdateDto>(originalItem);

                    if (!FileHelper.ArePropertiesEqual(item, originalDto))
                    {
                        await SaveEntityChanges(
                            item.Id,
                            "UPDATE",
                            originalDto,
                            item,
                            "tbAdditionInfo",
                          "AdditionalInformation"
                        );
                        await _uiNotificationService.Success(L["Notification:Edit"]);
                    }
                }
                item.IsChanged = false;
            }

            isDataEntryChanged = false;
            await GetTbAdditionInfoAsync(EditingCompanyId);
            await InvokeAsync(StateHasChanged);
        }

        #endregion AdditionInfo



        #region AttachFile

        private async Task FileUploadGridNew_Click()
        {
            isNew = true;
            await FileUploadGrid.SaveChangesAsync();
            FileUploadGrid.ClearSelection();
            await FileUploadGrid.StartEditNewRowAsync();
        }

        private void FileUploadGrid_EditModelSaving(GridEditModelSavingEventArgs e)
        {
            TbFileUploadUpdateDto editModel = (TbFileUploadUpdateDto)e.EditModel;

            if (editModel != null)
            {
                if (editModel.fileName == null)
                {
                    _uiMessageService.Error(L["File name is required!! You haven't uploaded any files to save."]);
                    e.Cancel = true;
                    return;
                }

                if (!e.IsNew)
                {
                    editModel.IsChanged = true;
                    isDataEntryChanged = true;

                    int index = FileUploadList.FindIndex(item => item.Id == editModel.Id);
                    if (index != -1)
                    {
                        FileUploadList[index] = editModel;
                    }
                }
                if (e.IsNew)
                {
                    editModel.IsChanged = true;
                    isDataEntryChanged = true;
                    editModel.Idx = FileUploadList.Count > 0
                        ? FileUploadList.Max(x => x.Idx) + 1
                        : 1;
                    FileUploadList.Add(editModel);
                }
            }
        }

        private void FileUploadGrid_OnCustomizeEditModel(GridCustomizeEditModelEventArgs e)
        {
            if (e.IsNew)
            {
                var newRow = (TbFileUploadUpdateDto)e.EditModel;
                newRow.Idx = FileUploadList.Count > 0
                    ? FileUploadList.Max(x => x.Idx) + 1
                    : 1;

                newRow.companyId = EditingCompanyId;
                newRow.IsChanged = true;

                /* gán newRow.personId của user đăng nhạp*/
            }
        }

        #endregion AttachFile



        #region BODGrid

        private async Task GetListPositionBODChanged()
        {
            var result = await TbPositionsAppService.GetListNoPagedAsync(new GetTbPositionsInput { });
            PositionBODList = result.Where(x => x.PositionType == 1).ToList();
        }

        private async Task GetCompanyPersonBODAsync()
        {
            var result = await TbCompanyPersonsAppService.GetListByCompanyId(EditingCompanyId);
            var test = result.Where(x => x.PostionType == 1).ToList();
            CompanyPersonBODList = ObjectMapper.Map<List<TbCompanyPersonDto>, List<TbCompanyPersonUpdateDto>>(test);

        }

        private async Task GetCompanyPersonBOMAsync()
        {
            var result = await TbCompanyPersonsAppService.GetListByCompanyId(EditingCompanyId);
            var test = result.Where(x => x.PostionType == 2).ToList();
            CompanyPersonBOMList = ObjectMapper.Map<List<TbCompanyPersonDto>, List<TbCompanyPersonUpdateDto>>(test);
        }

        private async Task GetCompanyPersonBOSAsync()
        {
            var result = await TbCompanyPersonsAppService.GetListByCompanyId(EditingCompanyId);
            var test = result.Where(x => x.PostionType == 3).ToList();
            CompanyPersonBOSList = ObjectMapper.Map<List<TbCompanyPersonDto>, List<TbCompanyPersonUpdateDto>>(test);
        }

        private async Task GetCompanyPersonMemberAsync()
        {
            var result = await TbCompanyPersonsAppService.GetListByCompanyId(EditingCompanyId);
            var test = result.Where(x => x.PostionType == 4).ToList();
            CompanyPersonMemberList = ObjectMapper.Map<List<TbCompanyPersonDto>, List<TbCompanyPersonUpdateDto>>(test);
        }

        private async Task ClickEditRow()
        {
            isNew = false;
            editFormPopupVisible = true;
            await Task.CompletedTask;
        }

        private async Task CompanyPersonGridNew_Click()
        {
            isNew = true;
            await CompanyPersonGrid.SaveChangesAsync();
            CompanyPersonGrid.ClearSelection();
            await CompanyPersonGrid.StartEditNewRowAsync();
        }

        private void CompanyPersonGrid_EditModelSaving(GridEditModelSavingEventArgs e)
        {
            TbCompanyPersonUpdateDto editModel = (TbCompanyPersonUpdateDto)e.EditModel;
            if (editModel != null)
            {
                if (editModel.PersonId == 0)
                {
                    _uiMessageService.Error(L["Full Name is required!!"]);
                    e.Cancel = true;
                    return;
                }

                if (editModel.PositionId == 0)
                {
                    _uiMessageService.Error(L["Position is required!!"]);
                    e.Cancel = true;
                    return;
                }

                editModel.IsChanged = true;
                isDataEntryChanged = true;
                if (!e.IsNew)
                {
                    editModel.IsChanged = true;
                    int index = CompanyPersonBODList.FindIndex(item => item.Id == editModel.Id);
                    if (index != -1)
                    {
                        CompanyPersonBODList[index] = editModel;
                    }
                }
                else
                {
                    // Khi thêm mới, Id sẽ chưa được gán hoặc có giá trị không hợp lệ   
                    // Gán Idx tạm thời cho hàng mới
                    editModel.IsChanged = true;
                    editModel.Idx = CompanyPersonBODList.Count > 0
                      ? CompanyPersonBODList.Max(x => x.Idx) + 1
                      : 1;
                    CompanyPersonBODList.Add(editModel);
                }
            }

        }

        private void CompanyPersonGrid_OnCustomizeEditModel(GridCustomizeEditModelEventArgs e)
        {
            if (e.IsNew)
            {

                var newRow = (TbCompanyPersonUpdateDto)e.EditModel;
                // Tính toán Idx tạm thời cho hàng mới
                newRow.Idx = CompanyPersonBODList.Count > 0
                    ? CompanyPersonBODList.Max(x => x.Idx) + 1
                    : 1;

                newRow.CompanyId = EditingCompanyId;
                newRow.IsChanged = true;
            }
        }

        private async Task SaveCompanyPersonBODAsync()
        {
            // Kiểm tra nếu dữ liệu không thay đổi thì không thực hiện gì
            if (!isDataEntryChanged)
                return;

            await CompanyPersonGrid.SaveChangesAsync();
            // Xóa danh sách tạm để chuẩn bị cho dữ liệu mới
            CompanyPersonTempList.Clear();

            // Lọc các mục đã thay đổi
            var itemsToSave = CompanyPersonBODList.Where(x => x.IsChanged).ToList();

            // Nếu không có mục nào để lưu thì thoát
            if (!itemsToSave.Any())
                return;

            // Duyệt qua từng mục đã thay đổi
            foreach (var item in itemsToSave)
            {

                // Tạo đối tượng DTO cập nhật cho danh sách tạm
                var updateDto = new TbCompanyPersonTempUpdateDto
                {
                    BranchCode = item.BranchCode,
                    CompanyId = item.CompanyId,
                    PersonId = item.PersonId,
                    PositionId = item.PositionId,
                    FromDate = item.FromDate,
                    ToDate = item.ToDate,
                    PositionCode = item.PositionCode,
                    PersonalValue = item.PersonalValue,
                    PersonalSharePercentage = item.PersonalSharePercentage,
                    OwnerValue = item.OwnerValue,
                    RepresentativePercentage = item.RepresentativePercentage,
                    PositionType = item.PostionType,
                    Note = item.Note,
                    IsActive = item.IsActive,
                    crt_date = item.crt_date,
                    crt_user = item.crt_user,
                };

                // Thêm vào danh sách tạm để xử lý sau
                CompanyPersonTempList.Add(updateDto);

                // Kiểm tra nếu Id của mục là 0, nghĩa là đây là bản ghi mới
                if (item.Id == 0)
                {
                    // Xử lý thao tác INSERT
                    var createDto = ObjectMapper.Map<TbCompanyPersonTempUpdateDto, TbCompanyPersonTempCreateDto>(updateDto);
                    createDto.crt_date = item.crt_date;
                    createDto.crt_user = item.crt_user;
                    var CompaniesBOD = await TbCompanyPersonTempsAppService.CreateAsync(createDto);
                    updateDto.Id = createDto.PersonId;

                    // Ghi log thay đổi cho thao tác INSERT
                    await SaveEntityChanges(
                      updateDto.Id,
                      "INSERT",
                      null,
                      updateDto,
                      "tbCompanyPerson_Temp",
                      "BoardOfDirectors(BOD)"
                  );

                    await _uiNotificationService.Success(L["Notification:Save"]);
                }
                else
                {
                    var originalItem = await TbCompanyPersonsAppService.GetAsync(item.Id);
                    var originalDto = ObjectMapper.Map<TbCompanyPersonDto, TbCompanyPersonUpdateDto>(originalItem);

                    if (!FileHelper.ArePropertiesEqual(item, originalDto))
                    {
                        // Ghi log thay đổi cho thao tác UPDATE
                        await SaveEntityChanges(
                         item.Id,
                         "UPDATE",
                         originalDto,
                         item,
                         "tbCompanyPerson",
                         "BoardOfDirectors(BOD)"
                        );
                        await _uiNotificationService.Success(L["Notification:Edit"]);
                    }
                }

                // Đánh dấu mục đã xử lý xong
                updateDto.IsChanged = false;
            }

            isDataEntryChanged = false;
            await GetCompanyPersonBODAsync();
        }

        private Task GetYesNoLookupAsync()
        {
            YesNoLists = Enum.GetValues(typeof(YesNoType))
                .OfType<YesNoType>().Select(t => new YesNoTypeList()
                {
                    Value = t.ToString(),
                    DisplayName = L["YesNoType." + t.ToString()],
                }).ToList();

            return Task.CompletedTask;
        }

        private async Task OnYesNoChanged(string item)
        {
            isDataEntryChanged = true;
            var value = YesNoLists.FirstOrDefault(x => x.Value == item);
            EditingCompanyPerson.Note = value?.Value;
            await Task.CompletedTask;
        }

        private async Task FullNameChanged(int item)
        {
            isDataEntryChanged = true;
            var value = PersonsList.FirstOrDefault(x => x.Id == item);
            EditingCompanyPerson.PersonId = item;
            await Task.CompletedTask;
        }

        private async Task PositionBODChanged(int item)
        {
            isDataEntryChanged = true;
            var value = PositionBODList.FirstOrDefault(x => x.Id == item);
            EditingCompanyPerson.PositionId = item;
            EditingCompanyPerson.PositionCode = value?.Code;
            EditingCompanyPerson.PostionType = value?.PositionType;
            await Task.CompletedTask;
        }


        #endregion BOD Grid


        #region BOMGrid

        private async Task ClickEditRowBOM()
        {
            isNew = false;
            editFormBOMPopupVisible = true;
            await Task.CompletedTask;
        }

        private async Task CompanyPersonBOMGridNew_Click()
        {
            isNew = true;
            await CompanyPersonBOMGrid.SaveChangesAsync();
            CompanyPersonBOMGrid.ClearSelection();
            await CompanyPersonBOMGrid.StartEditNewRowAsync();
        }

        private void CompanyPersonGridBOM_EditModelSaving(GridEditModelSavingEventArgs e)
        {
            TbCompanyPersonUpdateDto editModel = (TbCompanyPersonUpdateDto)e.EditModel;
            if (editModel != null)
            {
                if (editModel.PersonId == 0)
                {
                    _uiMessageService.Error(L["Full Name is required!!"]);
                    e.Cancel = true;
                    return;
                }

                if (editModel.PositionId == 0)
                {
                    _uiMessageService.Error(L["Position is required!!"]);
                    e.Cancel = true;
                    return;
                }

                editModel.IsChanged = true;
                isDataEntryChanged = true;
                if (!e.IsNew)
                {
                    editModel.IsChanged = true;
                    int index = CompanyPersonBOMList.FindIndex(item => item.Id == editModel.Id);
                    if (index != -1)
                    {
                        CompanyPersonBOMList[index] = editModel;
                    }
                }
                else
                {
                    // Khi thêm mới, Id sẽ chưa được gán hoặc có giá trị không hợp lệ   
                    // Gán Idx tạm thời cho hàng mới
                    editModel.IsChanged = true;
                    editModel.Idx = CompanyPersonBOMList.Count > 0
                      ? CompanyPersonBOMList.Max(x => x.Idx) + 1
                      : 1;
                    CompanyPersonBOMList.Add(editModel);
                }
            }

        }

        private void CompanyPersonGridBOM_OnCustomizeEditModel(GridCustomizeEditModelEventArgs e)
        {
            if (e.IsNew)
            {

                var newRow = (TbCompanyPersonUpdateDto)e.EditModel;
                // Tính toán Idx tạm thời cho hàng mới
                newRow.Idx = CompanyPersonBOMList.Count > 0
                    ? CompanyPersonBOMList.Max(x => x.Idx) + 1
                    : 1;

                newRow.CompanyId = EditingCompanyId;
                newRow.IsChanged = true;
            }

        }

        private async Task SaveCompanyBOMPersonsync()
        {
            {
                // Kiểm tra nếu dữ liệu không thay đổi thì không thực hiện gì
                if (!isDataEntryChanged)
                    return;

                await CompanyPersonBOMGrid.SaveChangesAsync();
                // Xóa danh sách tạm để chuẩn bị cho dữ liệu mới
                CompanyPersonTempList.Clear();

                // Lọc các mục đã thay đổi
                var itemsToSave = CompanyPersonBOMList.Where(x => x.IsChanged).ToList();

                // Nếu không có mục nào để lưu thì thoát
                if (!itemsToSave.Any())
                    return;

                // Duyệt qua từng mục đã thay đổi
                foreach (var item in itemsToSave)
                {
                    // Tạo đối tượng DTO cập nhật cho danh sách tạm
                    var updateDto = new TbCompanyPersonTempUpdateDto
                    {
                        BranchCode = item.BranchCode,
                        CompanyId = item.CompanyId,
                        PersonId = item.PersonId,
                        PositionId = item.PositionId,
                        FromDate = item.FromDate,
                        ToDate = item.ToDate,
                        PositionCode = item.PositionCode,
                        PersonalValue = item.PersonalValue,
                        PersonalSharePercentage = item.PersonalSharePercentage,
                        OwnerValue = item.OwnerValue,
                        RepresentativePercentage = item.RepresentativePercentage,
                        PositionType = item.PostionType,
                        Note = item.Note,
                        IsActive = item.IsActive,
                        crt_date = item.crt_date,
                        crt_user = item.crt_user,
                    };

                    // Thêm vào danh sách tạm để xử lý sau
                    CompanyPersonTempList.Add(updateDto);

                    // Kiểm tra nếu Id của mục là 0, nghĩa là đây là bản ghi mới
                    if (item.Id == 0)
                    {
                        // Xử lý thao tác INSERT
                        var createDto = ObjectMapper.Map<TbCompanyPersonTempUpdateDto, TbCompanyPersonTempCreateDto>(updateDto);
                        createDto.crt_date = item.crt_date;
                        createDto.crt_user = item.crt_user;
                        var CompaniesBOD = await TbCompanyPersonTempsAppService.CreateAsync(createDto);
                        updateDto.Id = createDto.PersonId;

                        // Ghi log thay đổi cho thao tác INSERT
                        await SaveEntityChanges(
                          updateDto.Id,
                          "INSERT",
                          null,
                          updateDto,
                          "tbCompanyPerson_Temp",
                          "BoardOfManagement(BOM)"
                        );
                        await _uiNotificationService.Success(L["Notification:Save"]);
                    }
                    else
                    {
                        // Xử lý thao tác UPDATE
                        var originalItem = await TbCompanyPersonsAppService.GetAsync(item.Id);
                        var originalDto = ObjectMapper.Map<TbCompanyPersonDto, TbCompanyPersonUpdateDto>(originalItem);

                        if (!FileHelper.ArePropertiesEqual(item, originalDto))
                        {
                            // Ghi log thay đổi cho thao tác UPDATE
                            await SaveEntityChanges(
                                 item.Id,
                                 "UPDATE",
                                 originalDto,
                                 item,
                                 "tbCompanyPerson",
                              "BoardOfManagement(BOM)"
                             );
                            await _uiNotificationService.Success(L["Notification:Edit"]);
                        }
                    }

                    // Đánh dấu mục đã xử lý xong
                    updateDto.IsChanged = false;
                }

                // Đặt lại cờ cho biết dữ liệu đã thay đổi
                isDataEntryChanged = false;

                await GetCompanyPersonBOMAsync(); 
            }
        }

        private async Task OnYesNoChangedBOM(string item)
        {
            isDataEntryChanged = true;
            var value = YesNoLists.FirstOrDefault(x => x.Value == item);
            EditingCompanyPersonBOM.Note = value?.Value;
            await Task.CompletedTask;
        }

        private async Task AmendmentChanged(byte? item)
        {
            isDataEntryChanged = true;
            isAmendmentValidation = true;
            EditingCompany.RegistrationOrder = item;
             
            await Task.CompletedTask;
        }

        private async Task FullNameChangedBOM(int item)
        {
            isDataEntryChanged = true;
            var value = PersonsList.FirstOrDefault(x => x.Id == item);
            EditingCompanyPersonBOM.PersonId = item;
            await Task.CompletedTask;
        }

        private async Task PositionBOMChanged(int item)
        {
            isDataEntryChanged = true;
            var value = PositionBOMList.FirstOrDefault(x => x.Id == item);
            EditingCompanyPersonBOM.PositionId = item;
            EditingCompanyPersonBOM.PositionCode = value?.Code;
            EditingCompanyPersonBOM.PostionType = value?.PositionType;
            await Task.CompletedTask;
        }


        #endregion BOM Grid


        #region BOSGrid

        private async Task ClickEditRowBOS()
        {
            isNew = false;
            editFormBOSPopupVisible = true;
            await Task.CompletedTask;
        }

        private async Task CompanyPersonBOSGridNew_Click()
        {
            isNew = true;
            await CompanyPersonBOSGrid.SaveChangesAsync();
            CompanyPersonBOSGrid.ClearSelection();
            await CompanyPersonBOSGrid.StartEditNewRowAsync();
        }

        private void CompanyPersonGridBOS_EditModelSaving(GridEditModelSavingEventArgs e)
        {
            TbCompanyPersonUpdateDto editModel = (TbCompanyPersonUpdateDto)e.EditModel;
            if (editModel != null)
            {
                if (editModel.PersonId == 0)
                {
                    _uiMessageService.Error(L["Full Name is required!!"]);
                    e.Cancel = true;
                    return;
                }

                if (editModel.PositionId == 0)
                {
                    _uiMessageService.Error(L["Position is required!!"]);
                    e.Cancel = true;
                    return;
                }

                editModel.IsChanged = true;
                isDataEntryChanged = true;
                if (!e.IsNew)
                {
                    editModel.IsChanged = true;
                    int index = CompanyPersonBOSList.FindIndex(item => item.Id == editModel.Id);
                    if (index != -1)
                    {
                        CompanyPersonBOSList[index] = editModel;
                    }
                }
                else
                {
                    // Khi thêm mới, Id sẽ chưa được gán hoặc có giá trị không hợp lệ   
                    // Gán Idx tạm thời cho hàng mới
                    editModel.IsChanged = true;
                    editModel.Idx = CompanyPersonBOSList.Count > 0
                      ? CompanyPersonBOSList.Max(x => x.Idx) + 1
                      : 1;
                    CompanyPersonBOSList.Add(editModel);
                }
            }

        }

        private void CompanyPersonGridBOS_OnCustomizeEditModel(GridCustomizeEditModelEventArgs e)
        {
            if (e.IsNew)
            {
                var newRow = (TbCompanyPersonUpdateDto)e.EditModel;
                // Tính toán Idx tạm thời cho hàng mới
                newRow.Idx = CompanyPersonBOSList.Count > 0
                    ? CompanyPersonBOSList.Max(x => x.Idx) + 1
                    : 1;

                newRow.CompanyId = EditingCompanyId;
                newRow.IsChanged = true;
                newRow.crt_date = DateTime.Now;
            }

        }

        private async Task SaveCompanyBOSPersonsync()
        {
            // Kiểm tra nếu dữ liệu không thay đổi thì không thực hiện gì
            if (!isDataEntryChanged)
                return;

            await CompanyPersonBOSGrid.SaveChangesAsync();
            // Xóa danh sách tạm để chuẩn bị cho dữ liệu mới
            CompanyPersonTempList.Clear();

            // Lọc các mục đã thay đổi
            var itemsToSave = CompanyPersonBOSList.Where(x => x.IsChanged).ToList();

            // Nếu không có mục nào để lưu thì thoát
            if (!itemsToSave.Any())
                return;

            // Duyệt qua từng mục đã thay đổi
            foreach (var item in itemsToSave)
            {
                // Tạo đối tượng DTO cập nhật cho danh sách tạm
                var updateDto = new TbCompanyPersonTempUpdateDto
                {
                    BranchCode = item.BranchCode,
                    CompanyId = item.CompanyId,
                    PersonId = item.PersonId,
                    PositionId = item.PositionId,
                    FromDate = item.FromDate,
                    ToDate = item.ToDate,
                    PositionCode = item.PositionCode,
                    PersonalValue = item.PersonalValue,
                    PersonalSharePercentage = item.PersonalSharePercentage,
                    OwnerValue = item.OwnerValue,
                    RepresentativePercentage = item.RepresentativePercentage,
                    PositionType = item.PostionType,
                    Note = item.Note,
                    IsActive = item.IsActive,
                    crt_date = item.crt_date,
                    crt_user = item.crt_user,
                };

                // Thêm vào danh sách tạm để xử lý sau
                CompanyPersonTempList.Add(updateDto);

                // Kiểm tra nếu Id của mục là 0, nghĩa là đây là bản ghi mới
                if (item.Id == 0)
                {
                    // Xử lý thao tác INSERT
                    var createDto = ObjectMapper.Map<TbCompanyPersonTempUpdateDto, TbCompanyPersonTempCreateDto>(updateDto);
                    var CompaniesBOM = await TbCompanyPersonTempsAppService.CreateAsync(createDto);

                    // Ghi log thay đổi cho thao tác INSERT
                    await SaveEntityChanges(
                        CompaniesBOM.Id,
                        "INSERT",
                        null,
                        CompaniesBOM,
                        "tbCompanyPerson_Temp",
                        "BoardOfSupervisors(BOS)"
                    );
                    await _uiNotificationService.Success(L["Notification:Save"]);
                }
                else
                {
                    var originalItem = await TbCompanyPersonsAppService.GetAsync(item.Id);
                    var originalDto = ObjectMapper.Map<TbCompanyPersonDto, TbCompanyPersonUpdateDto>(originalItem);

                    if (!FileHelper.ArePropertiesEqual(item, originalDto))
                    {
                        // Ghi log thay đổi cho thao tác UPDATE
                        await SaveEntityChanges(
                             item.Id,
                             "UPDATE",
                             originalDto,
                             item,
                             "tbCompanyPerson",
                             "BoardOfSupervisors(BOS)"
                         );
                        await _uiNotificationService.Success(L["Notification:Edit"]);
                    }
                }

                // Đánh dấu mục đã xử lý xong
                updateDto.IsChanged = false;
            }

            isDataEntryChanged = false;
            await GetCompanyPersonBOSAsync();
        }

        private async Task OnYesNoChangedBOS(string item)
        {
            isDataEntryChanged = true;
            var value = YesNoLists.FirstOrDefault(x => x.Value == item);
            EditingCompanyPersonBOS.Note = value?.Value;
            await Task.CompletedTask;
        }

        private async Task FullNameChangedBOS(int item)
        {
            isDataEntryChanged = true;
            var value = PersonsList.FirstOrDefault(x => x.Id == item);
            EditingCompanyPersonBOS.PersonId = item;
            await Task.CompletedTask;
        }

        private async Task PositionBOSChanged(int item)
        {
            isDataEntryChanged = true;
            var value = PositionBOSList.FirstOrDefault(x => x.Id == item);
            EditingCompanyPersonBOS.PositionId = item;
            EditingCompanyPersonBOS.PositionCode = value?.Code;
            EditingCompanyPersonBOS.PostionType = value?.PositionType;
            await Task.CompletedTask;
        }

        #endregion BOS Grid


        #region Member’s Council Grid

        private async Task ClickEditRowTabMember()
        {
            isNew = false;
            editFormTabMemberPopupVisible = true;
            await Task.CompletedTask;
        }

        private async Task CompanyPersonTabMemberGridNew_Click()
        {
            isNew = true;
            await CompanyPersonTabMemberGrid.SaveChangesAsync();
            CompanyPersonTabMemberGrid.ClearSelection();
            await CompanyPersonTabMemberGrid.StartEditNewRowAsync();
        }

        private void CompanyPersonGridTabMember_EditModelSaving(GridEditModelSavingEventArgs e)
        {
            TbCompanyPersonUpdateDto editModel = (TbCompanyPersonUpdateDto)e.EditModel;
            if (editModel != null)
            {
                if (editModel.PersonId == 0)
                {
                    _uiMessageService.Error(L["Full Name is required!!"]);
                    e.Cancel = true;
                    return;
                }

                if (editModel.PositionId == 0)
                {
                    _uiMessageService.Error(L["Position is required!!"]);
                    e.Cancel = true;
                    return;
                }

                editModel.IsChanged = true;
                isDataEntryChanged = true;
                if (!e.IsNew)
                {
                    editModel.IsChanged = true;
                    int index = CompanyPersonMemberList.FindIndex(item => item.Id == editModel.Id);
                    if (index != -1)
                    {
                        CompanyPersonMemberList[index] = editModel;
                    }
                }
                else
                {
                    // Khi thêm mới, Id sẽ chưa được gán hoặc có giá trị không hợp lệ   
                    // Gán Idx tạm thời cho hàng mới
                    editModel.IsChanged = true;
                    editModel.Idx = CompanyPersonMemberList.Count > 0
                      ? CompanyPersonMemberList.Max(x => x.Idx) + 1
                      : 1;
                    CompanyPersonMemberList.Add(editModel);
                }
            }


        }

        private void CompanyPersonGridTabMember_OnCustomizeEditModel(GridCustomizeEditModelEventArgs e)
        {
            if (e.IsNew)
            {
                var newRow = (TbCompanyPersonUpdateDto)e.EditModel;
                // Tính toán Idx tạm thời cho hàng mới
                newRow.Idx = CompanyPersonMemberList.Count > 0
                    ? CompanyPersonMemberList.Max(x => x.Idx) + 1
                    : 1;

                newRow.CompanyId = EditingCompanyId;
                newRow.IsChanged = true;
                newRow.crt_date = DateTime.Now;
            }

        }

        private async Task SaveCompanyTabMemberPersonsync()
        {
            // Kiểm tra nếu dữ liệu không thay đổi thì không thực hiện gì
            if (!isDataEntryChanged)
                return;

            await CompanyPersonTabMemberGrid.SaveChangesAsync();
            // Xóa danh sách tạm để chuẩn bị cho dữ liệu mới
            CompanyPersonTempList.Clear();

            // Lọc các mục đã thay đổi
            var itemsToSave = CompanyPersonMemberList.Where(x => x.IsChanged).ToList();

            // Nếu không có mục nào để lưu thì thoát
            if (!itemsToSave.Any())
                return;

            // Duyệt qua từng mục đã thay đổi
            foreach (var item in itemsToSave)
            {
                // Tạo đối tượng DTO cập nhật cho danh sách tạm
                var updateDto = new TbCompanyPersonTempUpdateDto
                {
                    BranchCode = item.BranchCode,
                    CompanyId = item.CompanyId,
                    PersonId = item.PersonId,
                    PositionId = item.PositionId,
                    FromDate = item.FromDate,
                    ToDate = item.ToDate,
                    PositionCode = item.PositionCode,
                    PersonalValue = item.PersonalValue,
                    PersonalSharePercentage = item.PersonalSharePercentage,
                    OwnerValue = item.OwnerValue,
                    RepresentativePercentage = item.RepresentativePercentage,
                    Note = item.Note,
                    PositionType = item.PostionType,
                    IsActive = item.IsActive,
                    crt_date = item.crt_date,
                    crt_user = item.crt_user,
                };

                // Thêm vào danh sách tạm để xử lý sau
                CompanyPersonTempList.Add(updateDto);

                // Kiểm tra nếu Id của mục là 0, nghĩa là đây là bản ghi mới
                if (item.Id == 0)
                {
                    // Xử lý thao tác INSERT
                    var createDto = ObjectMapper.Map<TbCompanyPersonTempUpdateDto, TbCompanyPersonTempCreateDto>(updateDto);
                    createDto.crt_date = item.crt_date;
                    createDto.crt_user = item.crt_user;
                    var CompaniesBOM = await TbCompanyPersonTempsAppService.CreateAsync(createDto);
                    updateDto.Id = createDto.PersonId;

                    // Ghi log thay đổi cho thao tác INSERT
                    await SaveEntityChanges(
                         updateDto.Id,
                         "INSERT",
                         null,
                         updateDto,
                         "tbCompanyPerson_Temp",
                         "Member’sCouncil"
                     );
                    await _uiNotificationService.Success(L["Notification:Save"]);
                }
                else
                {
                    var originalItem = await TbCompanyPersonsAppService.GetAsync(item.Id);
                    var originalDto = ObjectMapper.Map<TbCompanyPersonDto, TbCompanyPersonUpdateDto>(originalItem);

                    if (!FileHelper.ArePropertiesEqual(item, originalDto))
                    {
                        // Ghi log thay đổi cho thao tác UPDATE
                        await SaveEntityChanges(
                             item.Id,
                             "UPDATE",
                             originalDto,
                             item,
                             "tbCompanyPerson",
                             "Member’sCouncil"
                         );
                        await _uiNotificationService.Success(L["Notification:Edit"]);
                    }
                }

                // Đánh dấu mục đã xử lý xong
                updateDto.IsChanged = false;
            }

            isDataEntryChanged = false;
            await GetCompanyPersonMemberAsync();
        }

        private async Task OnYesNoChangedTabMember(string item)
        {
            var value = YesNoLists.FirstOrDefault(x => x.Value == item);
            EditingCompanyPersonMember.Note = value?.Value;
            await Task.CompletedTask;
        }

        private async Task FullNameChangedTabMenber(int item)
        {
            var value = PersonsList.FirstOrDefault(x => x.Id == item);
            EditingCompanyPersonMember.PersonId = item;
            await Task.CompletedTask;
        }

        private async Task PositionMemberChanged(int item)
        {
            var value = PositionMemberList.FirstOrDefault(x => x.Id == item);
            EditingCompanyPersonMember.PositionId = item;
            EditingCompanyPersonMember.PositionCode = value?.Code;
            EditingCompanyPersonMember.PostionType = value?.PositionType;
            await Task.CompletedTask;
        }

        #endregion Member’s Council Grid



        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                         THÔNG BÁO - VALIDATIONS
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


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

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            bool checkSaving = await SavingConfirmAsync();
            if (!checkSaving)
                context.PreventNavigation();
        }

        private async Task AdditionInfoChangePageSize(int value)
        {
            AdditionInfoPageSize = value;
            await Task.CompletedTask;
        }

        private async Task BODChangePageSize(int value)
        {
            BODPageSize = value;
            await Task.CompletedTask;
        }

        private async Task BOMChangePageSize(int value)
        {
            BOMPageSize = value;
            await Task.CompletedTask;
        }

        private async Task BOSChangePageSize(int value)
        {
            BOSPageSize = value;
            await Task.CompletedTask;
        }

        private async Task InvestmentChangePageSize(int value)
        {
            InvestmentPageSize = value;
            await Task.CompletedTask;
        }

        private async Task MemberChangePageSize(int value)
        {
            MemberPageSize = value;
            await Task.CompletedTask;
        }

        private async Task LandInfoChangePageSize(int value)
        {
            LandInfoPageSize = value;
            await Task.CompletedTask;
        }

        private async Task MajorChangePageSize(int value)
        {
            MajorPageSize = value;
            await Task.CompletedTask;
        }

        private async Task FileUploadChangePageSize(int value)
        {
            FileUploadPageSize = value;
            await Task.CompletedTask;
        }


        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                              UPLOAD - DOWNLOAD
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        //Upload
        private async Task HandleFileSelected(IBrowserFile file)
        {
            var currentUserId = TbUserList.FirstOrDefault(x => x.UserName == CurrentUser.UserName)?.Id;

            try
            {
                var maxFileSize = 15 * 1024 * 1024; // 15 MB
                var fileExtension = Path.GetExtension(file.Name).ToLower();
                var allowedExtensions = new[] { ".pdf" };

                // Kiểm tra loại tệp
                if (!allowedExtensions.Contains(fileExtension))
                {
                    await _uiMessageService.Error(L["Error:InvalidFileType"]);
                    return;
                }

                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.Name);
                var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                var sanitizedFileName = $"{FileHelper.SanitizeFileName(fileNameWithoutExtension)}_{timestamp}{fileExtension}";
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Docs");

                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var filePath = Path.Combine(uploadsFolderPath, sanitizedFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    using (var stream = file.OpenReadStream(maxFileSize))
                    {
                        await stream.CopyToAsync(fileStream, CancellationToken.None);
                    }
                }

                var fileUploadDto = new TbFileUploadTempUpdateDto
                {
                    companyId = EditingCompanyId > 0 ? EditingCompanyId : 0,
                    personId = null,
                    fileName = sanitizedFileName,
                    fullFileName = file.Name,
                    fileLink = $"/Docs/{sanitizedFileName}",
                    uploadDate = EditingFileUpload.uploadDate,
                    UserUpload = currentUserId,
                    note = EditingFileUpload.note,
                    IsActive = true,
                    crt_date = DateTime.Now,
                    crt_user = currentUserId,
                    IsChanged = true,
                };

                EditingFileUpload.fullFileName = file.Name;
                EditingFileUpload.fileName = fileNameWithoutExtension;
                EditingFileUpload.fileLink = fileUploadDto.fileLink;
                tempFiles.Add(fileUploadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            await GetTbFileUploadTempListAsync();
            await InvokeAsync(StateHasChanged);
        }


        private async Task GetTbFileUploadTempListAsync()
        {
            TbFileUploadTempList = await TbFileUploadTempsAppService.GetListNoPagedAsync(new GetTbFileUploadTempsInput());
        }

        private async Task SaveFilesAsync()
        {
            var tasks = new List<Task>();

            foreach (var tempFile in tempFiles.Where(x => x.IsChanged))
            {
                if (tempFile.Id == 0 && EditingFileUpload.Id == 0)
                {
                    // Xử lý thao tác INSERT
                    var createDto = ObjectMapper.Map<TbFileUploadTempUpdateDto, TbFileUploadTempCreateDto>(tempFile);
                    var fileUpload = await TbFileUploadTempsAppService.CreateAsync(createDto);
                    tempFile.Id = fileUpload.Id;

                    tasks.Add(SaveEntityChanges(
                        tempFile.Id,
                        "INSERT",
                        null,
                        tempFile,
                        "tbFileUpload_Temp",
                        "AttachFile"
                    ));

                    tasks.Add(_uiNotificationService.Success(L["Notification:Save"]));
                }
            }

            if (isDataEntryChanged)
            {
                if (EditingFileUpload.Id != 0)
                {
                    var originalItem = await TbFileUploadsAppService.GetAsync(EditingFileUpload.Id);
                    var originalDto = ObjectMapper.Map<TbFileUploadDto, TbFileUploadUpdateDto>(originalItem);

                    tasks.Add(SaveEntityChanges(
                        EditingFileUpload.Id,
                        "UPDATE",
                        originalDto,
                        EditingFileUpload,
                        "tbFileUpload",
                        "AttachFile"
                    ));

                    tasks.Add(_uiNotificationService.Success(L["Notification:Edit"]));
                }
            }

            // Chờ cho tất cả các tác vụ trong danh sách tasks hoàn thành
            await Task.WhenAll(tasks);

            tempFiles.Clear();
            isDataEntryChanged = false;
            await GetFileUploadListAsync(EditingCompanyId);
            await LoadDataAsync(EditingCompanyId);
            await InvokeAsync(StateHasChanged);
        }

        private async Task RemoveFileAsync()
        {
            var confirmed = await _uiMessageService.Confirm(L["DeleteConfirmationMessage"]);
            if (confirmed)
            {
                // Xóa các file tạm từ hệ thống file
                foreach (var tempFile in tempFiles)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Docs", tempFile.fileName);
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }

                if (EditingFileUpload.Id != 0)
                {
                    isDataEntryChanged = true;
                }

                // Xóa danh sách các file tạm
                tempFiles.Clear();

                EditingFileUpload.fileName = null;
                EditingFileUpload.fullFileName = null;
                EditingFileUpload.fileLink = null;
                EditingFileUpload.IsChanged = true;
            }
            await GetFileUploadListAsync(EditingCompanyId);
            await InvokeAsync(StateHasChanged);
        }


        //Download
        private async Task DownloadAsync(int fileId)
        {
            var file = FileUploadList.FirstOrDefault(x => x.Id == fileId);
            if (file != null)
            {
                string? fileUrl = file.fileLink;

                string script = GenerateDownloadScript(fileUrl);

                // Thực thi script bằng cách sử dụng JavaScript interop
                await JSRuntime.InvokeVoidAsync("eval", script);

                // Tăng số lần tải file
                var fileUpdateDto = ObjectMapper.Map<TbFileUploadDto, TbFileUploadUpdateDto>(await TbFileUploadsAppService.GetAsync(fileId));
                fileUpdateDto.DownloadCount++;

                await TbFileUploadsAppService.UpdateAsync(fileId, fileUpdateDto);
                await _uiNotificationService.Success(L["Notification:Download"]);
            }
            await GetFileUploadListAsync(EditingCompanyId);
            await InvokeAsync(StateHasChanged);
        }

        private string GenerateDownloadScript(string? fileUrl)
        {
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






        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                          HISTORY - FIREANT JS
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        #region --History

        // Lấy lịch sử hiển thị
        private async Task GetTbInfoUpdateListAsync()
        {
            var result = await InfoUpdatesAppService.GetListNoPagedAsync(new GetTbInfoUpdatesInput { });
            TbInfoUpdateList = result.Where(x => x.ScreenName == screenName && x.ScreenId == EditingCompanyId && x.IsVisible == true)
                .OrderByDescending(x=>x.crt_date)
                .ToList();
        }

        private async Task GetHistoryAsync()
        {
            await _blockUiService.Block(selectors: "#lpx-content-container", busy: false);

            await GetTbInfoUpdateListAsync();

            screenId = EditingCompanyId;

            if (TbInfoUpdateList.Count() > 0)
            {
                GroupedChanges = TbInfoUpdateList
                .Where(x => x.ChangeSetId.HasValue)
                .GroupBy(x => x.ChangeSetId)
                .ToList();

                isColumn1Visible = false;
                isColumn2Visible = true;

                await InvokeAsync(StateHasChanged);
            }
            else
            {
                await _uiMessageService.Warn(L["NoHistoryAvailable"]);
            }

            await _blockUiService.UnBlock();
        }

        private async Task HideHistory()
        {
            isColumn1Visible = true;
            isColumn2Visible = false;

            await InvokeAsync(StateHasChanged);
        }


        // Lưu lịch sử
        private bool IsColumnVisible(string columnName)
        {
            // Danh sách các cột muốn hiển thị
            var visibleColumns = new List<string>
            {
                "Code", "BriefName", "Name", "Name_EN", "ContactInfo_01", "ContactInfo_02",
                "ContactInfo_03", "ContactInfo_04", "ContactInfo_05", "ContactInfo_06", "License",
                "DirectShareholding", "ConsolidatedShareholding", "ParentId", "IsPublicCompany",
                "RegistrationDate", "LatestAmendment", "RegistrationOrder", "LegalRepresent",
                "MajorBusiness", "OtherActivity", "VotingRightDirect", "VotingRightTotal",
                "StockExchange", "StockCode", "StockRegistrationDate", "CharteredCapital", "ParValue",
                "TotalShare", "ListedShare", "PersonId", "PositionId", "FromDate", "ToDate",
                "PersonalValue", "PersonalSharePercentage", "OwnerValue", "RepresentativePercentage",
                "ShareHolderMajor", "ShareHolderType", "ShareHolderValue", "ShareHolderRate",
                "ContactName1", "ContactDept1", "ContactPosition1", "ContactPhone1", "ContactMail1",
                "ContactName2", "ContactDept2", "ContactPosition2", "ContactPhone2", "ContactMail2",
                "Description", "Address", "TypeOfLand", "Area", "SupportingDocument", "CompanyName",
                "Shares", "Holding", "DocDate", "TypeOfGroup", "TypeOfEvent", "NoOfDocument",
                "Remark", "Note", "DownloadCount", "idCompanyType", "idCompanyTypesCode", 
                "idCompanyTypeShareholdingCode", "fileName", "note", "uploadDate", "UserUpload"
            };

            // Kiểm tra xem cột hiện tại có trong danh sách các cột được hiển thị không
            return visibleColumns.Contains(columnName);
        }

        private static readonly HashSet<string> DecimalColumns = new HashSet<string>
        {
            "DirectShareholding", "ConsolidatedShareholding", "Area",
            "Shares", "Holding", "TotalShare", "ListedShare", "CharteredCapital",
            "VotingRightDirect", "VotingRightTotal", "ShareHolderValue", "ShareHolderRate",
            "PersonalValue", "PersonalSharePercentage", "OwnerValue", "RepresentativePercentage",
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
                    var infoUpdate = CreateInfoUpdateDto(field.Key, null, formattedValue, EditingCompanyId, rowId, command, tableName, changeSetId, groupName, isVisible);
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
                        var infoUpdate = CreateInfoUpdateDto(field, formattedLastValue, formattedNewValue, EditingCompanyId, rowId, command, tableName, changeSetId, groupName, isVisible);
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
                ScreenName = "Companies",
                ScreenId = screenId,
                GroupName = groupName,
                RowId = rowId,
                Command = command,
                LastValue = lastValue,
                NewValue = newValue,
                DocStatus = 0,
                Comment = "",
                IsActive = 1,
                IsVisible = isVisible, // hiển thị lên màn hình history => true: hiện , false: ẩn
                TimeAssessment = null,
                crt_user = currentUser?.Id,
                crt_date = DateTime.Now,
                mod_user = null,
                mod_date = null
            };
        }


        #endregion History-- 


        #region Stock Price Fireant

        private async Task LoadStock(string? stockCode)
        {
            // Nếu đã khởi tạo thành công
            if (isInitialized)
            {
                // Nếu mã Stock Code không rỗng hoặc không phải là dấu "-"
                if (!string.IsNullOrWhiteSpace(stockCode) && !stockCode.Equals("-"))
                {
                    // Loại bỏ khoảng trắng từ stockCode
                    string trimmedStockCode = stockCode.Trim();

                    // Tạo script hiển thị thông tin Stock Code 
                    string script = GenerateStockQuoteScript(trimmedStockCode);

                    // Thực thi script bằng cách sử dụng JavaScript interop
                    await JSRuntime.InvokeVoidAsync("eval", script);
                }
                else
                {
                    // Xóa nội dung nếu không có Stock Code
                    await JSRuntime.InvokeVoidAsync("eval", "document.getElementById('financial-data').innerHTML = '';");
                }
            }
        }

        private string GenerateStockQuoteScript(string stockCode)
        {
            // Tạo script JavaScript để hiển thị thông tin
            return @"
                (function() {
                    var script = document.createElement('script');
                    script.src = 'https://www.fireant.vn/Scripts/web/widgets.js';
                    script.onload = function() {
                        new FireAnt.QuoteWidget({
                            container_id: 'financial-data',
                            symbols: '" + stockCode + @"',
                            locale: 'vi',
                            price_line_color: '#71BDDF',
                            grid_color: '#999999',
                            label_color: '#999999',
                            width: '100%',
                            height: '300px'
                        });
                    };
                    document.head.appendChild(script);
                })();
            ";
        }

        #endregion



    }
}