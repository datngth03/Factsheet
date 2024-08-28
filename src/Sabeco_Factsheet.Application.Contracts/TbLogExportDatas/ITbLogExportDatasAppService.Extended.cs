using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbLogExportDatas
{
    public partial interface ITbLogExportDatasAppService
    {
        //HQSOFT's generated code:
        Task<List<TbLogExportDataDto>> GetListNoPagedAsync(GetTbLogExportDatasInput input);

        //Write your custom code here...

    }
}