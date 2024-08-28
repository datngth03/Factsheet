using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbLogLogins
{
    public partial interface ITbLogLoginsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbLogLoginDto>> GetListNoPagedAsync(GetTbLogLoginsInput input);

        //Write your custom code here...

    }
}