using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbHisLogPrintings
{
    public partial interface ITbHisLogPrintingsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbHisLogPrintingDto>> GetListNoPagedAsync(GetTbHisLogPrintingsInput input);

        //Write your custom code here...

    }
}