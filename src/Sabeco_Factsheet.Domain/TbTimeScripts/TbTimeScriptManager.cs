using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbTimeScripts
{
    public abstract class TbTimeScriptManagerBase : DomainService
    {
        public ITbTimeScriptRepository _tbTimeScriptRepository;

        public TbTimeScriptManagerBase(ITbTimeScriptRepository tbTimeScriptRepository)
        {
            _tbTimeScriptRepository = tbTimeScriptRepository;
        }

        public virtual async Task<TbTimeScript> CreateAsync(
        string? code = null, int? year = null, int? month = null, int? day = null, int? hour = null, int? minute = null, int? second = null)
        {
            Check.Length(code, nameof(code), TbTimeScriptConsts.CodeMaxLength);

            var tbTimeScript = new TbTimeScript(

             code, year, month, day, hour, minute, second
             );

            return await _tbTimeScriptRepository.InsertAsync(tbTimeScript);
        }

        public virtual async Task<TbTimeScript> UpdateAsync(
            int id,
            string? code = null, int? year = null, int? month = null, int? day = null, int? hour = null, int? minute = null, int? second = null
        )
        {
            Check.Length(code, nameof(code), TbTimeScriptConsts.CodeMaxLength);

            var tbTimeScript = await _tbTimeScriptRepository.GetAsync(id);

            tbTimeScript.Code = code;
            tbTimeScript.Year = year;
            tbTimeScript.Month = month;
            tbTimeScript.Day = day;
            tbTimeScript.Hour = hour;
            tbTimeScript.Minute = minute;
            tbTimeScript.Second = second;

            return await _tbTimeScriptRepository.UpdateAsync(tbTimeScript);
        }

    }
}