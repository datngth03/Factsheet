namespace Sabeco_Factsheet.TbLandInfos
{
    public static class TbLandInfoConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbLandInfo." : string.Empty);
        }

    }
}