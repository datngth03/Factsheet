using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyBranchImages
{
    public partial interface ITbCompanyBranchImagesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyBranchImageDto>> GetListNoPagedAsync(GetTbCompanyBranchImagesInput input);

        //Write your custom code here...

    }
}