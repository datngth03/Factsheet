using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyBoards
{
    public partial interface ITbCompanyBoardsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyBoardDto>> GetListNoPagedAsync(GetTbCompanyBoardsInput input);

        //Write your custom code here...

    }
}