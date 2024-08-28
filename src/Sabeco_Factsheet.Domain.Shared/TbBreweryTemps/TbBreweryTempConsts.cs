namespace Sabeco_Factsheet.TbBreweryTemps
{
    public static class TbBreweryTempConsts
    {
        private const string DefaultSorting = "{0}idBrewery asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbBreweryTemp." : string.Empty);
        }

        public const int BreweryCodeMaxLength = 20;
        public const int BreweryNameMaxLength = 250;
        public const int BreweryName_ENMaxLength = 250;
    }
}