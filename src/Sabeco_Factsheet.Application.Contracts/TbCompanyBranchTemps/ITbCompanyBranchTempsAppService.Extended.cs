using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyBranchTemps
{
    public partial interface ITbCompanyBranchTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyBranchTempDto>> GetListNoPagedAsync(GetTbCompanyBranchTempsInput input);

        //Write your custom code here...

    }
}