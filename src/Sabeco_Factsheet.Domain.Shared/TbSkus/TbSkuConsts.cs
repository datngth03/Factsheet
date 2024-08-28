namespace Sabeco_Factsheet.TbSkus
{
    public static class TbSkuConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbSku." : string.Empty);
        }

        public const int CodeMaxLength = 16;
        public const int NameMaxLength = 150;
        public const int Name_ENMaxLength = 150;
        public const int BrandCodeMaxLength = 16;
        public const int UnitMaxLength = 50;
        public const int ItemBaseTypeMaxLength = 10;
    }
}