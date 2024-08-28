namespace Sabeco_Factsheet.TbHisLogPrintings
{
    public static class TbHisLogPrintingConsts
    {
        private const string DefaultSorting = "{0}IsSendMail asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbHisLogPrinting." : string.Empty);
        }

        public const int UserNameMaxLength = 150;
        public const int CompanyCodeMaxLength = 350;
        public const int FileLanguageMaxLength = 10;
    }
}