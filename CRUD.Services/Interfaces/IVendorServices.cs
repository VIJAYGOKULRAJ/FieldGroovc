using CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Interfaces
{
    public interface IVendorServices
    {
        Task<IEnumerable<Vendors>> GetVendors();

        string CreateVendor(Vendors vendor);

        string EditVendor(int id, Vendors vendor);

        string InActivateVendor(int id);
    }
}
