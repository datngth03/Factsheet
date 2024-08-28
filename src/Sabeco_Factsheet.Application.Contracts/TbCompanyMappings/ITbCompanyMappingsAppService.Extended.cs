using Sabeco_Factsheet.TbCompanyPersons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyMappings
{
    public partial interface ITbCompanyMappingsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyMappingDto>> GetListNoPagedAsync(GetTbCompanyMappingsInput input);

        //Write your custom code here...

        Task<List<TbCompanyMappingDto>> GetListByCompanyId(int id);
    }
}