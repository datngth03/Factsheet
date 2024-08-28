using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbLogRefeshAccounts
{
    public partial interface ITbLogRefeshAccountsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbLogRefeshAccountDto>> GetListNoPagedAsync(GetTbLogRefeshAccountsInput input);

        //Write your custom code here...

    }
}