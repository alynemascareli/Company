using System;
using System.Collections.Generic;
using System.Linq;
using MsCompany.Core.Contracts;
using MsCompany.Core.Model;

namespace MsCompany.Tests
{
    class CompanyServiceFake : ICompanyService
    {
        private readonly List<Company> _company;

        public CompanyServiceFake()
        {
            _company = new List<Company>()
            {
                new Company() {
                CompanyId = 1,
                BusinessName = new string("Company 1"),
                FictitiousName = new string("Company 1"),
                CnpjCpf = new string(""),
                Phone = new string(""),
                CellPhone = new string(""),
                Email = new string(""),
                MEI = new string(""),
                SerieNfce = new string(""),
                TokenNfce = new string(""),
                Time = new string(""),
                Image = new string(""),
                Status = new int(),
                DateUpdated = DateTime.Now,
                DateCreated = DateTime.Now,
                DateDeleted = new DateTime(0001, 01, 01, 0, 0, 0)
            },
                new Company() {
                CompanyId = 2,
                BusinessName = new string("Company 2"),
                FictitiousName = new string("Company 2"),
                CnpjCpf = new string(""),
                Phone = new string(""),
                CellPhone = new string(""),
                Email = new string(""),
                MEI = new string(""),
                SerieNfce = new string(""),
                TokenNfce = new string(""),
                Time = new string(""),
                Image = new string(""),
                Status = new int(),
                DateUpdated = DateTime.Now,
                DateCreated = DateTime.Now,
                DateDeleted = new DateTime(0001, 01, 01, 0, 0, 0)
            },
                new Company() {
                CompanyId = 3,
                BusinessName = new string("Company 3"),
                FictitiousName = new string("Company 3"),
                CnpjCpf = new string(""),
                Phone = new string(""),
                CellPhone = new string(""),
                Email = new string(""),
                MEI = new string(""),
                SerieNfce = new string(""),
                TokenNfce = new string(""),
                Time = new string(""),
                Image = new string(""),
                Status = new int(),
                DateUpdated = DateTime.Now,
                DateCreated = DateTime.Now,
                DateDeleted = new DateTime(0001, 01, 01, 0, 0, 0)
            }
            };
        }

        public IEnumerable<Company> Get()
        {
            return _company;
        }

        public Company Entry(Company newItem)
        {
            newItem.CompanyId = new int();
            _company.Add(newItem);
            return newItem;
        }

        public Company Find(int id)
        {
            return _company.Where(a => a.CompanyId == id)
                .FirstOrDefault();
        }

        public void Remove(int id)
        {
            var existing = _company.First(a => a.CompanyId == id);
            _company.Remove(existing);
        }
    }
}
