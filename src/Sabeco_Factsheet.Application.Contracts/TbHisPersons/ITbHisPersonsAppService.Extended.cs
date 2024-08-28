using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbHisPersons
{
    public partial interface ITbHisPersonsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbHisPersonDto>> GetListNoPagedAsync(GetTbHisPersonsInput input);

        //Write your custom code here...

    }
}