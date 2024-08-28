using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyBusinesses
{
    public partial interface ITbCompanyBusinessesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyBusinessDto>> GetListNoPagedAsync(GetTbCompanyBusinessesInput input);

        //Write your custom code here...

    }
}