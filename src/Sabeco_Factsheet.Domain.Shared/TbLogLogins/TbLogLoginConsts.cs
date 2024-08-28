namespace Sabeco_Factsheet.TbLogLogins
{
    public static class TbLogLoginConsts
    {
        private const string DefaultSorting = "{0}UserName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbLogLogin." : string.Empty);
        }

    }
}