using CRUD.Domain.Models;
using CRUD.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Interfaces
{
    public interface IToDos
    {
        public IEnumerable<ToDos> GetToDos();
        Task ToDosAdd(ToDos model);
        IEnumerable<TodoDetails> GetTodoDetails();
    }
}
