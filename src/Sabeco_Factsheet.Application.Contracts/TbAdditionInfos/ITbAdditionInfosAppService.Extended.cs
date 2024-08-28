using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbAdditionInfos
{
    public partial interface ITbAdditionInfosAppService
    {
        //HQSOFT's generated code:
        Task<List<TbAdditionInfoDto>> GetListNoPagedAsync(GetTbAdditionInfosInput input);

        //Write your custom code here...

    }
}