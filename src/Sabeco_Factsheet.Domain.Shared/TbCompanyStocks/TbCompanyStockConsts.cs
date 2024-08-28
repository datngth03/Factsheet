namespace Sabeco_Factsheet.TbCompanyStocks
{
    public static class TbCompanyStockConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbCompanyStock." : string.Empty);
        }

        public const int CompanyCodeMaxLength = 20;
        public const int StockExchangeMaxLength = 10;
        public const int DescriptionMaxLength = 250;
    }
}