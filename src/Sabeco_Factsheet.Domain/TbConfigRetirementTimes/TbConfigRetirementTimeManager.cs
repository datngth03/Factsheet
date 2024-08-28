using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbConfigRetirementTimes
{
    public abstract class TbConfigRetirementTimeManagerBase : DomainService
    {
        public ITbConfigRetirementTimeRepository _tbConfigRetirementTimeRepository;

        public TbConfigRetirementTimeManagerBase(ITbConfigRetirementTimeRepository tbConfigRetirementTimeRepository)
        {
            _tbConfigRetirementTimeRepository = tbConfigRetirementTimeRepository;
        }

        public virtual async Task<TbConfigRetirementTime> CreateAsync(
        string? code = null, int? yearNumb = null, int? monthNumb = null, int? dayNumb = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            var tbConfigRetirementTime = new TbConfigRetirementTime(

             code, yearNumb, monthNumb, dayNumb, note, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbConfigRetirementTimeRepository.InsertAsync(tbConfigRetirementTime);
        }

        public virtual async Task<TbConfigRetirementTime> UpdateAsync(
            int id,
            string? code = null, int? yearNumb = null, int? monthNumb = null, int? dayNumb = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {

            var tbConfigRetirementTime = await _tbConfigRetirementTimeRepository.GetAsync(id);

            tbConfigRetirementTime.Code = code;
            tbConfigRetirementTime.YearNumb = yearNumb;
            tbConfigRetirementTime.MonthNumb = monthNumb;
            tbConfigRetirementTime.DayNumb = dayNumb;
            tbConfigRetirementTime.Note = note;
            tbConfigRetirementTime.crt_date = crt_date;
            tbConfigRetirementTime.crt_user = crt_user;
            tbConfigRetirementTime.mod_date = mod_date;
            tbConfigRetirementTime.mod_user = mod_user;

            return await _tbConfigRetirementTimeRepository.UpdateAsync(tbConfigRetirementTime);
        }

    }
}