using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbHisCompanyPersons
{
    public partial interface ITbHisCompanyPersonsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbHisCompanyPersonDto>> GetListNoPagedAsync(GetTbHisCompanyPersonsInput input);

        //Write your custom code here...

    }
}