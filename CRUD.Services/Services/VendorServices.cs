using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Services
{
    public class VendorServices : IVendorServices
    {
        private readonly ProductContext _context;

        public VendorServices(ProductContext context)
        {
            _context = context;
        }

        public string CreateVendor(Vendors vendor)
        {
            try
            {
                vendor.Active = true;
                _context.Vendors.Add(vendor);
                _context.SaveChanges();
                return "Added Vendors";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EditVendor(int id, Vendors vendor)
        {
            try
            {
                var existingVandor = _context.Vendors.Find(id);
                if(existingVandor != null)
                {

                    existingVandor.UserId = vendor.UserId;
                    existingVandor.CompanyName = vendor.CompanyName;
                    existingVandor.MailingAddress1 = vendor.MailingAddress1;
                    existingVandor.MailingAddress2 = vendor.MailingAddress2;
                    existingVandor.MailingCity = vendor.MailingCity;
                    existingVandor.MailingState = vendor.MailingState;
                    existingVandor.MailingZip = vendor.MailingZip;
                    existingVandor.ReorderContact = vendor.ReorderContact;
                    existingVandor.Notes = vendor.Notes;
                    existingVandor.Phone = vendor.Phone;
                    existingVandor.IntegrationId = vendor.IntegrationId;
                    existingVandor.DateModified = DateTime.Now;
                    existingVandor.Email = vendor.Email;
                    existingVandor.Website = vendor.Website;
                    existingVandor.QuickbooksId = vendor.QuickbooksId;
                    existingVandor.QuickbooksSyncDate = vendor.QuickbooksSyncDate;
                    existingVandor.QuickbooksSyncToken = vendor.QuickbooksSyncToken;
                    existingVandor.QuickBookDesktopID = vendor.QuickBookDesktopID;
                    existingVandor.QuickBooksDesktopSyncDate = vendor.QuickBooksDesktopSyncDate;

                    _context.Vendors.Update(existingVandor);
                    _context.SaveChanges();
                    return "edited";

                }
                else
                {
                    return "invalid Id";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<IEnumerable<Vendors>> GetVendors()
        {
            return await _context.Vendors.ToListAsync();
        }

        public string InActivateVendor(int id)
        {
            try
            {
                var existingVandor = _context.Vendors.Find(id);
                if (existingVandor != null)
                {
                    existingVandor.Active = false;
                    _context.Vendors.Update(existingVandor);
                    _context.SaveChanges();
                    return "Inactivated";
                }
                else
                {
                    return "invalid Id";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
