using System;
using System.Collections.Generic;
using MsCompany.Core.Model;

namespace MsCompany.Core.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<Company> Get();
        Company Entry(Company newItem);
        Company Find(int id);
        void Remove(int id);
    }
}
