namespace Sabeco_Factsheet.TbHisCompanies
{
    public static class TbHisCompanyConsts
    {
        private const string DefaultSorting = "{0}IsSendMail asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbHisCompany." : string.Empty);
        }

        public const int CodeMaxLength = 20;
        public const int NameMaxLength = 250;
        public const int Name_ENMaxLength = 250;
        public const int BriefNameMaxLength = 100;
        public const int ContactInfo_01MaxLength = 250;
        public const int ContactInfo_02MaxLength = 50;
        public const int ContactInfo_03MaxLength = 50;
        public const int ContactInfo_04MaxLength = 150;
        public const int ContactInfo_05MaxLength = 250;
        public const int ContactInfo_06MaxLength = 15;
        public const int StockCodeMaxLength = 5;
        public const int StockExchangeMaxLength = 10;
        public const int LicenseNoMaxLength = 20;
        public const int LicenseMaxLength = 20;
        public const int LegalRepresentMaxLength = 250;
        public const int CompanyTypeMaxLength = 5;
        public const int ContactName1MaxLength = 150;
        public const int ContactDept1MaxLength = 150;
        public const int ContactMail1MaxLength = 150;
        public const int ContactPosition1MaxLength = 250;
        public const int ContactPhone1MaxLength = 50;
        public const int ContactName2MaxLength = 150;
        public const int ContactDept2MaxLength = 150;
        public const int ContactMail2MaxLength = 150;
        public const int ContactPosition2MaxLength = 250;
        public const int ContactPhone2MaxLength = 50;
        public const int NoteMaxLength = 250;
    }
}