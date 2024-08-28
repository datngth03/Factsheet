namespace Sabeco_Factsheet.TbAssets
{
    public static class TbAssetConsts
    {
        private const string DefaultSorting = "{0}CompanyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbAsset." : string.Empty);
        }

        public const int AssetTypeMaxLength = 150;
        public const int AssetItemMaxLength = 250;
        public const int AssetAddressMaxLength = 250;
        public const int DocNoMaxLength = 50;
        public const int DescriptionMaxLength = 250;
    }
}