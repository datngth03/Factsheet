using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyBranchs
{
    public partial interface ITbCompanyBranchsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyBranchDto>> GetListNoPagedAsync(GetTbCompanyBranchsInput input);

        //Write your custom code here...

    }
}