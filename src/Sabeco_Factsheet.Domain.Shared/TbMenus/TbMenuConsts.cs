namespace Sabeco_Factsheet.TbMenus
{
    public static class TbMenuConsts
    {
        private const string DefaultSorting = "{0}ControlName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbMenu." : string.Empty);
        }

        public const int ControlNameMaxLength = 500;
        public const int DescriptionMaxLength = 500;
    }
}