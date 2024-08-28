using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbAdditionInfoTemps
{
    public partial interface ITbAdditionInfoTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbAdditionInfoTempDto>> GetListNoPagedAsync(GetTbAdditionInfoTempsInput input);

        //Write your custom code here...

    }
}