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
    //changes
    public class WorkOrdersRepository : IWorkOrdersRepository
    {
        private readonly ProductContext _context;
        private readonly IEstimatesRepository _estimatesRepository;
        private readonly ILeadsRepository _leadsRepository;


        public WorkOrdersRepository(ProductContext context, IEstimatesRepository estimatesRepository, ILeadsRepository leadsRepository)
        {
            _context = context;
            _estimatesRepository = estimatesRepository;
            _leadsRepository = leadsRepository; 
        }
        private void Save()
        {
            _context.SaveChanges();
        }
        public string WorkOrdersAdd(WorkOrders model)
        {
            try
            {
                var estimatesData = _estimatesRepository.GetByLeadsId(model.LeadsId);

                if (estimatesData.ReadyForWorkOrder == true)
                {
                    _context.WorkOrders.Add(model);
                    Save();
                    return "Added successfully when ReadyForWorkOrder is true!";
                }
                else
                {
                    return "You can create a work order only when ReadyForWorkOrder is true for the corresponding estimate.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EditWordOrders(int id, WorkOrders updatedModel)
        {
            try
            {
                var existingWorkOrder = _context.WorkOrders.FirstOrDefault(x => x.WorkOrdersId == id);

                if (existingWorkOrder != null)
                {
                    existingWorkOrder.Name = updatedModel.Name;
                    existingWorkOrder.LineItemIds = updatedModel.LineItemIds;
                    existingWorkOrder.Owner = updatedModel.Owner;
                    existingWorkOrder.CompletedDate = updatedModel.CompletedDate;
                    existingWorkOrder.Notes = updatedModel.Notes;
                    existingWorkOrder.Scheduled = updatedModel.Scheduled;
                    existingWorkOrder.LocationId = updatedModel.LocationId;
                    existingWorkOrder.Type = updatedModel.Type;
                    existingWorkOrder.Number = updatedModel.Number;
                    existingWorkOrder.Status = updatedModel.Status;
                    existingWorkOrder.StatusHistory = updatedModel.StatusHistory;
                    existingWorkOrder.NotifySalesman = updatedModel.NotifySalesman;
                    existingWorkOrder.NotifyAccounting = updatedModel.NotifyAccounting;
                    existingWorkOrder.LaborAmount = updatedModel.LaborAmount;
                    existingWorkOrder.PartialWorkOrder = updatedModel.PartialWorkOrder;
                    existingWorkOrder.DisplayLaborAmount = updatedModel.DisplayLaborAmount;
                    existingWorkOrder.DateModified = updatedModel.DateModified;
                    existingWorkOrder.CreatedBy = updatedModel.CreatedBy;
                    existingWorkOrder.LaborAmountType = updatedModel.LaborAmountType;
                    existingWorkOrder.AllowInvoiceBeforeComplete = updatedModel.AllowInvoiceBeforeComplete;
                    existingWorkOrder.TentativeDate = updatedModel.TentativeDate;
                    existingWorkOrder.HourlyOnlyLaborCost = updatedModel.HourlyOnlyLaborCost;
                    Save();
                    return "WorkOrder updated successfully";
                }
                else
                {
                    return "WorkOrder not found";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
