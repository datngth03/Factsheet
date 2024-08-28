namespace Sabeco_Factsheet.TbHisCompanyPersons
{
    public static class TbHisCompanyPersonConsts
    {
        private const string DefaultSorting = "{0}IsSendMail asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbHisCompanyPerson." : string.Empty);
        }

        public const int BranchCodeMaxLength = 10;
        public const int PositionCodeMaxLength = 20;
        public const int NoteMaxLength = 250;
    }
}