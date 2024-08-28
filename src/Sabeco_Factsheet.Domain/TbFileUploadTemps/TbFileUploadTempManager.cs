using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbFileUploadTemps
{
    public abstract class TbFileUploadTempManagerBase : DomainService
    {
        public ITbFileUploadTempRepository _tbFileUploadTempRepository;

        public TbFileUploadTempManagerBase(ITbFileUploadTempRepository tbFileUploadTempRepository)
        {
            _tbFileUploadTempRepository = tbFileUploadTempRepository;
        }

        public virtual async Task<TbFileUploadTemp> CreateAsync(
        int downloadCount, int? companyId = null, int? personId = null, string? fileName = null, string? fullFileName = null, string? fileLink = null, DateTime? uploadDate = null, int? userUpload = null, string? note = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            var tbFileUploadTemp = new TbFileUploadTemp(

             downloadCount, companyId, personId, fileName, fullFileName, fileLink, uploadDate, userUpload, note, isActive, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbFileUploadTempRepository.InsertAsync(tbFileUploadTemp);
        }

        public virtual async Task<TbFileUploadTemp> UpdateAsync(
            int id,
            int? companyId = null, int? personId = null, string? fileName = null, string? fullFileName = null, string? fileLink = null, DateTime? uploadDate = null, int? userUpload = null, string? note = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {

            var tbFileUploadTemp = await _tbFileUploadTempRepository.GetAsync(id);

            tbFileUploadTemp.companyId = companyId;
            tbFileUploadTemp.personId = personId;
            tbFileUploadTemp.fileName = fileName;
            tbFileUploadTemp.fullFileName = fullFileName;
            tbFileUploadTemp.fileLink = fileLink;
            tbFileUploadTemp.uploadDate = uploadDate;
            tbFileUploadTemp.UserUpload = userUpload;
            tbFileUploadTemp.note = note;
            tbFileUploadTemp.IsActive = isActive;
            tbFileUploadTemp.crt_date = crt_date;
            tbFileUploadTemp.crt_user = crt_user;
            tbFileUploadTemp.mod_date = mod_date;
            tbFileUploadTemp.mod_user = mod_user;

            return await _tbFileUploadTempRepository.UpdateAsync(tbFileUploadTemp);
        }

    }
}