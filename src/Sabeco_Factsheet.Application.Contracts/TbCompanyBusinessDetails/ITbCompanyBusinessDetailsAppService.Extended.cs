using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyBusinessDetails
{
    public partial interface ITbCompanyBusinessDetailsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyBusinessDetailDto>> GetListNoPagedAsync(GetTbCompanyBusinessDetailsInput input);

        //Write your custom code here...

    }
}