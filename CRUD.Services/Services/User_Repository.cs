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
    public class User_Repository : IUser
    {
        private readonly ProductContext _context;
        public User_Repository(ProductContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetUser()
        {
            try
            {
                return _context.User.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
