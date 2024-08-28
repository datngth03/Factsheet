using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbPersons
{
    public partial interface ITbPersonsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbPersonDto>> GetListNoPagedAsync(GetTbPersonsInput input);

        //Write your custom code here...

    }
}