namespace Sabeco_Factsheet.TbPersonTemps
{
    public static class TbPersonTempConsts
    {
        private const string DefaultSorting = "{0}idPerson asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbPersonTemp." : string.Empty);
        }

        public const int CodeMaxLength = 20;
        public const int FullNameMaxLength = 150;
        public const int BirthPlaceMaxLength = 150;
        public const int AddressMaxLength = 150;
        public const int IDCardNoMaxLength = 20;
        public const int IdCardIssuePlaceMaxLength = 150;
        public const int EthnicityMaxLength = 150;
        public const int ReligionMaxLength = 150;
        public const int NationalityCodeMaxLength = 3;
        public const int GenderMaxLength = 3;
        public const int PhoneMaxLength = 50;
        public const int EmailMaxLength = 150;
        public const int NoteMaxLength = 250;
        public const int OldCodeMaxLength = 20;
    }
}