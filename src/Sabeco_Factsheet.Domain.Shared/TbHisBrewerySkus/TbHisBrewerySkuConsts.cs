namespace Sabeco_Factsheet.TbHisBrewerySkus
{
    public static class TbHisBrewerySkuConsts
    {
        private const string DefaultSorting = "{0}IsSendMail asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbHisBrewerySku." : string.Empty);
        }

        public const int BreweryCodeMaxLength = 20;
        public const int SKUCodeMaxLength = 16;
    }
}