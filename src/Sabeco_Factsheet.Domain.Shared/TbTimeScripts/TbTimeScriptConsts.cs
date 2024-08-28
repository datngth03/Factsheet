namespace Sabeco_Factsheet.TbTimeScripts
{
    public static class TbTimeScriptConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbTimeScript." : string.Empty);
        }

        public const int CodeMaxLength = 50;
    }
}