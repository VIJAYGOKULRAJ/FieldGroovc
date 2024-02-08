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



        public async Task<IEnumerable<Customers>> GetAll()
        {
            try
            {
                var customersWithEstimates = await _context.Customers
                    .Include(c => c.Estimate)
                    .ToListAsync();
                return customersWithEstimates;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Customers> GetById(int id)
        {
            try
            {
                var customer = await _context.Customers
                    .Include(c => c.Estimate) // Include related data if needed
                    .FirstOrDefaultAsync(c => c.CustomerId == id);

                return customer;
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                throw;
            }
        }

        public async Task<int> GetCustomerIdByName(string name)
        {
            try
            {
                var customerId = await _context.Customers
                    .Where(c => c.CompanyName == name) 
                    .Select(c => (int)c.CustomerId) 
                    .FirstOrDefaultAsync();

                return customerId;
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                throw;
            }
        }
    }
}
