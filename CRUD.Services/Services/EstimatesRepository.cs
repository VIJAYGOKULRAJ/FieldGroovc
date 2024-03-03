using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Services
{
    public class EstimatesRepository : IEstimatesRepository
    {
        private readonly ProductContext _context;
        private readonly ILeadsRepository _leadsRepository;


        public EstimatesRepository(ProductContext context , ILeadsRepository leadsRepository )
        {
            _context = context;
            _leadsRepository = leadsRepository;
           
        }
        private void Save()
        {
           _context.SaveChanges();
        }
        public Estimates GetById(int id)
        {
            return _context.Estimates.FirstOrDefault(x => x.EstimateId == id);
        }

        public async Task<int> EstimatesAdd(Estimates model)
        {
            try
            {
                var ConvertTheEstimate = _leadsRepository.GetById(model.LeadsId);
                if(ConvertTheEstimate.IsOpportunity == true)
                {
                    
                    model.Locked = false;
                    model.DefaultEstimate = false;
                    if (model.Status == EstimateStatus.ReadyForWorkOrder)
                    {
                        model.ReadyForWorkOrder = true;
                        await _context.Estimates.AddAsync(model);
                        Save();
                        return model.EstimateId;
                        
                    }
                    else
                    {
                        await _context.Estimates.AddAsync(model);
                        Save();
                        return model.EstimateId;


                    }
                }
                else
                {
                    throw new InvalidOperationException("You can create an estimate only for Opportunity");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public Estimates GetByLeadsId(int id)
        {
            return _context.Estimates.FirstOrDefault(x => x.LeadsId == id);
        }


        public string LockTheEstimate(int id)
        {
            Estimates lockedEstimate = _context.Estimates.FirstOrDefault(x => x.EstimateId == id);

            if (lockedEstimate != null)
            {
                lockedEstimate.Locked = true;
                _context.SaveChanges();
                return "Estimate Blocked";
            }
            else
            {
                return "Estimate not found";
            }
        }


        public string EditEstimate(int id, Estimates model)
        {
            var previousDetails = _context.Estimates.FirstOrDefault(x => x.EstimateId == id);

            if (previousDetails != null && previousDetails.Locked == false)
            {
                previousDetails.UserId = model.UserId;
                previousDetails.LeadsId = model.LeadsId;
                previousDetails.Name = model.Name;
                previousDetails.LineItemIds = model.LineItemIds;
                previousDetails.CustomerAccepted = model.CustomerAccepted;
                previousDetails.Notes = model.Notes;
                previousDetails.LocationId = model.LocationId;
                previousDetails.DefaultEstimate = model.DefaultEstimate;
                previousDetails.Type = model.Type;
                previousDetails.Number = model.Number;
                previousDetails.Status = model.Status;
                previousDetails.DateModified = model.DateModified;
                previousDetails.Fineprint = model.Fineprint;
                previousDetails.ChangeOrder = model.ChangeOrder;
                previousDetails.ReadyForWorkOrder = model.ReadyForWorkOrder;
                previousDetails.Duration = model.Duration;
                previousDetails.SignerName = model.SignerName;
                previousDetails.SignerTitle = model.SignerTitle;
                previousDetails.SignerSignature = model.SignerSignature;
                previousDetails.SignatureStyle = model.SignatureStyle;
                previousDetails.Dead = model.Dead;
                previousDetails.CreatedBy = model.CreatedBy;
                previousDetails.HidePhaseTotal = model.HidePhaseTotal;
                previousDetails.DisplayDiscountAmountOnPrintable = model.DisplayDiscountAmountOnPrintable;
                previousDetails.DateCustomerAccepted = model.DateCustomerAccepted;
                previousDetails.HideEstimateTotal = model.HideEstimateTotal;
                previousDetails.DepositAmount = model.DepositAmount;
                previousDetails.DepositAmountUnit = model.DepositAmountUnit;
                previousDetails.DepositNote = model.DepositNote;
                previousDetails.Amount = model.Amount;
                previousDetails.PaidDate = model.PaidDate;
                previousDetails.PayaVaultId = model.PayaVaultId;
                previousDetails.PaymentMethodPreview = model.PaymentMethodPreview;
                previousDetails.PayaVaultLocationId = model.PayaVaultLocationId;
                previousDetails.Token = model.Token;

                Save();
                return "Estimate Updated";
            }

            else
            {
                return "Estimate Blocked";
            }
        }

        public string ChangeTheDefaultEstimate(int id)
        {
            Estimates DefaultEstimate = _context.Estimates.FirstOrDefault(x => x.EstimateId == id);

            if (DefaultEstimate != null && DefaultEstimate.Locked == false)
            {
                DefaultEstimate.DefaultEstimate = true;
                _context.SaveChanges();
                return "Default Estimate Changed";
            }
            else
            {
                return "Default Estimate not changed because of locked";
            }
        }

        public Estimates DuplicateEstimate(int id)
        {
            try
            {
                var existingEstimate = _context.Estimates.FirstOrDefault(x => x.EstimateId == id);

                if (existingEstimate != null)
                {

                    var newEstimate = new Estimates
                    {
                        UserId = existingEstimate.UserId,
                        LeadsId = existingEstimate.LeadsId,
                        Name = existingEstimate.Name,
                        LineItemIds = existingEstimate.LineItemIds,
                        CustomerAccepted = existingEstimate.CustomerAccepted,
                        Notes = existingEstimate.Notes,
                        LocationId = existingEstimate.LocationId,
                        Type = existingEstimate.Type,
                        Number = existingEstimate.Number,
                        Status = existingEstimate.Status,
                        Fineprint = existingEstimate.Fineprint,
                        StartDate = existingEstimate.StartDate,
                        ChangeOrder = existingEstimate.ChangeOrder,
                        ReadyForWorkOrder = existingEstimate.ReadyForWorkOrder,
                        Duration = existingEstimate.Duration,
                        SignerName = existingEstimate.SignerName,
                        SignerTitle = existingEstimate.SignerTitle,
                        SignerSignature = existingEstimate.SignerSignature,
                        SignatureStyle = existingEstimate.SignatureStyle,
                        DateSigned = existingEstimate.DateSigned,
                        Locked = existingEstimate.Locked,
                        Dead = existingEstimate.Dead,
                        CreatedBy = existingEstimate.CreatedBy,
                        HidePhaseTotal = existingEstimate.HidePhaseTotal,
                        DisplayDiscountAmountOnPrintable = existingEstimate.DisplayDiscountAmountOnPrintable,
                        DateCustomerAccepted = existingEstimate.DateCustomerAccepted,
                        HideEstimateTotal = existingEstimate.HideEstimateTotal,
                        DepositAmount = existingEstimate.DepositAmount,
                        DepositAmountUnit = existingEstimate.DepositAmountUnit,
                        DepositNote = existingEstimate.DepositNote,
                        Amount = existingEstimate.Amount,
                        PaidDate = existingEstimate.PaidDate,
                        PayaVaultId = existingEstimate.PayaVaultId,
                        PaymentMethodPreview = existingEstimate.PaymentMethodPreview,
                        PayaVaultLocationId = existingEstimate.PayaVaultLocationId,
                        Token = existingEstimate.Token

                    };

                    newEstimate.DateCreated = DateTime.Now;
                    newEstimate.DateModified = DateTime.Now;
                    newEstimate.DefaultEstimate = false;
                    _context.Estimates.Add(newEstimate);
                    Save();

                    return newEstimate;
                }
                else
                {
                    return null; 
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string EditEstimateLocation(int id, string location)
        {
            try
            {
                var existingEstimate = _context.Estimates.FirstOrDefault(x => x.EstimateId == id);

                if (existingEstimate != null && existingEstimate.Locked == false)
                {
                    existingEstimate.LocationId = location;
                    Save();
                    return "Estimate Location Updated";
                }
                else
                {
                    return "Estimate not found or locked";
                }
            }
            catch (Exception ex)
            {
                return $"An error occurred while updating estimate location: {ex.Message}";
            }
        }
    }
}
