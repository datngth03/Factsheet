using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbLogSendEmailRetirements
{
    public partial interface ITbLogSendEmailRetirementsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbLogSendEmailRetirementDto>> GetListNoPagedAsync(GetTbLogSendEmailRetirementsInput input);

        //Write your custom code here...

    }
}