using CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Interfaces
{
    public interface IUser
    {
        public IEnumerable<User> GetUser();
        public IEnumerable<User> ListUser();
        Task AddUser(User model);

        User GetUserByUsername(string username);

    }
}
