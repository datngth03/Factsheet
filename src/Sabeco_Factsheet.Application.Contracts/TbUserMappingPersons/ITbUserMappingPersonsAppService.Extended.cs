using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbUserMappingPersons
{
    public partial interface ITbUserMappingPersonsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbUserMappingPersonDto>> GetListNoPagedAsync(GetTbUserMappingPersonsInput input);

        //Write your custom code here...

    }
}