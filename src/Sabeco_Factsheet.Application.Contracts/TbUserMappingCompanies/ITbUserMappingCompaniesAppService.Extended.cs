using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbUserMappingCompanies
{
    public partial interface ITbUserMappingCompaniesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbUserMappingCompanyDto>> GetListNoPagedAsync(GetTbUserMappingCompaniesInput input);

        //Write your custom code here...

    }
}