namespace Sabeco_Factsheet.TbCompanyBranchTemps
{
    public static class TbCompanyBranchTempConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbCompanyBranchTemp." : string.Empty);
        }

    }
}