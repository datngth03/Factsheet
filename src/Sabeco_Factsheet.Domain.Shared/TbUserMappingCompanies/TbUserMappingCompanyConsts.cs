namespace Sabeco_Factsheet.TbUserMappingCompanies
{
    public static class TbUserMappingCompanyConsts
    {
        private const string DefaultSorting = "{0}userid asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbUserMappingCompany." : string.Empty);
        }

    }
}