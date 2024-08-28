namespace Sabeco_Factsheet.TsClassTemps
{
    public static class TsClassTempConsts
    {
        private const string DefaultSorting = "{0}ParentCode asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TsClassTemp." : string.Empty);
        }

        public const int ParentCodeMaxLength = 50;
        public const int CodeMaxLength = 50;
        public const int NameMaxLength = 250;
        public const int Name_ENMaxLength = 250;
        public const int Code_TypeMaxLength = 1;
    }
}