using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbConfigRetirementTimes
{
    public partial interface ITbConfigRetirementTimesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbConfigRetirementTimeDto>> GetListNoPagedAsync(GetTbConfigRetirementTimesInput input);

        //Write your custom code here...

    }
}