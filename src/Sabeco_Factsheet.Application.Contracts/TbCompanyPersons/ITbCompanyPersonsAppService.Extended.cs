using Sabeco_Factsheet.TbBrewerySkus;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyPersons
{
    public partial interface ITbCompanyPersonsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyPersonDto>> GetListNoPagedAsync(GetTbCompanyPersonsInput input);

        //Write your custom code here...
         
        Task<List<TbCompanyPersonDto>> GetListByCompanyId(int id);
    }
}