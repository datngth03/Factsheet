using System;

namespace Sabeco_Factsheet.TbPersons
{
    public abstract class TbPersonExcelDtoBase
    {
        public string Code { get; set; } = null!;
        public int? CompanyId { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? Address { get; set; }
        public string? IDCardNo { get; set; }
        public DateTime? IDCardDate { get; set; }
        public string? IdCardIssuePlace { get; set; }
        public string? Ethnicity { get; set; }
        public string? Religion { get; set; }
        public string? NationalityCode { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }
        public string? Image { get; set; }
        public bool? IsActive { get; set; }
        public byte? DocStatus { get; set; }
        public bool? IsCheckRetirement { get; set; }
        public bool? IsCheckTermEnd { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public string? OldCode { get; set; }
        public bool IsDeleted { get; set; }
    }
}