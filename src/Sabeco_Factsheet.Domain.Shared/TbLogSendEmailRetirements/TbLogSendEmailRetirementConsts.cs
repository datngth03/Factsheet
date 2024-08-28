namespace Sabeco_Factsheet.TbLogSendEmailRetirements
{
    public static class TbLogSendEmailRetirementConsts
    {
        private const string DefaultSorting = "{0}idCompany asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbLogSendEmailRetirement." : string.Empty);
        }

    }
}