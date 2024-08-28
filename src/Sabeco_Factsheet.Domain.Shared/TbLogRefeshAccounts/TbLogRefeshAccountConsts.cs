namespace Sabeco_Factsheet.TbLogRefeshAccounts
{
    public static class TbLogRefeshAccountConsts
    {
        private const string DefaultSorting = "{0}AccessToken asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbLogRefeshAccount." : string.Empty);
        }

    }
}