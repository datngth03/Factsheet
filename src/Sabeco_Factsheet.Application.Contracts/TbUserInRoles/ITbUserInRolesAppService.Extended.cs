using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbUserInRoles
{
    public partial interface ITbUserInRolesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbUserInRoleDto>> GetListNoPagedAsync(GetTbUserInRolesInput input);

        //Write your custom code here...

    }
}