﻿using CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Interfaces
{
    public interface ICalendarEvent
    {
       public IEnumerable<CalendarEvents> GetCalendarEvents();
       Task CalendarEventsAdd(CalendarEvents model);


    }
}
