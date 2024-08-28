namespace Sabeco_Factsheet.TbFileUploadTemps
{
    public static class TbFileUploadTempConsts
    {
        private const string DefaultSorting = "{0}companyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbFileUploadTemp." : string.Empty);
        }

    }
}