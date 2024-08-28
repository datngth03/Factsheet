using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbLogSendEmails
{
    public partial interface ITbLogSendEmailsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbLogSendEmailDto>> GetListNoPagedAsync(GetTbLogSendEmailsInput input);

        //Write your custom code here...

    }
}