using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyInvestTemps
{
    public partial interface ITbCompanyInvestTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyInvestTempDto>> GetListNoPagedAsync(GetTbCompanyInvestTempsInput input);

        //Write your custom code here...

    }
}