namespace Sabeco_Factsheet.TbLogErrors
{
    public static class TbLogErrorConsts
    {
        private const string DefaultSorting = "{0}TimeLog asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbLogError." : string.Empty);
        }

    }
}