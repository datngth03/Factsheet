using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbCompanyBoards
{
    public abstract class TbCompanyBoardCreateDtoBase
    {
        [StringLength(TbCompanyBoardConsts.BranchCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? BranchCode { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbCompanyBoardConsts.CompanyCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string CompanyCode { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbCompanyBoardConsts.PersonCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string PersonCode { get; set; } = null!;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        [StringLength(TbCompanyBoardConsts.PositionCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? PositionCode { get; set; }
        public int? PersonalValue { get; set; }
        public int? OwnerValue { get; set; }
        [StringLength(TbCompanyBoardConsts.NoteMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Note { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public bool IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public bool IsDeleted { get; set; }
    }
}