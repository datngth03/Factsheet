using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbPositions
{
    public partial interface ITbPositionsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbPositionDto>> GetListNoPagedAsync(GetTbPositionsInput input);

        //Write your custom code here...

    }
}