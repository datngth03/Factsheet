using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyMajorTemps
{
    public partial interface ITbCompanyMajorTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyMajorTempDto>> GetListNoPagedAsync(GetTbCompanyMajorTempsInput input);

        //Write your custom code here...

    }
}