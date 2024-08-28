using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbLogSyncUats
{
    public partial interface ITbLogSyncUatsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbLogSyncUatDto>> GetListNoPagedAsync(GetTbLogSyncUatsInput input);

        //Write your custom code here...

    }
}