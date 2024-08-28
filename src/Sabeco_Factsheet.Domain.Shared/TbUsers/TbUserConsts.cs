namespace Sabeco_Factsheet.TbUsers
{
    public static class TbUserConsts
    {
        private const string DefaultSorting = "{0}UserPrincipalName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbUser." : string.Empty);
        }

        public const int UserPrincipalNameMaxLength = 50;
        public const int UserNameMaxLength = 150;
        public const int FullNameMaxLength = 250;
        public const int EmailMaxLength = 250;
    }
}