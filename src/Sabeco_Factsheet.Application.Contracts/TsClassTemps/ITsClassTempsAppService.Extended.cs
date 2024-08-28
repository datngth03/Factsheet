using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TsClassTemps
{
    public partial interface ITsClassTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TsClassTempDto>> GetListNoPagedAsync(GetTsClassTempsInput input);

        //Write your custom code here...

    }
}