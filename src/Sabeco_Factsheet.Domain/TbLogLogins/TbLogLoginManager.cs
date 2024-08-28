using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbLogLogins
{
    public abstract class TbLogLoginManagerBase : DomainService
    {
        public ITbLogLoginRepository _tbLogLoginRepository;

        public TbLogLoginManagerBase(ITbLogLoginRepository tbLogLoginRepository)
        {
            _tbLogLoginRepository = tbLogLoginRepository;
        }

        public virtual async Task<TbLogLogin> CreateAsync(
        string iPTracking, string? userName = null, DateTime? loginDate = null, bool? statusLogin = null)
        {
            Check.NotNullOrWhiteSpace(iPTracking, nameof(iPTracking));

            var tbLogLogin = new TbLogLogin(

             iPTracking, userName, loginDate, statusLogin
             );

            return await _tbLogLoginRepository.InsertAsync(tbLogLogin);
        }

        public virtual async Task<TbLogLogin> UpdateAsync(
            int id,
            string iPTracking, string? userName = null, DateTime? loginDate = null, bool? statusLogin = null
        )
        {
            Check.NotNullOrWhiteSpace(iPTracking, nameof(iPTracking));

            var tbLogLogin = await _tbLogLoginRepository.GetAsync(id);

            tbLogLogin.IPTracking = iPTracking;
            tbLogLogin.UserName = userName;
            tbLogLogin.LoginDate = loginDate;
            tbLogLogin.StatusLogin = statusLogin;

            return await _tbLogLoginRepository.UpdateAsync(tbLogLogin);
        }

    }
}