using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MsCompany.Core.Model
{
    [Table("CompanyParams")]
    public class CompanyParams
    {
        public int CompanyParamsId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string NameIntegration { get; set; }
        public bool Type { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public DateTime DateDeleted { get; set; } = new DateTime(0001, 01, 01, 0, 0, 0);

    }

}
