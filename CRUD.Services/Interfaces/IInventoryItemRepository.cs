﻿using CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Interfaces
{
    public interface IInventoryItemRepository
    {
        public string InventoryItemAdd(InventoryItems model);
        public string InventoryItemRemove(int id);

        public string InventoryItemUpdate(int id , InventoryItems model);
    }
}
