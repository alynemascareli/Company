using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MsCompany.Core.Model
{
    [Table("CompanyAddress")]
    public class CompanyAddress
    {
        [Key]
        public int CompanyAddressId { get; set; }   
        public int CompanyId { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string CountryCode { get; set; }
        public string Observation { get; set; }
        public string Complement { get; set; }
        public int CompanyType { get; set; } 
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public DateTime DateDeleted { get; set; } = new DateTime(0001, 01, 01, 0, 0, 0);

    }

}
