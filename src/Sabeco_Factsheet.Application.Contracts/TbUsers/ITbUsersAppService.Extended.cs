using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbUsers
{
    public partial interface ITbUsersAppService
    {
        //HQSOFT's generated code:
        Task<List<TbUserDto>> GetListNoPagedAsync(GetTbUsersInput input);

        //Write your custom code here...

        Task<List<TbUserDto>> GetListByAbpUserId(Guid? abpUserId);

        Task<TbUserDto?> GetByAbpUserIdAsync(Guid? abpUserId);
    }
}