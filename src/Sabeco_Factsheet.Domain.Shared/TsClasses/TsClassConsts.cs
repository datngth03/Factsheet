namespace Sabeco_Factsheet.TsClasses
{
    public static class TsClassConsts
    {
        private const string DefaultSorting = "{0}ParentCode asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TsClass." : string.Empty);
        }

        public const int ParentCodeMaxLength = 50;
        public const int CodeMaxLength = 50;
        public const int NameMaxLength = 250;
        public const int Name_ENMaxLength = 250;
        public const int Code_TypeMaxLength = 1;
    }
}