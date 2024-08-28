namespace Sabeco_Factsheet.TbRoles
{
    public static class TbRoleConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbRole." : string.Empty);
        }

        public const int CodeMaxLength = 20;
        public const int NameMaxLength = 250;
        public const int DescriptionMaxLength = 250;
    }
}