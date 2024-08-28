namespace Sabeco_Factsheet.TbUserMappingBreweries
{
    public static class TbUserMappingBreweryConsts
    {
        private const string DefaultSorting = "{0}userid asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbUserMappingBrewery." : string.Empty);
        }

    }
}