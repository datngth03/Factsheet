namespace Sabeco_Factsheet.TbCompanyMajorTemps
{
    public static class TbCompanyMajorTempConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbCompanyMajorTemp." : string.Empty);
        }

        public const int ShareHolderTypeMaxLength = 20;
        public const int NoteMaxLength = 250;
    }
}