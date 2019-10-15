using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Ms.Companies.Core.Model
{
    
    [Table("Company")]
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string BusinessName { get; set; }
        public string FictitiousName { get; set; }
        public string CnpjCpf { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string MEI { get; set; }
        public string SerieNfce { get; set; }
        public string TokenNfce { get; set; }
        public int Status { get; set; }
        public string Time { get; set; }
        public string Image { get; set; }
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateDeleted { get; set; } = new DateTime(0001, 01, 01, 0, 0, 0);
        public List<CompanyAddress> CompanyAddress { get; set; }
        public List<CompanyParams> CompanyParams { get; set; }
    }   
}
