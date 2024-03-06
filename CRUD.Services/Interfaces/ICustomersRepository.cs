using CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Interfaces
{
    public interface ICustomersRepository
    {
        Task<string> CustomersAddAsync(Customers model);

        Task<IEnumerable<Customers>> GetAll();

        Customers GetById(int id);
        Task<string> _AssignName(int id, AssignName name);
        Task<string> _AssignSales(int id, AssignSales name);

        Task<string> _AssignEstimate(int id, AssignSales name);

    }
}