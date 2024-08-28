using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbInvests
{
    public partial interface ITbInvestsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbInvestDto>> GetListNoPagedAsync(GetTbInvestsInput input);

        //Write your custom code here...

    }
}