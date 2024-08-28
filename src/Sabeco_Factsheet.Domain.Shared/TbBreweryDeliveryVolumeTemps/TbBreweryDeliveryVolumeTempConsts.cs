namespace Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps
{
    public static class TbBreweryDeliveryVolumeTempConsts
    {
        private const string DefaultSorting = "{0}idBreweryDeliveryVolume asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbBreweryDeliveryVolumeTemp." : string.Empty);
        }

        public const int BreweryCodeMaxLength = 20;
    }
}