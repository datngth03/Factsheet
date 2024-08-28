namespace Sabeco_Factsheet.TbCompanyMajors
{
    public static class TbCompanyMajorConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbCompanyMajor." : string.Empty);
        }

        public const int ShareHolderTypeMaxLength = 20;
        public const int NoteMaxLength = 250;
    }
}