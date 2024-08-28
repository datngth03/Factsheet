using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbFileUploads
{
    public abstract class TbFileUploadManagerBase : DomainService
    {
        public ITbFileUploadRepository _tbFileUploadRepository;

        public TbFileUploadManagerBase(ITbFileUploadRepository tbFileUploadRepository)
        {
            _tbFileUploadRepository = tbFileUploadRepository;
        }

        public virtual async Task<TbFileUpload> CreateAsync(
        int downloadCount, int? companyId = null, int? personId = null, string? fileName = null, string? fullFileName = null, string? fileLink = null, DateTime? uploadDate = null, int? userUpload = null, string? note = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            var tbFileUpload = new TbFileUpload(

             downloadCount, companyId, personId, fileName, fullFileName, fileLink, uploadDate, userUpload, note, isActive, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbFileUploadRepository.InsertAsync(tbFileUpload);
        }

        public virtual async Task<TbFileUpload> UpdateAsync(
            int id,
            int downloadCount, int? companyId = null, int? personId = null, string? fileName = null, string? fullFileName = null, string? fileLink = null, DateTime? uploadDate = null, int? userUpload = null, string? note = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {

            var tbFileUpload = await _tbFileUploadRepository.GetAsync(id);

            tbFileUpload.DownloadCount = downloadCount;
            tbFileUpload.companyId = companyId;
            tbFileUpload.personId = personId;
            tbFileUpload.fileName = fileName;
            tbFileUpload.fullFileName = fullFileName;
            tbFileUpload.fileLink = fileLink;
            tbFileUpload.uploadDate = uploadDate;
            tbFileUpload.UserUpload = userUpload;
            tbFileUpload.note = note;
            tbFileUpload.IsActive = isActive;
            tbFileUpload.crt_date = crt_date;
            tbFileUpload.crt_user = crt_user;
            tbFileUpload.mod_date = mod_date;
            tbFileUpload.mod_user = mod_user;

            return await _tbFileUploadRepository.UpdateAsync(tbFileUpload);
        }

    }
}