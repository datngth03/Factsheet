namespace Sabeco_Factsheet.TbNationalityTemps
{
    public static class TbNationalityTempConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbNationalityTemp." : string.Empty);
        }

        public const int CodeMaxLength = 3;
        public const int Code2MaxLength = 2;
        public const int Name_enMaxLength = 255;
        public const int Name_vnMaxLength = 255;
    }
}