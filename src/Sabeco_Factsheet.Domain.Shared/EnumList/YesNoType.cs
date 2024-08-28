using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.EnumList
{
    public enum YesNoType
    {
        Yes,
        No
    }
    public class YesNoTypeList
    {
        public string? Value { get; set; }
        public string? DisplayName { get; set; }
    }
}
