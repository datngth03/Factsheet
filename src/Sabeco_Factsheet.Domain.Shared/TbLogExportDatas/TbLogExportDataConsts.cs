namespace Sabeco_Factsheet.TbLogExportDatas
{
    public static class TbLogExportDataConsts
    {
        private const string DefaultSorting = "{0}TimeExport asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbLogExportData." : string.Empty);
        }

    }
}