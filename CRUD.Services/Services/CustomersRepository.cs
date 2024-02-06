using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Services
{
    public class CustomersRepository :ICustomersRepository
    {
        private readonly ProductContext _context;
        public CustomersRepository(ProductContext context)
        {
            _context = context;
        }
        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<string> CustomersAddAsync(Customers model)
        {
            await _context.Customers.AddAsync(model);
            await SaveAsync(); 

            return "added success...";
        }

        public async Task<IEnumerable<Customers>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}
