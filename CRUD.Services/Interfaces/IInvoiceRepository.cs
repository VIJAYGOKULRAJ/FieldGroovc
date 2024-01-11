using CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Interfaces
{
    public interface IInvoiceRepository
    {
        public string InvoiceCreate(Invoices model);
        public string InvoiceEdit(int id, Invoices model); 
    }
}
