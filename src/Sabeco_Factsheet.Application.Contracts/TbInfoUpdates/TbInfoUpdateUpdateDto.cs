using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbInfoUpdates
{
    public abstract class TbInfoUpdateUpdateDtoBase : AuditedEntityDto<int>
    {
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbInfoUpdateConsts.TableNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string TableName { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbInfoUpdateConsts.ColumnNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string ColumnName { get; set; } = null!;
        public string? ScreenName { get; set; }
        public int ScreenId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int RowId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbInfoUpdateConsts.CommandMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Command { get; set; } = null!;
        public string? GroupName { get; set; } 
        public string? LastValue { get; set; } 
        public string? NewValue { get; set; }
        public byte? DocStatus { get; set; }
        [StringLength(TbInfoUpdateConsts.CommentMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Comment { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int IsActive { get; set; }
        public int? crt_user { get; set; }
        public DateTime? crt_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }
        public Guid? ChangeSetId { get; set; }
        public DateTime? TimeAssessment { get; set; }
        public bool IsVisible { get; set; }

    }
}