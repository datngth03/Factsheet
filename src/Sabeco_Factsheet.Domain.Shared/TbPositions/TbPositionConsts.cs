namespace Sabeco_Factsheet.TbPositions
{
    public static class TbPositionConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbPosition." : string.Empty);
        }

        public const int CodeMaxLength = 20;
        public const int NameMaxLength = 250;
        public const int Name_ENMaxLength = 250;
    }
}