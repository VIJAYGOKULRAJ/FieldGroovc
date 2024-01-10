using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Services
{
    public class VendorServices : IVendorServices
    {
        private readonly ProductContext _context;

        public VendorServices(ProductContext context)
        {
            _context = context;
        }

        public string CreateVendor(Vendors vendor)
        {
            try
            {
                _context.Vendors.AddAsync(vendor);
                _context.SaveChanges();
                return "Added Vendors";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EditVendor(int id, Vendors vendor)
        {
            try
            {
                var existingVandor = _context.Vendors.FindAsync(id);
                if(existingVandor != null)
                {
                    
                }
                else
                {
                    return "invalid Id";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<IEnumerable<Vendors>> GetVendors()
        {
            return await _context.Vendors.ToListAsync();
        }
    }
}
