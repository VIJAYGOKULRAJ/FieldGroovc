using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Services
{
    public class ContactRepository : IContactRepository
    {
        private readonly ProductContext _context;
        public ContactRepository(ProductContext context)
        {
            _context = context;           
        }
        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task ContactsAdd(Contacts model)
        {           
            await _context.Contacts.AddAsync(model);
            await Save();
        }   
    }
}
