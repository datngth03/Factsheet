using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbMenus
{
    public abstract class TbMenuManagerBase : DomainService
    {
        public ITbMenuRepository _tbMenuRepository;

        public TbMenuManagerBase(ITbMenuRepository tbMenuRepository)
        {
            _tbMenuRepository = tbMenuRepository;
        }

        public virtual async Task<TbMenu> CreateAsync(
        string controlName, string description, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {
            Check.NotNullOrWhiteSpace(controlName, nameof(controlName));
            Check.Length(controlName, nameof(controlName), TbMenuConsts.ControlNameMaxLength);
            Check.NotNullOrWhiteSpace(description, nameof(description));
            Check.Length(description, nameof(description), TbMenuConsts.DescriptionMaxLength);

            var tbMenu = new TbMenu(

             controlName, description, isActive, create_user, create_date, mod_user, mod_date
             );

            return await _tbMenuRepository.InsertAsync(tbMenu);
        }

        public virtual async Task<TbMenu> UpdateAsync(
            int id,
            string controlName, string description, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {
            Check.NotNullOrWhiteSpace(controlName, nameof(controlName));
            Check.Length(controlName, nameof(controlName), TbMenuConsts.ControlNameMaxLength);
            Check.NotNullOrWhiteSpace(description, nameof(description));
            Check.Length(description, nameof(description), TbMenuConsts.DescriptionMaxLength);

            var tbMenu = await _tbMenuRepository.GetAsync(id);

            tbMenu.ControlName = controlName;
            tbMenu.Description = description;
            tbMenu.IsActive = isActive;
            tbMenu.create_user = create_user;
            tbMenu.create_date = create_date;
            tbMenu.mod_user = mod_user;
            tbMenu.mod_date = mod_date;

            return await _tbMenuRepository.UpdateAsync(tbMenu);
        }

    }
}