using System;
using System.Collections.Generic;
using Ms.Companies.Core.Model;

namespace Ms.Companies.Core.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<Company> Get();
        Company Entry(Company newItem);
        Company Find(int id);
        void Remove(int id);
    }
}
