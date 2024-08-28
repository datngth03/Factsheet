namespace Sabeco_Factsheet.TbCompanyBranchs
{
    public static class TbCompanyBranchConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbCompanyBranch." : string.Empty);
        }

    }
}