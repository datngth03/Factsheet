using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbContacts
{
    public partial interface ITbContactsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbContactDto>> GetListNoPagedAsync(GetTbContactsInput input);

        //Write your custom code here...

    }
}