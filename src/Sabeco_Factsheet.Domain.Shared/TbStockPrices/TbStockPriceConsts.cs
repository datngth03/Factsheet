namespace Sabeco_Factsheet.TbStockPrices
{
    public static class TbStockPriceConsts
    {
        private const string DefaultSorting = "{0}StockCode asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbStockPrice." : string.Empty);
        }

        public const int StockCodeMaxLength = 10;
    }
}