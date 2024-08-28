using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbLandInfoTemps
{
    public partial interface ITbLandInfoTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbLandInfoTempDto>> GetListNoPagedAsync(GetTbLandInfoTempsInput input);

        //Write your custom code here...

    }
}