using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbLandInfos
{
    public partial interface ITbLandInfosAppService
    {
        //HQSOFT's generated code:
        Task<List<TbLandInfoDto>> GetListNoPagedAsync(GetTbLandInfosInput input);

        //Write your custom code here...

    }
}