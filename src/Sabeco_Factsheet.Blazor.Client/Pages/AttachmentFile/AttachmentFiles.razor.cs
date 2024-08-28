using Microsoft.AspNetCore.Components.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Sabeco_Factsheet.TbUsers;
using Sabeco_Factsheet.TbFileUploads;
using Sabeco_Factsheet.TbFileUploadTemps;
using Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps;
using System.Linq;
using System.Text.RegularExpressions;
using Sabeco_Factsheet.Blazor.Client.Pages.Person;
using System.ComponentModel.Design;
using Microsoft.JSInterop;

namespace Sabeco_Factsheet.Blazor.Client.Pages.AttachmentFile
{
    public partial class AttachmentFiles
    {

        [Parameter]
        public int? companyId { get; set; }

        [Parameter]
        public int? personId { get; set; }

        [Parameter]
        public bool isPersonScreen { get; set; }

        [Parameter]
        public string? fileName { get; set; }

        public int fileId { get; set; }

        private string? filePath;
        private InputFile fileInput;


        private List<TbUserDto> TbUserList = new List<TbUserDto> { };

        private List<TbFileUploadDto> TbFileUploadList = new List<TbFileUploadDto> { };
        private List<TbFileUploadTempDto> TbFileUploadTempList { get; set; } = new List<TbFileUploadTempDto>();
        public List<TbFileUploadTempUpdateDto> TbFileUploadTempUpdateList { get; set; } = new List<TbFileUploadTempUpdateDto>();

        public AttachmentFiles()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            await GetUserListAsync();
            await GetTbFileUploadListAsync();
            await GetTbFileUploadTempListAsync();
            await base.OnInitializedAsync();
        }

        private async Task GetUserListAsync()
        {
            TbUserList = await TbUsersAppService.GetListNoPagedAsync(new GetTbUsersInput { });
        }

        private async Task GetTbFileUploadListAsync()
        {
            TbFileUploadList = await TbFileUploadsAppService.GetListNoPagedAsync(new GetTbFileUploadsInput { });
        }

        private async Task GetTbFileUploadTempListAsync()
        {
            TbFileUploadTempList = await TbFileUploadTempsAppService.GetListNoPagedAsync(new GetTbFileUploadTempsInput { });

            var fileUpload = TbFileUploadTempList.FirstOrDefault(x => (x.personId == personId || x.companyId == companyId) ||
                                                                        (x.personId == personId && x.companyId == companyId));
            if (fileUpload != null)
            {
                fileId = fileUpload.Id;
                fileName = fileUpload?.fileName;
            } 
        }

        private async Task DeleteFile(int fileId)
        {
            var confirmed = await _uiMessageService.Confirm(L["DeleteConfirmationMessage"]);
            if (confirmed)
            {
                await TbFileUploadTempsAppService.DeleteAsync(fileId);
            }

            fileName = null;
            await GetTbFileUploadTempListAsync();
            await InvokeAsync(StateHasChanged);
        }
        
        private async Task HandleFileSelected(InputFileChangeEventArgs e)
        {
            var currentUserId = TbUserList.FirstOrDefault(x => x.UserName == CurrentUser.UserName)?.Id;

            var files = e.GetMultipleFiles();
            foreach (var file in files)
            {
                try
                {
                    if (isPersonScreen && file.ContentType != "application/pdf")
                    {
                        await _uiMessageService.Warn(L["Chỉ được phép tải lên tệp PDF trên màn hình Person."]); 
                        continue; // Bỏ qua tệp không phải PDF
                    }

                    var maxFileSize = 10 * 1024 * 1024; // 10 MB
                    var fileExtension = Path.GetExtension(file.Name);
                    var sanitizedFileName = SanitizeFileName(Path.GetFileNameWithoutExtension(file.Name)) + fileExtension;
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
                        companyId = companyId > 0 ? companyId : 0,
                        personId = personId > 0 ? personId : (int?)null,
                        fileName = sanitizedFileName,
                        fullFileName = file.Name,
                        fileLink = $"/Docs/{sanitizedFileName}",
                        uploadDate = DateTime.Now,
                        UserUpload = currentUserId,
                        note = "",
                        IsActive = true,
                        crt_date = DateTime.Now,
                        crt_user = currentUserId,
                    };

                    var createDto = ObjectMapper.Map<TbFileUploadTempUpdateDto, TbFileUploadTempCreateDto>(fileUploadDto);
                    await TbFileUploadTempsAppService.CreateAsync(createDto);
                    await GetTbFileUploadTempListAsync();

                    await InvokeAsync(StateHasChanged);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }

        private string SanitizeFileName(string fileName)
        {
            // Loại bỏ ký tự không hợp lệ
            var invalidChars = Path.GetInvalidFileNameChars();
            var sanitizedFileName = new string(fileName
                .Where(ch => !invalidChars.Contains(ch) && !char.IsWhiteSpace(ch))
                .ToArray());

            // Thay thế ký tự đặc biệt bằng dấu gạch dưới
            sanitizedFileName = Regex.Replace(sanitizedFileName, @"[^a-zA-Z0-9]", "_");

            return sanitizedFileName;
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

    }
}
