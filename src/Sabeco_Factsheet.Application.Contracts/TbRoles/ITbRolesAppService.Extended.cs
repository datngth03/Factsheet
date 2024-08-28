using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbRoles
{
    public partial interface ITbRolesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbRoleDto>> GetListNoPagedAsync(GetTbRolesInput input);

        //Write your custom code here...

    }
}