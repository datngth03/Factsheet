namespace Sabeco_Factsheet.TbLogSendEmails
{
    public static class TbLogSendEmailConsts
    {
        private const string DefaultSorting = "{0}TimeSend asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbLogSendEmail." : string.Empty);
        }

    }
}