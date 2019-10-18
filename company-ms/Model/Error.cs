using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MsCompany.Core.Model
{
    [NotMapped]
    public class Error
    {
        public string Message { get; set; }
        public int Type { get; set; }
        public Object Errors { get; set; }
    }


}
