namespace Sabeco_Factsheet.TbCompanyInvests
{
    public static class TbCompanyInvestConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbCompanyInvest." : string.Empty);
        }

    }
}