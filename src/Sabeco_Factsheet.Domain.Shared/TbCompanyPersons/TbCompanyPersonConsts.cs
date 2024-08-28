namespace Sabeco_Factsheet.TbCompanyPersons
{
    public static class TbCompanyPersonConsts
    {
        private const string DefaultSorting = "{0}BranchCode asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbCompanyPerson." : string.Empty);
        }

        public const int BranchCodeMaxLength = 10;
        public const int PositionCodeMaxLength = 20;
        public const int NoteMaxLength = 250;
    }
}