namespace Sabeco_Factsheet.TbCompanyBusinesses
{
    public static class TbCompanyBusinessConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbCompanyBusiness." : string.Empty);
        }

        public const int LicenseMaxLength = 20;
        public const int CompanyNameMaxLength = 250;
        public const int CompanyAddressMaxLength = 250;
        public const int LegalRepresentMaxLength = 250;
        public const int CompanyTypeMaxLength = 250;
        public const int MajorBusinessMaxLength = 250;
        public const int OtherActivityMaxLength = 500;
        public const int NoteMaxLength = 250;
    }
}