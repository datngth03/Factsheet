using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbTerms
{
    public partial interface ITbTermsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbTermDto>> GetListNoPagedAsync(GetTbTermsInput input);

        //Write your custom code here...

    }
}