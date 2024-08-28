using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.Shared
{
    public abstract class LookupRequestDtoBase : PagedResultRequestDto
    {
        public string? Filter { get; set; }

        public LookupRequestDtoBase()
        {
            MaxResultCount = MaxMaxResultCount;
        }
    }
}