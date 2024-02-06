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
        Task<Customers> GetById(int id);
    }
}
