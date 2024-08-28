using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyInvests
{
    public partial interface ITbCompanyInvestsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyInvestDto>> GetListNoPagedAsync(GetTbCompanyInvestsInput input);

        //Write your custom code here...

    }
}