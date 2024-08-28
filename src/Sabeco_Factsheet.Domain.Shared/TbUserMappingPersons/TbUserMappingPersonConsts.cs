namespace Sabeco_Factsheet.TbUserMappingPersons
{
    public static class TbUserMappingPersonConsts
    {
        private const string DefaultSorting = "{0}userid asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbUserMappingPerson." : string.Empty);
        }

    }
}