using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbUserMappingPersons
{
    public abstract class TbUserMappingPersonManagerBase : DomainService
    {
        public ITbUserMappingPersonRepository _tbUserMappingPersonRepository;

        public TbUserMappingPersonManagerBase(ITbUserMappingPersonRepository tbUserMappingPersonRepository)
        {
            _tbUserMappingPersonRepository = tbUserMappingPersonRepository;
        }

        public virtual async Task<TbUserMappingPerson> CreateAsync(
        int? userid = null, int? personid = null, bool? isActive = null)
        {

            var tbUserMappingPerson = new TbUserMappingPerson(

             userid, personid, isActive
             );

            return await _tbUserMappingPersonRepository.InsertAsync(tbUserMappingPerson);
        }

        public virtual async Task<TbUserMappingPerson> UpdateAsync(
            int id,
            int? userid = null, int? personid = null, bool? isActive = null
        )
        {

            var tbUserMappingPerson = await _tbUserMappingPersonRepository.GetAsync(id);

            tbUserMappingPerson.userid = userid;
            tbUserMappingPerson.personid = personid;
            tbUserMappingPerson.IsActive = isActive;

            return await _tbUserMappingPersonRepository.UpdateAsync(tbUserMappingPerson);
        }

    }
}