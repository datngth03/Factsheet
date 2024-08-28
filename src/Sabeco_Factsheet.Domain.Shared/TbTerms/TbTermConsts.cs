namespace Sabeco_Factsheet.TbTerms
{
    public static class TbTermConsts
    {
        private const string DefaultSorting = "{0}BranchId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbTerm." : string.Empty);
        }

        public const int TermCodeMaxLength = 16;
        public const int DescriptionMaxLength = 10;
    }
}