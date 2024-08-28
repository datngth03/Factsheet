using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbLogErrors
{
    public abstract class TbLogErrorCreateDtoBase
    {
        [Required(ErrorMessage = "The field is required.")]
        public DateTime TimeLog { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int UserLog { get; set; }
        public string? IPAddress { get; set; }
        public string? ClassLog { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public string FunctionLog { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        public string ReasonFailed { get; set; } = null!;
    }
}