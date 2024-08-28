namespace Sabeco_Factsheet.TbLandInfoTemps
{
    public static class TbLandInfoTempConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbLandInfoTemp." : string.Empty);
        }

    }
}