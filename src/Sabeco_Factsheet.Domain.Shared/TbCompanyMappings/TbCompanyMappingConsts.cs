namespace Sabeco_Factsheet.TbCompanyMappings
{
    public static class TbCompanyMappingConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbCompanyMapping." : string.Empty);
        }

    }
}