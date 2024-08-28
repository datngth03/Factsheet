namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{
    public static class TbCompanyMemberCouncilTermConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbCompanyMemberCouncilTerm." : string.Empty);
        }

    }
}