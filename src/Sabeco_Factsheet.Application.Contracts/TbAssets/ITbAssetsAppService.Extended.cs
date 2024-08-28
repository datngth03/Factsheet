using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbAssets
{
    public partial interface ITbAssetsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbAssetDto>> GetListNoPagedAsync(GetTbAssetsInput input);

        //Write your custom code here...

    }
}