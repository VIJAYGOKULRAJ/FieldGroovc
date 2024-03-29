﻿using CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Interfaces
{
    public interface IOpportunities
    {
        Task ConvertToOpportunities(int id);
        Task<IEnumerable<Opportunities>> GetAll();
        Task AddOpportunities(Opportunities model);
        Leads DuplicateOpportunity(int id);
        IEnumerable<Opportunities> FilterOpportunities(string action, string status);
        IEnumerable<Opportunities> GetOpportunities();
    }
}
