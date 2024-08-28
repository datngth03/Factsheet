using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbBreweryImages
{
    public partial interface ITbBreweryImagesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbBreweryImageDto>> GetListNoPagedAsync(GetTbBreweryImagesInput input);

        //Write your custom code here...

    }
}