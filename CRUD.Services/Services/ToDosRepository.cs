using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Services
{
    public class ToDosRepository : IToDos
    {
        private readonly ProductContext _context;
        public ToDosRepository(ProductContext context)
        {
            _context = context;
        }
        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public IEnumerable<ToDos> GetToDos()
        {
            try
            {
                return _context.ToDos.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task ToDosAdd(ToDos model)
        {
            await _context.ToDos.AddAsync(model);
            await Save();
        }
    }
}
