using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbFileUploads
{
    public partial interface ITbFileUploadsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbFileUploadDto>> GetListNoPagedAsync(GetTbFileUploadsInput input);

        //Write your custom code here...

    }
}