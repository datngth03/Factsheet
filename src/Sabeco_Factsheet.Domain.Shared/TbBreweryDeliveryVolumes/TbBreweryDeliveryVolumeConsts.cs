namespace Sabeco_Factsheet.TbBreweryDeliveryVolumes
{
    public static class TbBreweryDeliveryVolumeConsts
    {
        private const string DefaultSorting = "{0}BreweryId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbBreweryDeliveryVolume." : string.Empty);
        }

        public const int BreweryCodeMaxLength = 20;
    }
}