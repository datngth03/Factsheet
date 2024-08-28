using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbPositions
{
    public abstract class TbPositionManagerBase : DomainService
    {
        public ITbPositionRepository _tbPositionRepository;

        public TbPositionManagerBase(ITbPositionRepository tbPositionRepository)
        {
            _tbPositionRepository = tbPositionRepository;
        }

        public virtual async Task<TbPosition> CreateAsync(
        string code, string name, string name_EN, bool isActive, bool isDeleted, byte? positionType = null, int? crt_user = null, DateTime? ctr_date = null, int? mod_user = null, DateTime? mod_date = null, int? orderNumb = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbPositionConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), TbPositionConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(name_EN, nameof(name_EN));
            Check.Length(name_EN, nameof(name_EN), TbPositionConsts.Name_ENMaxLength);

            var tbPosition = new TbPosition(

             code, name, name_EN, isActive, isDeleted, positionType, crt_user, ctr_date, mod_user, mod_date, orderNumb
             );

            return await _tbPositionRepository.InsertAsync(tbPosition);
        }

        public virtual async Task<TbPosition> UpdateAsync(
            int id,
            string code, string name, string name_EN, bool isActive, bool isDeleted, byte? positionType = null, int? crt_user = null, DateTime? ctr_date = null, int? mod_user = null, DateTime? mod_date = null, int? orderNumb = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbPositionConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), TbPositionConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(name_EN, nameof(name_EN));
            Check.Length(name_EN, nameof(name_EN), TbPositionConsts.Name_ENMaxLength);

            var tbPosition = await _tbPositionRepository.GetAsync(id);

            tbPosition.Code = code;
            tbPosition.Name = name;
            tbPosition.Name_EN = name_EN;
            tbPosition.IsActive = isActive;
            tbPosition.IsDeleted = isDeleted;
            tbPosition.PositionType = positionType;
            tbPosition.crt_user = crt_user;
            tbPosition.ctr_date = ctr_date;
            tbPosition.mod_user = mod_user;
            tbPosition.mod_date = mod_date;
            tbPosition.OrderNumb = orderNumb;

            return await _tbPositionRepository.UpdateAsync(tbPosition);
        }

    }
}