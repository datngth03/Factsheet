namespace Sabeco_Factsheet.TbCompanyBranchImages
{
    public static class TbCompanyBranchImageConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbCompanyBranchImage." : string.Empty);
        }

    }
}