namespace Sabeco_Factsheet.TbFileUploads
{
    public static class TbFileUploadConsts
    {
        private const string DefaultSorting = "{0}companyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbFileUpload." : string.Empty);
        }

    }
}