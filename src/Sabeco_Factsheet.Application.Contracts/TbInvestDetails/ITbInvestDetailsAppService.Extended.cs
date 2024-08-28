using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbInvestDetails
{
    public partial interface ITbInvestDetailsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbInvestDetailDto>> GetListNoPagedAsync(GetTbInvestDetailsInput input);

        //Write your custom code here...

    }
}