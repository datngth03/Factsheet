namespace Sabeco_Factsheet.TbLogSyncUats
{
    public static class TbLogSyncUatConsts
    {
        private const string DefaultSorting = "{0}TimeExport asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbLogSyncUat." : string.Empty);
        }

    }
}