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
    public class CalendarEventRepository : ICalendarEvent
    {
        private readonly ProductContext _context;
        public CalendarEventRepository(ProductContext context)
        {
            _context = context;
        }

        public IEnumerable<CalendarEvents> GetCalendarEvents()
        {
            try
            {
                return _context.CalendarEvents.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task CalendarEventsAdd(CalendarEvents model)
        {
            await _context.CalendarEvents.AddAsync(model);
            await Save();
        }

    }
}
