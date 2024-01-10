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
    public class InventoryItemRepository : IInventoryItemRepository
    {
        private readonly ProductContext _context;
        public InventoryItemRepository(ProductContext context)
        {
            _context = context; 
        }
        private void Save()
        {
            _context.SaveChanges();
        }
        public string InventoryItemAdd(InventoryItems model)
        {
            try
            {
                _context.InventoryItems.AddAsync(model);
                Save();
                return "Added Inventory Vendors";

            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string InventoryItemRemove(int id)
        {
            var inventoryItemToRemove = _context.InventoryItems.Find(id);

            try 
            {
                if (inventoryItemToRemove != null)
                {
                _context.InventoryItems.Remove(inventoryItemToRemove);
                 Save();
                }
                 return "Deleted the Particular item";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string InventoryItemUpdate(int id, InventoryItems model)
        {
            var inventoryItemToEdit = _context.InventoryItems.Find(id);
            try
            {
                if (inventoryItemToEdit != null)
                {
                    // Update properties with new values from the model
                    inventoryItemToEdit.Category = model.Category;
                    inventoryItemToEdit.Name = model.Name;
                    inventoryItemToEdit.Description = model.Description;
                    inventoryItemToEdit.Price = model.Price;
                    inventoryItemToEdit.Quantity = model.Quantity;
                    inventoryItemToEdit.Sku = model.Sku;
                    inventoryItemToEdit.Warehouse = model.Warehouse;
                    inventoryItemToEdit.ReorderLevel = model.ReorderLevel;
                    inventoryItemToEdit.Taxable = model.Taxable;
                    inventoryItemToEdit.Active = model.Active;
                    inventoryItemToEdit.UnlimitedQuantity = model.UnlimitedQuantity;
                    inventoryItemToEdit.MinimumPrice = model.MinimumPrice;
                    inventoryItemToEdit.SurchargeExempt = model.SurchargeExempt;
                    inventoryItemToEdit.VendorId = model.VendorId;
                    inventoryItemToEdit.CustomField1 = model.CustomField1;
                    inventoryItemToEdit.CustomField2 = model.CustomField2;
                    inventoryItemToEdit.CustomField3 = model.CustomField3;
                    inventoryItemToEdit.CustomField4 = model.CustomField4;
                    inventoryItemToEdit.CustomField5 = model.CustomField5;
                    inventoryItemToEdit.LowQuantity = model.LowQuantity;
                    inventoryItemToEdit.Manufacturer = model.Manufacturer;
                    inventoryItemToEdit.LocationId = model.LocationId;
                    inventoryItemToEdit.ContingentId = model.ContingentId;
                    inventoryItemToEdit.ContingentWorkArea = model.ContingentWorkArea;
                    inventoryItemToEdit.NeedsManufacturerAssigned = model.NeedsManufacturerAssigned;
                    inventoryItemToEdit.Barcode = model.Barcode;
                    inventoryItemToEdit.Value = model.Value;
                    inventoryItemToEdit.CommittedQuantity = model.CommittedQuantity;
                    inventoryItemToEdit.AwaitingQuantity = model.AwaitingQuantity;
                    inventoryItemToEdit.TargetQuantity = model.TargetQuantity;
                    inventoryItemToEdit.UnitOfMeasurement = model.UnitOfMeasurement;
                    inventoryItemToEdit.Notes = model.Notes;
                    inventoryItemToEdit.DateModified = DateTime.Now; 
                    inventoryItemToEdit.IntegrationId = model.IntegrationId;
                    inventoryItemToEdit.AdditionalFinePrint = model.AdditionalFinePrint;
                    inventoryItemToEdit.MasterId = model.MasterId;
                    inventoryItemToEdit.BookPrice = model.BookPrice;

                    
                    Save();
                }

                return "Edit the Particular item";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
