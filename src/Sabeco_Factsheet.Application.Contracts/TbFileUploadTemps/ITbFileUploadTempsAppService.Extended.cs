using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbFileUploadTemps
{
    public partial interface ITbFileUploadTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbFileUploadTempDto>> GetListNoPagedAsync(GetTbFileUploadTempsInput input);

        //Write your custom code here...

    }
}