namespace Sabeco_Factsheet.TbHisBreweryDeliveryVolumes
{
    public static class TbHisBreweryDeliveryVolumeConsts
    {
        private const string DefaultSorting = "{0}IsSendMail asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbHisBreweryDeliveryVolume." : string.Empty);
        }

        public const int BreweryCodeMaxLength = 20;
    }
}