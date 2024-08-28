namespace Sabeco_Factsheet.TbAdditionInfoTemps
{
    public static class TbAdditionInfoTempConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbAdditionInfoTemp." : string.Empty);
        }

        public const int TypeOfGroupMaxLength = 50;
    }
}