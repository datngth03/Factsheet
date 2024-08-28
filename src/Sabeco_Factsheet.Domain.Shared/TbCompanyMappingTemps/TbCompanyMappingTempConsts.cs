namespace Sabeco_Factsheet.TbCompanyMappingTemps
{
    public static class TbCompanyMappingTempConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbCompanyMappingTemp." : string.Empty);
        }

    }
}