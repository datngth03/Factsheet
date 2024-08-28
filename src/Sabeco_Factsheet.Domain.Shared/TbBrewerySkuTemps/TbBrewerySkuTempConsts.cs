namespace Sabeco_Factsheet.TbBrewerySkuTemps
{
    public static class TbBrewerySkuTempConsts
    {
        private const string DefaultSorting = "{0}idBrewerySKU asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbBrewerySkuTemp." : string.Empty);
        }

        public const int BreweryCodeMaxLength = 20;
        public const int SKUCodeMaxLength = 16;
    }
}