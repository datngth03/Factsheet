namespace Sabeco_Factsheet.TbConfigRetirementTimes
{
    public static class TbConfigRetirementTimeConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbConfigRetirementTime." : string.Empty);
        }

    }
}