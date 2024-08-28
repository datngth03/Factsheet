namespace Sabeco_Factsheet.TbInvestPersons
{
    public static class TbInvestPersonConsts
    {
        private const string DefaultSorting = "{0}ParentId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbInvestPerson." : string.Empty);
        }

        public const int NoteMaxLength = 250;
    }
}