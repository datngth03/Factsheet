using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using System.Web;
using Blazorise;
using Blazorise.DataGrid;
using Volo.Abp.BlazoriseUI.Components;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using Sabeco_Factsheet.TbCompanyPersons;
using Sabeco_Factsheet.TbNationalities;
using Sabeco_Factsheet.TbPersons;
using Sabeco_Factsheet.TbCompanies;
using Sabeco_Factsheet.TbPositions;
using Sabeco_Factsheet.Permissions;
using Sabeco_Factsheet.Shared;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components.Messages;

using Blazorise.Snackbar;
using DevExpress.Blazor;
using DevExpress.Blazor.Internal;
using Microsoft.AspNetCore.Components.Routing;
using Sabeco_Factsheet.TbInfoUpdates;
using Sabeco_Factsheet.TbUsers;
using Excubo.Blazor.TreeViews;
using Sabeco_Factsheet.TbPersonTemps;
using Volo.Abp.ObjectMapping;
using Sabeco_Factsheet.TbFileUploads;
using Sabeco_Factsheet.TbFileUploadTemps;
using Sabeco_Factsheet.TbCompanyPersonTemps;
using Sabeco_Factsheet.TbUserMappingCompanies;
using Sabeco_Factsheet.Blazor.Client.Pages.AttachmentFile;
using Volo.Abp.AspNetCore.Components.Progression;
using Sabeco_Factsheet.TbBreweries;
using Microsoft.JSInterop;
using System.Threading;
using System.Reflection;
using System.ComponentModel.Design;
using Volo.Abp.Users;
using SkiaSharp;


namespace Sabeco_Factsheet.Blazor.Client.Pages.Person
{
    public partial class Persons
    {
        protected List<Volo.Abp.BlazoriseUI.BreadcrumbItem> BreadcrumbItems = new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>();
        protected PageToolbar Toolbar { get; } = new PageToolbar();
        private int PageSize { get; } = LimitedResultRequestDto.MaxMaxResultCount;
        private int CurrentPage { get; set; } = 1;
        private string CurrentSorting { get; set; } = string.Empty;
        private int TotalCount { get; set; }

        private bool CanCreateTbPerson { get; set; }
        private bool CanEditTbPerson { get; set; }
        private bool CanDeleteTbPerson { get; set; }
        private bool isDataEntryChanged { get; set; }

        [Parameter]
        public string Id { get; set; }
        private int EditingPersonId { get; set; }
        private int EditingPersonTempId { get; set; }

        private GetTbCompanyPersonsInput Filter { get; set; }
        private TbPersonUpdateDto EditingPerson { get; set; } = new TbPersonUpdateDto();
        private TbPersonTempUpdateDto EditingPersonTemp { get; set; } = new TbPersonTempUpdateDto();
        private TbCompanyDto EditingCompany { get; set; } = new TbCompanyDto();
        private TbFileUploadUpdateDto EditingFileUpload { get; set; } = new TbFileUploadUpdateDto();
        private TbFileUploadTempUpdateDto EditingFileUploadTemp { get; set; } = new TbFileUploadTempUpdateDto();


        private List<TbUserMappingCompanyDto> TbUserMappingCompaniesList { get; set; } = new List<TbUserMappingCompanyDto>();
        private List<TbUserDto> TbUserList { get; set; } = new List<TbUserDto>();
        private List<TbPersonTempDto> TbPersonTempList { get; set; } = new List<TbPersonTempDto>();
        private List<TbCompanyDto> TbCompanyList { get; set; } = new List<TbCompanyDto>();
        private List<TbPositionDto> TbPositionList { get; set; } = new List<TbPositionDto>();
        private List<GenderItem> GenderList { get; set; } = new List<GenderItem>();
        private List<TbNationalityDto> NationalityList { get; set; } = new List<TbNationalityDto>();
        private IReadOnlyList<TbCompanyPersonDto> CompanyPersonLists { get; set; } = new List<TbCompanyPersonDto>(); 
        private IReadOnlyList<TbCompanyPersonDto> CompanyPersonBODList { get; set; } = new List<TbCompanyPersonDto>();
        private IReadOnlyList<TbCompanyPersonDto> CompanyPersonBOMList { get; set; } = new List<TbCompanyPersonDto>();
        private IReadOnlyList<TbCompanyPersonDto> CompanyPersonBOSList { get; set; } = new List<TbCompanyPersonDto>();
        private IReadOnlyList<TbCompanyPersonDto> CompanyPersonMemberList { get; set; } = new List<TbCompanyPersonDto>();


        private EditForm EditFormMain { get; set; }
        private CheckBoxContentAlignment Alignment { get; set; }
        private LabelPosition LabelPosition { get; set; }
        private IGrid CompanyGrid { get; set; }


        //------------------------- IMAGE - UPLOAD  
        private bool uploadComplete { get; set; } = false; 
        private string? fileType { get; set; }
        private byte[]? fileBytes { get; set; }
        private int fileSize { get; set; }
        private int totalBytesRead { get; set; }

        private List<string> allowedFileExtensions = new() { ".jpg", ".jpeg", ".png" };

        private List<TbFileUploadDto> TbFileUploadList = new List<TbFileUploadDto> { };
        private List<TbFileUploadTempDto> TbFileUploadTempList { get; set; } = new List<TbFileUploadTempDto>();



        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                                 Initial
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        public Persons()
        {
            Filter = new GetTbCompanyPersonsInput
            {
                MaxResultCount = PageSize,
                SkipCount = (CurrentPage - 1) * PageSize,
                Sorting = CurrentSorting
            };
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
            EditingPersonId = int.Parse(Id);
            await SetPermissionsAsync();
            await SetToolbarItemsAsync();
            await SetBreadcrumbItemsAsync();
        }


        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                      ToolBar - Breadcrumb - Permission   
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        private async Task SetPermissionsAsync()
        {
            CanCreateTbPerson = await AuthorizationService
                .IsGrantedAsync(Sabeco_FactsheetPermissions.TbPersons.Create);
            CanEditTbPerson = await AuthorizationService
                            .IsGrantedAsync(Sabeco_FactsheetPermissions.TbPersons.Edit);
            CanDeleteTbPerson = await AuthorizationService
                            .IsGrantedAsync(Sabeco_FactsheetPermissions.TbPersons.Delete);
        }

        protected virtual ValueTask SetBreadcrumbItemsAsync()
        {
            BreadcrumbItems.AddRange(new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>
            {
                new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:TbPersons"],"/persons"),
                new Volo.Abp.BlazoriseUI.BreadcrumbItem(EditingPerson.Code)
            });
            return ValueTask.CompletedTask;
        }

        protected virtual ValueTask SetToolbarItemsAsync()
        {
            Toolbar.AddButton(L["Back"], async () =>
            {
                NavigationManager.NavigateTo($"/persons");
                await Task.CompletedTask;
            },
             IconName.Undo,
            Blazorise.Color.Default);


            Toolbar.AddButton(L["Save"], async () =>
            {
                await SaveDataAsync();
            },
              IconName.Save,
              Blazorise.Color.Primary,
               requiredPolicyName: Sabeco_FactsheetPermissions.TbPersons.Edit);


            return ValueTask.CompletedTask;
        }


        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                    Load Data Source for ListView & Others  
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        private async Task LoadGridData()
        {
            if (isDataEntryChanged)
            {
                var confirmed = await _uiMessageService.Confirm(L["DeleteConfirmationMessage"]);
            }

            // Lấy dữ liệu cho các danh sách
            await GetCompanyPersonBODAsync();
            await GetCompanyPersonBOMAsync();
            await GetCompanyPersonBOSAsync();
            await GetCompanyPersonMemberAsync();

            await GetNationalityAsync();
            await GetUserListAsync();
            await GetPositionAsync();
            await GetCompanyAsync();
            await GetTbPersonTempListAsync();
            await GetTbFileUploadListAsync(); 

            await LoadDataAsync(EditingPersonId);
            await GetCompanyPersonsAsync(EditingPersonId);
        }

        private async Task LoadDataAsync(int classId)
        { 
            // Khởi tạo danh sách giới tính
            GenderList = new List<GenderItem>
            {
                new GenderItem { Value = "0", DisplayName = "Male" },
                new GenderItem { Value = "1", DisplayName = "Female" }
            };

            // Xử lý thông tin người dùng và tệp
            if (classId > 0)
            {
                var personDto = await TbPersonsAppService.GetAsync(classId);
                EditingPerson = ObjectMapper.Map<TbPersonDto, TbPersonUpdateDto>(personDto);

                if (EditingPerson.Image == null)
                {
                    EditingPerson.Image = null;
                }

                var fileUpload = TbFileUploadList.FirstOrDefault(x => x.personId == classId);
                if (fileUpload != null)
                {
                    EditingFileUpload = new TbFileUploadUpdateDto
                    {
                        Id = fileUpload.Id,
                        fileLink = fileUpload.fileLink,
                        fileName = fileUpload.fileName,
                        fullFileName = fileUpload.fullFileName
                    };
                }
            }
            else
            {
                EditingPerson = new TbPersonUpdateDto
                {
                    IsCheckRetirement = false,
                    IsCheckTermEnd = false,
                    BirthDate = new DateTime(1875, 1, 1) 
                };
            } 

            await InvokeAsync(StateHasChanged);
        }


        private async Task GetCompanyPersonBODAsync()
        {
            if (EditingPerson.CompanyId.HasValue)
            {
                var result = await TbCompanyPersonsAppService.GetListByCompanyId((int)EditingPerson.CompanyId);
                CompanyPersonBODList = result.Where(x => x.PostionType == 1).ToList();
            }
        }

        private async Task GetCompanyPersonBOMAsync()
        {
            if (EditingPerson.CompanyId.HasValue)
            {
                var result = await TbCompanyPersonsAppService.GetListByCompanyId((int)EditingPerson.CompanyId);
                CompanyPersonBOMList = result.Where(x => x.PostionType == 2).ToList();
            }
        }

        private async Task GetCompanyPersonBOSAsync()
        {
            if (EditingPerson.CompanyId.HasValue)
            {
                var result = await TbCompanyPersonsAppService.GetListByCompanyId((int)EditingPerson.CompanyId);
                CompanyPersonBOSList = result.Where(x => x.PostionType == 3).ToList();
            }
        }

        private async Task GetCompanyPersonMemberAsync()
        {
            if (EditingPerson.CompanyId.HasValue)
            {
                var result = await TbCompanyPersonsAppService.GetListByCompanyId((int)EditingPerson.CompanyId);
                CompanyPersonMemberList = result.Where(x => x.PostionType == 4).ToList();
            }
        }

        private async Task GetTbFileUploadListAsync()
        {
            TbFileUploadList = await TbFileUploadsAppService.GetListNoPagedAsync(new GetTbFileUploadsInput { });
        }
        
        private async Task GetNationalityAsync()
        {
            NationalityList = await TbNationalitiesAppService.GetListNoPagedAsync(new GetTbNationalitiesInput());
        }

        private async Task GetUserListAsync()
        {
            TbUserList = await TbUsersAppService.GetListNoPagedAsync(new GetTbUsersInput { });
        }

        private async Task GetTbPersonTempListAsync()
        {
            TbPersonTempList = await TbPersonTempsAppService.GetListNoPagedAsync(new GetTbPersonTempsInput { });
        }

        private async Task GetTbUserMappingCompaniesListAsync()
        {
            var currentUser = TbUserList.FirstOrDefault(x => x.UserName == CurrentUser.UserName);

            if (currentUser != null)
            {
                var result = await TbUserMappingCompaniesAppService.GetListNoPagedAsync(new GetTbUserMappingCompaniesInput { });
                TbUserMappingCompaniesList = result.Where(x => x.userid == currentUser.Id).ToList();
            }
        }

        private async Task GetCompanyAsync()
        {
            await GetTbUserMappingCompaniesListAsync();

            // Lấy tất cả dữ liệu mà không phân trang để tính TotalCount
            var allCompaniesResult = await TbCompaniesAppService.GetListNoPagedAsync(new GetTbCompaniesInput { });

            // Lọc danh sách dựa trên quyền truy cập của người dùng
            TbCompanyList = allCompaniesResult
                .Where(x => TbUserMappingCompaniesList.Any(mapping => mapping.companyid == x.Id))
                .ToList();

        }

        private string GetCompanyName(int companyId)
        {
            var company = TbCompanyList.FirstOrDefault(c => c.Id == companyId);
            return company?.Name ?? "Unknown";
        }

        private async Task GetPositionAsync()
        {
            TbPositionList = await TbPositionsAppService.GetListNoPagedAsync(new GetTbPositionsInput());
        }

        private string GetPositionNameEN(int? positionId)
        {
            var position = TbPositionList.FirstOrDefault(c => c.Id == positionId);
            return position?.Name_EN ?? "Unknown";
        }

        private async Task GetCompanyPersonsAsync(int personId)
        {
            if (EditingPerson.CompanyId != null)
            {
                // Gộp dữ liệu từ các danh sách
                var allCompanyPersons = await TbCompanyPersonsAppService.GetListNoPagedAsync(new GetTbCompanyPersonsInput { });

                allCompanyPersons.AddRange(CompanyPersonBODList ?? Enumerable.Empty<TbCompanyPersonDto>());
                allCompanyPersons.AddRange(CompanyPersonBOMList ?? Enumerable.Empty<TbCompanyPersonDto>());
                allCompanyPersons.AddRange(CompanyPersonBOSList ?? Enumerable.Empty<TbCompanyPersonDto>());
                allCompanyPersons.AddRange(CompanyPersonMemberList ?? Enumerable.Empty<TbCompanyPersonDto>());

                // Áp dụng bộ lọc dựa trên personId
                CompanyPersonLists = allCompanyPersons
                    .Where(x => x.PersonId == personId) // Lọc theo personId nếu cần
                    .ToList();

                TotalCount = CompanyPersonLists.Count;
                await Task.CompletedTask;
            }
        }



        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                              SELECTED CHANGED
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        private async Task SelectedGenderChangedAsync(string? selectedGender)
        {
            EditingPerson.Gender = selectedGender;
            await InvokeAsync(StateHasChanged);
        }

        private async Task SelectedNationalityChangedAsync(string? selectedNationalityCode)
        {
            EditingPerson.NationalityCode = selectedNationalityCode;
            isDataEntryChanged = true;
            await InvokeAsync(StateHasChanged);
        }



        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                          Controls triggers/events  
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        private async Task ResetToolbar()
        {
            Toolbar.Contributors.Clear();
            await SetToolbarItemsAsync();
        }

        private async Task OnDateChanged(DateTime? newValue)
        {
            isDataEntryChanged = true;
            EditingPerson.IDCardDate = newValue;
            await InvokeAsync(StateHasChanged);
        }

        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<TbCompanyPersonDto> e)
        {
            CurrentSorting = e.Columns
                .Where(c => c.SortDirection != SortDirection.Default)
                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentPage = e.Page;
            await GetCompanyPersonsAsync(EditingPersonId);
            await InvokeAsync(StateHasChanged);
        }






        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                              UPLOAD - DOWNLOAD
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        //Upload Image
        private async Task OnFilesUploading(FilesUploadingEventArgs args)
        {
            uploadComplete = false;
            var file = args.Files.FirstOrDefault();

            if (file == null)
            {
                await _uiMessageService.Warn("No file selected.");
                return;
            }

            fileSize = (int)file.Size;
            fileBytes = new byte[fileSize];
            fileType = file.Type;

            if (fileSize > 10 * 1024 * 1024) // 10MB limit
            {
                await _uiMessageService.Warn("File size exceeds the allowed limit of 10MB.");
                return;
            }

            try
            {
                using var stream = file.OpenReadStream(file.Size);
                using var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);

                fileBytes = memoryStream.ToArray();
                var base64Image = Convert.ToBase64String(fileBytes);

                EditingPerson.Image = base64Image; // Gán chuỗi Base64 vào EditingPerson.Image
                uploadComplete = true;
                isDataEntryChanged = true;

                await InvokeAsync(StateHasChanged);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }



        //Upload File 

        private List<TbFileUploadTempUpdateDto> tempFiles = new List<TbFileUploadTempUpdateDto>();

        private async Task HandleFileSelected(IBrowserFile file)
        {
            var currentUserId = TbUserList.FirstOrDefault(x => x.UserName == CurrentUser.UserName)?.Id;

            try
            {
                var maxFileSize = 10 * 1024 * 1024; // 10 MB
                var fileExtension = Path.GetExtension(file.Name).ToLower();
                var allowedExtensions = new[] { ".pdf" };

                // Kiểm tra loại tệp
                if (!allowedExtensions.Contains(fileExtension))
                {
                    await _uiMessageService.Error(L["Error:InvalidFileType"]);
                    return;
                }

                // Kiểm tra kích thước tệp
                if (file.Size > maxFileSize)
                {
                    var maxFileSizeMB = maxFileSize / (1024 * 1024); // Chuyển đổi kích thước tối đa sang MB
                    await _uiMessageService.Error(L["Error:FileSizeExceeded"]);
                    return;
                }

                var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                var fileNameWithoutExtension = $"{Path.GetFileNameWithoutExtension(file.Name)}_{timestamp}";
                var sanitizedFileName = $"{FileHelper.SanitizeFileName(fileNameWithoutExtension)}_{timestamp}{fileExtension}";
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Docs");

                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var filePath = Path.Combine(uploadsFolderPath, sanitizedFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                using (var stream = file.OpenReadStream(maxFileSize))
                {
                    await stream.CopyToAsync(fileStream).ConfigureAwait(false);
                }

                var fileUploadDto = new TbFileUploadTempUpdateDto
                {
                    companyId = EditingPerson.CompanyId,
                    personId = EditingPersonId,
                    fileName = sanitizedFileName,
                    fullFileName = file.Name,
                    fileLink = $"/Docs/{sanitizedFileName}",
                    uploadDate = DateTime.Now,
                    UserUpload = currentUserId,
                    note = null,
                    IsActive = true,
                    crt_date = DateTime.Now,
                    crt_user = currentUserId,
                    IsChanged = true,
                };

                EditingFileUpload.fullFileName = fileNameWithoutExtension;
                EditingFileUpload.fileName = sanitizedFileName;
                EditingFileUpload.fileLink = fileUploadDto.fileLink;
                EditingFileUpload.IsChanged = true;

                tempFiles.Add(fileUploadDto);
                isDataEntryChanged = true;
            }
            catch (Exception)
            {
                await _uiMessageService.Error(L["Error:FileUploadFailed"]);
            }

            await GetTbFileUploadListAsync();
            await InvokeAsync(StateHasChanged);
        }


        private async Task SaveFileAsync()
        {
            var currentUserId = TbUserList.FirstOrDefault(x => x.UserName == CurrentUser.UserName)?.Id;
            var tasks = new List<Task>();

            foreach (var tempFile in tempFiles.Where(x => x.IsChanged))
            {
                if (tempFile.Id == 0 && EditingFileUpload.Id == 0)
                {
                    // Xử lý thao tác INSERT
                    var createDto = ObjectMapper.Map<TbFileUploadTempUpdateDto, TbFileUploadTempCreateDto>(tempFile);
                    var fileUpload = await TbFileUploadTempsAppService.CreateAsync(createDto).ConfigureAwait(false);
                    tempFile.Id = fileUpload.Id;

                    tasks.Add(SaveEntityChanges(
                        tempFile.Id,
                        "INSERT",
                        null,
                        tempFile,
                        "tbFileUpload_Temp",
                        "Person"
                    ));

                    EditingFileUpload.fileName = null;
                    EditingFileUpload.fullFileName = null;
                    EditingFileUpload.fileLink = null;
                    EditingFileUpload.IsChanged = true;
                }
            }

            var tbFileUpload = TbFileUploadList.FirstOrDefault(x => x.personId == EditingPersonId);
            if (tbFileUpload != null && EditingFileUpload.Id != 0)
            {
                if (EditingFileUpload.IsChanged == true)
                {
                    var originalItem = await TbFileUploadsAppService.GetAsync(tbFileUpload.Id).ConfigureAwait(false);
                    var originalDto = ObjectMapper.Map<TbFileUploadDto, TbFileUploadUpdateDto>(originalItem);

                    var oldItem = new TbFileUploadUpdateDto
                    {
                        UserUpload = originalDto.UserUpload,
                        uploadDate = originalDto.uploadDate,
                        fullFileName = originalDto.fullFileName,
                        fileName = originalDto.fileName,
                        fileLink = originalDto.fileLink,
                        mod_date = originalDto.mod_date,
                        mod_user = originalDto.mod_user,
                    };

                    var newItem = new TbFileUploadUpdateDto
                    {
                        UserUpload = originalDto.UserUpload,
                        uploadDate = DateTime.Now,
                        fullFileName = EditingFileUpload.fullFileName,
                        fileName = EditingFileUpload.fileName,
                        fileLink = EditingFileUpload.fileLink,
                        mod_date = DateTime.Now,
                        mod_user = currentUserId,
                    };

                    tasks.Add(SaveEntityChanges(
                    originalDto.Id,
                    "UPDATE",
                    oldItem,
                    newItem,
                    "tbFileUpload",
                    "Person"
                ));
                }
            }

            // Chờ cho tất cả các tác vụ trong danh sách tasks hoàn thành
            await Task.WhenAll(tasks).ConfigureAwait(false);

            tempFiles.Clear();
            isDataEntryChanged = false;
            await InvokeAsync(StateHasChanged);
        }


        private async Task RemoveFileAsync()
        {
            var oldItem = TbFileUploadList.FirstOrDefault(x => x.personId == EditingPersonId);
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

                if (oldItem != null)
                {
                    var originalItem = await TbFileUploadsAppService.GetAsync(oldItem.Id).ConfigureAwait(false);
                    var originalDto = ObjectMapper.Map<TbFileUploadDto, TbFileUploadUpdateDto>(originalItem);

                    if (oldItem.Id != 0)
                    {
                        isDataEntryChanged = true;
                    }
                }

                // Xóa danh sách các file tạm
                tempFiles.Clear();
                EditingFileUpload.fileName = null;
                EditingFileUpload.fullFileName = null;
                EditingFileUpload.fileLink = null;
                EditingFileUpload.IsChanged = true;
                isDataEntryChanged = true;
                await _uiNotificationService.Success(L["Notification:Delete"]);
            }
            await InvokeAsync(StateHasChanged);
        }






        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         *                            SAVE - UPDATE       
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
                await _blockUiService.Block(selectors: "#lpx-content-container", busy: false);

                // Kiểm tra xem có thay đổi dữ liệu không
                if (!EditFormMain.EditContext.Validate())
                    return;

                if (isDataEntryChanged)
                {
                    TbPersonTempList = await TbPersonTempsAppService.GetListNoPagedAsync(new GetTbPersonTempsInput { });

                    if (EditingPersonId == 0)
                    {
                        // Lấy bản ghi cuối cùng trong TbPersonTemp
                        var lastPersonTemp = TbPersonTempList.LastOrDefault();

                        if (lastPersonTemp != null)
                        {
                            // Tăng từ mã cuối cùng
                            var lastCode = lastPersonTemp.Code;

                            if (!string.IsNullOrWhiteSpace(lastCode) && lastCode.Length > 1 && int.TryParse(lastCode.Substring(1), out var lastCodeNumber))
                            {
                                var newCodeNumber = lastCodeNumber + 1;
                                EditingPerson.Code = $"S{newCodeNumber}";
                            }
                            else
                            {
                                EditingPerson.Code = "S1";
                            }
                        }
                        else
                        {
                            EditingPerson.Code = "S1";
                        }

                        // Map dữ liệu từ EditingPerson sang TbPersonTempCreateDto
                        var personTempCreateDto = new TbPersonTempCreateDto
                        {
                            Code = EditingPerson.Code,
                            CompanyId = EditingPerson.CompanyId,
                            Address = EditingPerson.Address,
                            BirthDate = EditingPerson.BirthDate,
                            BirthPlace = EditingPerson.BirthPlace,
                            DocStatus = EditingPerson.DocStatus,
                            Email = EditingPerson.Email,
                            Ethnicity = EditingPerson.Ethnicity,
                            FullName = EditingPerson.FullName,
                            Gender = EditingPerson.Gender,
                            IDCardDate = EditingPerson.IDCardDate,
                            IdCardIssuePlace = EditingPerson.IdCardIssuePlace,
                            IDCardNo = EditingPerson.IDCardNo,
                            IsActive = EditingPerson.IsActive,
                            IsCheckRetirement = EditingPerson.IsCheckRetirement,
                            IsCheckTermEnd = EditingPerson.IsCheckTermEnd,
                            NationalityCode = EditingPerson.NationalityCode,
                            Religion = EditingPerson.Religion,
                            Phone = EditingPerson.Phone,
                            OldCode = EditingPerson.OldCode,
                            Note = EditingPerson.Note,
                            Image = EditingPerson.Image,
                            crt_date = DateTime.Now,
                            crt_user = EditingPerson.crt_user,
                        };

                        // Tạo mới EditingPersonTemp
                        var createdPersonTempDto = await TbPersonTempsAppService.CreateAsync(personTempCreateDto);
                        EditingPersonTemp = ObjectMapper.Map<TbPersonTempDto, TbPersonTempUpdateDto>(createdPersonTempDto);
                        EditingPersonTempId = EditingPersonTemp.Id;

                        // Ghi log thay đổi cho thao tác INSERT
                        await SaveEntityChanges(
                            EditingPersonTemp.Id,
                            "INSERT",
                            null,
                            personTempCreateDto,
                            "tbPerson_Temp",
                            "Person"
                        );

                        await SaveFileAsync();

                        EditingFileUploadTemp.fullFileName = null;
                        EditingFileUploadTemp.fileName = null;
                        EditingFileUploadTemp.fileLink = null;
                        uploadComplete = false;
                        isDataEntryChanged = false;

                        await _uiNotificationService.Success(L["Notification:Save"]);
                        await LoadDataAsync(EditingPersonId);
                    }
                    else
                    {
                        var originalItem = await TbPersonsAppService.GetAsync(EditingPersonId);
                        var originalDto = ObjectMapper.Map<TbPersonDto, TbPersonUpdateDto>(originalItem);

                        if (!FileHelper.ArePropertiesEqual(EditingPerson, originalDto) || EditingFileUpload.IsChanged == true)
                        {
                            await _blockUiService.Block(selectors: "#lpx-content-container", busy: false);

                            // Ghi log thay đổi cho thao tác UPDATE
                            await SaveEntityChanges(
                                EditingPersonId,
                                "UPDATE",
                                originalDto,
                                EditingPerson,
                                "tbPersons",
                                "Person"
                            );

                            await SaveFileAsync();
                            await LoadDataAsync(EditingPersonId);
                            await _uiNotificationService.Success(L["Notification:Edit"]);
                            await _blockUiService.UnBlock();
                        }
                        isDataEntryChanged = false;
                    }
                }

                await _blockUiService.UnBlock();
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
                "Code",
                "Image",
                "fileName",
                "FullName",
                "Gender",
                "Address",
                "BirthDate",
                "BirthPlace",
                "NationalityCode",
                "IDCardNo",
                "IDCardDate",
                "Religion",
                "Email",
                "Phone",
                "Ethnicity",
                "CompanyId",
                "Note",
                "IsCheckRetirement",
                "IsCheckTermEnd"
            };

            // Kiểm tra xem cột hiện tại có trong danh sách các cột được hiển thị không
            return visibleColumns.Contains(columnName);
        }

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
                    var isVisible = IsColumnVisible(field.Key); // Kiểm tra xem cột có được hiển thị không
                    var infoUpdate = CreateInfoUpdateDto(field.Key, null, field.Value, EditingPersonId, rowId, command, tableName, changeSetId, groupName, isVisible);
                    changes.Add(infoUpdate);
                }
            }
            else if (command == "UPDATE")
            {
                var originalValues = FileHelper.GetAllFieldValues(originalItem);
                var updatedValues = FileHelper.GetAllFieldValues(updatedItem);

                foreach (var field in originalValues.Keys)
                {
                    // Kiểm tra nếu dữ liệu có thay đổi
                    if (originalValues[field] != updatedValues[field])
                    {
                        // Xử lý trường hợp dữ liệu cũ là chuỗi rỗng và dữ liệu mới là null
                        var lastValue = originalValues[field];
                        var newValue = updatedValues[field];

                        // Nếu dữ liệu cũ là null và dữ liệu mới là chuỗi rỗng, thì không cần lưu
                        if (lastValue == null && newValue == "")
                        {
                            return;
                        }

                        var isVisible = IsColumnVisible(field); // Kiểm tra xem cột có được hiển thị không
                        var infoUpdate = CreateInfoUpdateDto(field, lastValue, newValue, EditingPersonId, rowId, command, tableName, changeSetId, groupName, isVisible);
                        changes.Add(infoUpdate);
                    }
                }
            }

            foreach (var change in changes)
            {
                await TbInfoUpdatesAppService.CreateAsync(change);
            }
        }

        private TbInfoUpdateCreateDto CreateInfoUpdateDto(string columnName, string? lastValue, string? newValue, int screenId, int rowId, string command, string tableName, Guid changeSetId, string? groupName, bool isVisible)
        {
            var currentUser = TbUserList.FirstOrDefault(x => x.UserName == CurrentUser.UserName);

            return new TbInfoUpdateCreateDto
            {
                ChangeSetId = changeSetId,
                TableName = tableName,
                ColumnName = columnName,
                ScreenName = "Persons",
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

    }
}

public class GenderItem
{
    public string Value { get; set; }
    public string DisplayName { get; set; }
}