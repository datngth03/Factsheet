namespace Sabeco_Factsheet.TbLogPrintings
{
    public static class TbLogPrintingConsts
    {
        private const string DefaultSorting = "{0}userName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbLogPrinting." : string.Empty);
        }

        public const int userNameMaxLength = 150;
        public const int companyCodeMaxLength = 350;
        public const int fileLanguageMaxLength = 10;
    }
}