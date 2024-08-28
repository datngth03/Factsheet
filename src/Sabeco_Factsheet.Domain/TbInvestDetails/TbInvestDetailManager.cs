using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbInvestDetails
{
    public abstract class TbInvestDetailManagerBase : DomainService
    {
        public ITbInvestDetailRepository _tbInvestDetailRepository;

        public TbInvestDetailManagerBase(ITbInvestDetailRepository tbInvestDetailRepository)
        {
            _tbInvestDetailRepository = tbInvestDetailRepository;
        }

        public virtual async Task<TbInvestDetail> CreateAsync(
        int parentId, int investType, bool isDeleted, DateTime? docDate = null, string? docNo = null, int? shareNum = null, decimal? shareValue = null, string? note = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {
            Check.Length(docNo, nameof(docNo), TbInvestDetailConsts.DocNoMaxLength);
            Check.Length(note, nameof(note), TbInvestDetailConsts.NoteMaxLength);

            var tbInvestDetail = new TbInvestDetail(

             parentId, investType, isDeleted, docDate, docNo, shareNum, shareValue, note, isActive, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbInvestDetailRepository.InsertAsync(tbInvestDetail);
        }

        public virtual async Task<TbInvestDetail> UpdateAsync(
            int id,
            int parentId, int investType, bool isDeleted, DateTime? docDate = null, string? docNo = null, int? shareNum = null, decimal? shareValue = null, string? note = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {
            Check.Length(docNo, nameof(docNo), TbInvestDetailConsts.DocNoMaxLength);
            Check.Length(note, nameof(note), TbInvestDetailConsts.NoteMaxLength);

            var tbInvestDetail = await _tbInvestDetailRepository.GetAsync(id);

            tbInvestDetail.ParentId = parentId;
            tbInvestDetail.InvestType = investType;
            tbInvestDetail.IsDeleted = isDeleted;
            tbInvestDetail.DocDate = docDate;
            tbInvestDetail.DocNo = docNo;
            tbInvestDetail.ShareNum = shareNum;
            tbInvestDetail.ShareValue = shareValue;
            tbInvestDetail.Note = note;
            tbInvestDetail.IsActive = isActive;
            tbInvestDetail.crt_date = crt_date;
            tbInvestDetail.crt_user = crt_user;
            tbInvestDetail.mod_date = mod_date;
            tbInvestDetail.mod_user = mod_user;

            return await _tbInvestDetailRepository.UpdateAsync(tbInvestDetail);
        }

    }
}