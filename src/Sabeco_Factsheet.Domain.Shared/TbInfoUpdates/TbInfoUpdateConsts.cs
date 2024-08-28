namespace Sabeco_Factsheet.TbInfoUpdates
{
    public static class TbInfoUpdateConsts
    {
        private const string DefaultSorting = "{0}TableName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TbInfoUpdate." : string.Empty);
        }

        public const int TableNameMaxLength = 50;
        public const int ColumnNameMaxLength = 50;
        public const int CommandMaxLength = 50;
        public const int LastValueMaxLength = 2000;
        public const int NewValueMaxLength = 2000;
        public const int CommentMaxLength = 250;
    }
}