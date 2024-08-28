using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbBranchs
{
    public partial interface ITbBranchsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbBranchDto>> GetListNoPagedAsync(GetTbBranchsInput input);

        //Write your custom code here...

    }
}