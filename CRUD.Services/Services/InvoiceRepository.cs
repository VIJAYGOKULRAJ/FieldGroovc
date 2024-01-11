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
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ProductContext _context;
        public InvoiceRepository(ProductContext context)
        {
            _context = context;
        }
        private void Save()
        {
            _context.SaveChanges();
        }
        public string InvoiceCreate(Invoices model)
        {
            try
            {
                _context.Invoices.AddAsync(model);
                Save();
                return "Successfully created Invoice";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string InvoiceEdit(int id, Invoices model)
        {

            var invoiceEdit = _context.Invoices.Find(id);
            try
            {
                if (invoiceEdit != null)
                {
                    invoiceEdit.UserId = model.UserId;
                    invoiceEdit.LeadsId = model.LeadsId;
                    invoiceEdit.DatePaid = model.DatePaid;
                    invoiceEdit.AmountPaid = model.AmountPaid;
                    invoiceEdit.Notes = model.Notes;
                    invoiceEdit.Name = model.Name;
                    invoiceEdit.LineItemIds = model.LineItemIds;
                    invoiceEdit.Amount = model.Amount;
                    invoiceEdit.LocationId = model.LocationId;
                    invoiceEdit.Status = model.Status;
                    invoiceEdit.Fineprint = model.Fineprint;
                    invoiceEdit.Void = model.Void;
                    invoiceEdit.InvoiceDate = model.InvoiceDate;
                    invoiceEdit.PaidDate = model.PaidDate;
                    invoiceEdit.DueDate = model.DueDate;
                    invoiceEdit.DateModified = model.DateModified;
                    invoiceEdit.ExportDate = model.ExportDate;
                    invoiceEdit.QuickbooksId = model.QuickbooksId;
                    invoiceEdit.QuickbooksSyncDate = model.QuickbooksSyncDate;
                    invoiceEdit.QuickbooksSyncToken = model.QuickbooksSyncToken;
                    invoiceEdit.OnlyShowPhaseTotal = model.OnlyShowPhaseTotal;
                    invoiceEdit.IsEstimateGenerated = model.IsEstimateGenerated;
                    invoiceEdit.QuickBookDesktopID = model.QuickBookDesktopID;
                    invoiceEdit.QuickBooksDesktopSyncDate = model.QuickBooksDesktopSyncDate;
                    invoiceEdit.QBDEditSequence = model.QBDEditSequence;
                    invoiceEdit.CustomNumber = model.CustomNumber;

                    Save();
                }

                return "Edit the invoice item";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
