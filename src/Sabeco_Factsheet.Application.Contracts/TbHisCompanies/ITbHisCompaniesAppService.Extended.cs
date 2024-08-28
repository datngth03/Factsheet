using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbHisCompanies
{
    public partial interface ITbHisCompaniesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbHisCompanyDto>> GetListNoPagedAsync(GetTbHisCompaniesInput input);

        //Write your custom code here...

    }
}