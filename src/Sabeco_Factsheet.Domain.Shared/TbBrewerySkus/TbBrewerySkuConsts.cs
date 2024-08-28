namespace Sabeco_Factsheet.TbBrewerySkus
{
    public static class TbBrewerySkuConsts
    {
        private const string DefaultSorting = "{0}Year asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbBrewerySku." : string.Empty);
        }

        public const int BreweryCodeMaxLength = 20;
        public const int SKUCodeMaxLength = 16;
    }
}