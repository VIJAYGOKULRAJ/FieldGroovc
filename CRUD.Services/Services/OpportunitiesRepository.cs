using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Services
{
    public class OpportunitiesRepository : IOpportunities
    {
        private readonly ProductContext _context;
        private readonly IValidator<Leads> _validator;
        public OpportunitiesRepository(ProductContext context, IValidator<Leads> validator)
        {
            _context = context;
            _validator = validator;
        }
        private void Save()
        {
            try
            {
                 _context.SaveChanges();
            }
                catch (DbUpdateException ex)
            {
                // Log the exception for further investigation
                Console.WriteLine($"Database save failed: {ex.Message}");
                throw; // Re-throw the exception to propagate it further
            }
        }
        public async Task ConvertToOpportunities(int id)
        {
            var details = _context.Leads.FirstOrDefault(x => x.LeadsId == id);
            if (details != null)
            {
                details.IsOpportunity = true;
                 Save();

            }
        }

        public async Task AddOpportunities(Opportunities model)
        {
            await _context.Opportunities.AddAsync(model);
            Save();
        }


     


        public Leads DuplicateOpportunity(int id)
        {
            try
            {
                var existingOpportunity = _context.Leads.FirstOrDefault(x => x.LeadsId == id);

                if (existingOpportunity != null)
                {
                    var newOpportunity = new Leads
                    {
                        UserId = existingOpportunity.UserId,
                        AccountType = existingOpportunity.AccountType,
                        Status = existingOpportunity.Status,
                        ProjectName = existingOpportunity.ProjectName,
                        CreatedBy = existingOpportunity.CreatedBy,
                        UpdatedBy = existingOpportunity.UpdatedBy
                    };

                    newOpportunity.CreatedDate = DateTime.Now;
                    newOpportunity.UpdatedDate = DateTime.Now;
                    newOpportunity.IsOpportunity = true;

                    _context.Leads.Add(newOpportunity);
                    Save();

                    return newOpportunity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error duplicating opportunity: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<Opportunities>> GetAll()
        {
            return await _context.Opportunities.ToListAsync();
        }
    }
}
