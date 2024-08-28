using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbContactTemps
{
    public partial interface ITbContactTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbContactTempDto>> GetListNoPagedAsync(GetTbContactTempsInput input);

        //Write your custom code here...

    }
}