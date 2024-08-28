using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbPersonTemps
{
    public partial interface ITbPersonTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbPersonTempDto>> GetListNoPagedAsync(GetTbPersonTempsInput input);

        //Write your custom code here...

    }
}