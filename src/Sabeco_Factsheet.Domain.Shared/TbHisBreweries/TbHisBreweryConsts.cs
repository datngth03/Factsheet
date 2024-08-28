namespace Sabeco_Factsheet.TbHisBreweries
{
    public static class TbHisBreweryConsts
    {
        private const string DefaultSorting = "{0}IsSendMail asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbHisBrewery." : string.Empty);
        }

        public const int BreweryNameMaxLength = 250;
        public const int BreweryName_ENMaxLength = 250;
    }
}