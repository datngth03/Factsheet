namespace Sabeco_Factsheet.TbAdditionInfos
{
    public static class TbAdditionInfoConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbAdditionInfo." : string.Empty);
        }

        public const int TypeOfGroupMaxLength = 50;
    }
}