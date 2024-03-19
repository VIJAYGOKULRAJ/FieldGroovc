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

        public Customers GetById(int id)
        {
            try
            {
                var customer = _context.Customers
                    .Include(c => c.Estimate) 
                    .FirstOrDefault(c => c.CustomerId == id);

                return customer;
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                throw;
            }
        }
        public async Task<string> _AssignName(int id, AssignName name)
        {
            var customer =  _context.Customers
                     .Include(c => c.Estimate)
                     .FirstOrDefault(c => c.CustomerId == id);

            if (customer != null)
            {
                 customer.FirstName = name.FirstName;
                SaveAsync();
                return "successfully assign name changed...";
            }
            return "error while assign name changed...";
        }

        public async Task<string> _AssignSales(int id, AssignSales name)
        {
            var customer = _context.Customers
                    .Include(c => c.Estimate)
                    .FirstOrDefault(c => c.CustomerId == id);

            if (customer != null)
            {
                customer.Salesman = name.Salesman;
                SaveAsync();
                return "successfully assign saleperson changed...";
            }
            return "error while assign saleperson changed...";
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

        public Task<string> _AssignEstimate(int id, AssignSales name)
        {
            throw new NotImplementedException();
        }
    }
}
