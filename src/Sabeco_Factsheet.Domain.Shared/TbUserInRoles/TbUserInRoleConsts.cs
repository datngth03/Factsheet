namespace Sabeco_Factsheet.TbUserInRoles
{
    public static class TbUserInRoleConsts
    {
        private const string DefaultSorting = "{0}RoleId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbUserInRole." : string.Empty);
        }

    }
}