namespace Sabeco_Factsheet.Shared
{
    public abstract class LookupDtoBase<TKey>
    {
        public TKey Id { get; set; }

        public string DisplayName { get; set; } = null!;
    }
}