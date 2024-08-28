namespace Sabeco_Factsheet.TbCompanyPersonTemps
{
    public static class TbCompanyPersonTempConsts
    {
        private const string DefaultSorting = "{0}idCompanyPerson asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbCompanyPersonTemp." : string.Empty);
        }

        public const int BranchCodeMaxLength = 10;
        public const int PositionCodeMaxLength = 20;
        public const int NoteMaxLength = 250;
    }
}