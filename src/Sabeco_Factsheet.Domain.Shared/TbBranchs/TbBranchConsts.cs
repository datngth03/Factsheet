namespace Sabeco_Factsheet.TbBranchs
{
    public static class TbBranchConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbBranch." : string.Empty);
        }

        public const int CodeMaxLength = 10;
        public const int BriefNameMaxLength = 50;
        public const int NameMaxLength = 250;
        public const int Name_ENMaxLength = 250;
        public const int CompanyCodeMaxLength = 20;
        public const int DescriptionMaxLength = 250;
    }
}