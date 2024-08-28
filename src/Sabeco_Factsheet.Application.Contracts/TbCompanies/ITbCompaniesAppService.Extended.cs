using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanies
{
    public partial interface ITbCompaniesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyDto>> GetListNoPagedAsync(GetTbCompaniesInput input);

        //Write your custom code here...

    }
}