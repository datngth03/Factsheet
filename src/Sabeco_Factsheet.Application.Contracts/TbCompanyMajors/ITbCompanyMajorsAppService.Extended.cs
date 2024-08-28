using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyMajors
{
    public partial interface ITbCompanyMajorsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyMajorDto>> GetListNoPagedAsync(GetTbCompanyMajorsInput input);

        //Write your custom code here...

    }
}