using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbMenus
{
    public partial interface ITbMenusAppService
    {
        //HQSOFT's generated code:
        Task<List<TbMenuDto>> GetListNoPagedAsync(GetTbMenusInput input);

        //Write your custom code here...

    }
}