using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbInvestPersons
{
    public partial interface ITbInvestPersonsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbInvestPersonDto>> GetListNoPagedAsync(GetTbInvestPersonsInput input);

        //Write your custom code here...

    }
}