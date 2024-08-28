namespace Sabeco_Factsheet.TbCompanyInvestTemps
{
    public static class TbCompanyInvestTempConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbCompanyInvestTemp." : string.Empty);
        }

    }
}