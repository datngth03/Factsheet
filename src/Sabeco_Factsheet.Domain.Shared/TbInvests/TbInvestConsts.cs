namespace Sabeco_Factsheet.TbInvests
{
    public static class TbInvestConsts
    {
        private const string DefaultSorting = "{0}BranchCode asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbInvest." : string.Empty);
        }

        public const int BranchCodeMaxLength = 20;
        public const int CompanyCodeMaxLength = 20;
        public const int NoteMaxLength = 250;
    }
}