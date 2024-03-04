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
    public class SettingsRepository : ISettingsRepository
    {
        private readonly ProductContext _context;

        public SettingsRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> GetAllOppTypes()
        {
            var opportunityTypes = await _context.companies.Select(company => company.OpportunityActions).ToListAsync();
            return opportunityTypes;
        }
    }
}
