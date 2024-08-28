using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbNationalityTemps
{
    public partial interface ITbNationalityTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbNationalityTempDto>> GetListNoPagedAsync(GetTbNationalityTempsInput input);

        //Write your custom code here...

    }
}