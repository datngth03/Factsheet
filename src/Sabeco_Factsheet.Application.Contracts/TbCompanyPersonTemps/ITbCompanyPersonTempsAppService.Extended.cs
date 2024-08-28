using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyPersonTemps
{
    public partial interface ITbCompanyPersonTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyPersonTempDto>> GetListNoPagedAsync(GetTbCompanyPersonTempsInput input);

        //Write your custom code here...

    }
}