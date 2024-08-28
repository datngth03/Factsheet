namespace Sabeco_Factsheet.TbBreweryImages
{
    public static class TbBreweryImageConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbBreweryImage." : string.Empty);
        }

    }
}