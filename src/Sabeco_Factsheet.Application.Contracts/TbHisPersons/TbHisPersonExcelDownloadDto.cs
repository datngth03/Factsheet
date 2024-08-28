using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbHisPersons
{
    public abstract class TbHisPersonExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public bool? IsSendMail { get; set; }
        public DateTime? DateSendMailMin { get; set; }
        public DateTime? DateSendMailMax { get; set; }
        public DateTime? InsertDateMin { get; set; }
        public DateTime? InsertDateMax { get; set; }
        public int? TypeMin { get; set; }
        public int? TypeMax { get; set; }
        public int? IdPersonMin { get; set; }
        public int? IdPersonMax { get; set; }
        public string? Code { get; set; }
        public int? CompanyIdMin { get; set; }
        public int? CompanyIdMax { get; set; }
        public string? FullName { get; set; }
        public DateTime? BirthDateMin { get; set; }
        public DateTime? BirthDateMax { get; set; }
        public string? BirthPlace { get; set; }
        public string? Address { get; set; }
        public string? IDCardNo { get; set; }
        public DateTime? IDCardDateMin { get; set; }
        public DateTime? IDCardDateMax { get; set; }
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
        public byte? DocStatusMin { get; set; }
        public byte? DocStatusMax { get; set; }
        public bool? IsCheckRetirement { get; set; }
        public bool? IsCheckTermEnd { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public string? OldCode { get; set; }

        public TbHisPersonExcelDownloadDtoBase()
        {

        }
    }
}