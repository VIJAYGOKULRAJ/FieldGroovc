using CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Interfaces
{
    public interface IEstimatesRepository
    {
        Task<int> EstimatesAdd(Estimates model);
        Estimates GetByLeadsId(int id);
        Estimates GetById(int id);
        string LockTheEstimate(int id);
        string ChangeTheDefaultEstimate(int id);
        string EditEstimate(int id, Estimates model);
        

        Estimates DuplicateEstimate(int id);
        string EditEstimateLocation(int id, string location);



    }
}
