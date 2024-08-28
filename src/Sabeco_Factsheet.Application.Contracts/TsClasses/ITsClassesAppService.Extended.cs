using Sabeco_Factsheet.TbCompanyPersons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TsClasses
{
    public partial interface ITsClassesAppService
    {
        //HQSOFT's generated code:
        Task<List<TsClassDto>> GetListNoPagedAsync(GetTsClassesInput input);

        //Write your custom code here...

        Task<List<TsClassDto>> GetListByParentCode(string parentCode);
    }
}