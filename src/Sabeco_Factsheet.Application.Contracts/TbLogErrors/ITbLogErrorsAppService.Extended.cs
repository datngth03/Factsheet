using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbLogErrors
{
    public partial interface ITbLogErrorsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbLogErrorDto>> GetListNoPagedAsync(GetTbLogErrorsInput input);

        //Write your custom code here...

    }
}