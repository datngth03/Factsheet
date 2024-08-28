namespace Sabeco_Factsheet.TbCompanyBoards
{
    public static class TbCompanyBoardConsts
    {
        private const string DefaultSorting = "{0}BranchCode asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbCompanyBoard." : string.Empty);
        }

        public const int BranchCodeMaxLength = 10;
        public const int CompanyCodeMaxLength = 20;
        public const int PersonCodeMaxLength = 20;
        public const int PositionCodeMaxLength = 20;
        public const int NoteMaxLength = 250;
    }
}