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

        public IEnumerable<TodoDetails> GetTodoDetails()
        {
            var todoDetails = _context.ToDos
                .Include(t => t.User)
                .Select(t => new TodoDetails
                {
                    Username = t.User.Username,
                    DueDate = t.DueDate,
                    Description = t.Description,
                    ToDo = t.ToDo
                })
                .ToList();

            return todoDetails;
        }
        public async Task<bool> DeleteToDoById(int id)
        {
            var todoToDelete = await _context.ToDos.FindAsync(id);

            if (todoToDelete == null)
            {
                return false; 
            }

            _context.ToDos.Remove(todoToDelete);
            await Save();

            return true;
        }
    }
}
