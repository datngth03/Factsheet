using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbNationalities
{
    public partial interface ITbNationalitiesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbNationalityDto>> GetListNoPagedAsync(GetTbNationalitiesInput input);

        //Write your custom code here...

    }
}