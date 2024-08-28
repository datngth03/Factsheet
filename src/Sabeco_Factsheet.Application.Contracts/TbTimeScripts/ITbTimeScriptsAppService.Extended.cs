using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbTimeScripts
{
    public partial interface ITbTimeScriptsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbTimeScriptDto>> GetListNoPagedAsync(GetTbTimeScriptsInput input);

        //Write your custom code here...

    }
}