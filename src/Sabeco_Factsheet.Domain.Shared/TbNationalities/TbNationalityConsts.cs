namespace Sabeco_Factsheet.TbNationalities
{
    public static class TbNationalityConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbNationality." : string.Empty);
        }

        public const int CodeMaxLength = 3;
        public const int Code2MaxLength = 2;
        public const int Name_enMaxLength = 255;
        public const int Name_vnMaxLength = 255;
    }
}