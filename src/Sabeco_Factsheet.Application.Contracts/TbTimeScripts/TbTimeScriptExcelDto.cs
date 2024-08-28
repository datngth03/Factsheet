using System;

namespace Sabeco_Factsheet.TbTimeScripts
{
    public abstract class TbTimeScriptExcelDtoBase
    {
        public string? Code { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }
        public int? Hour { get; set; }
        public int? Minute { get; set; }
        public int? Second { get; set; }
    }
}