using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{
    public partial interface ITbCompanyMemberCouncilTermsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyMemberCouncilTermDto>> GetListNoPagedAsync(GetTbCompanyMemberCouncilTermsInput input);

        //Write your custom code here...

    }
}