namespace Sabeco_Factsheet.TbCompanyBusinessDetails
{
    public static class TbCompanyBusinessDetailConsts
    {
        private const string DefaultSorting = "{0}ParentId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbCompanyBusinessDetail." : string.Empty);
        }

        public const int RegistrationCodeMaxLength = 10;
        public const int RegistrationNameMaxLength = 250;
        public const int RegistrationName_ENMaxLength = 250;
    }
}