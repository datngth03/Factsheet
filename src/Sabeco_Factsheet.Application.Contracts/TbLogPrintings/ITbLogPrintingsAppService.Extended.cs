using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbLogPrintings
{
    public partial interface ITbLogPrintingsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbLogPrintingDto>> GetListNoPagedAsync(GetTbLogPrintingsInput input);

        //Write your custom code here...

    }
}