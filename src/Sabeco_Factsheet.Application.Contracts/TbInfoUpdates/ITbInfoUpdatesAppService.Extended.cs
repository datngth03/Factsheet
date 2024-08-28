using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbInfoUpdates
{
    public partial interface ITbInfoUpdatesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbInfoUpdateDto>> GetListNoPagedAsync(GetTbInfoUpdatesInput input);

        //Write your custom code here...

    }
}