namespace Sabeco_Factsheet.TbBreweries
{
    public static class TbBreweryConsts
    {
        private const string DefaultSorting = "{0}BreweryCode asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbBrewery." : string.Empty);
        }

        public const int BreweryCodeMaxLength = 20;
        public const int BreweryNameMaxLength = 250;
        public const int BreweryName_ENMaxLength = 250;
    }
}