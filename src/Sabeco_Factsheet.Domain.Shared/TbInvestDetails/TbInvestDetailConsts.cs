namespace Sabeco_Factsheet.TbInvestDetails
{
    public static class TbInvestDetailConsts
    {
        private const string DefaultSorting = "{0}ParentId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbInvestDetail." : string.Empty);
        }

        public const int DocNoMaxLength = 50;
        public const int NoteMaxLength = 250;
    }
}