using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using CRUD.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CRUD_Operation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private readonly IInventoryItemRepository _inventoryItemRepository;
        public InventoryItemController(IInventoryItemRepository inventoryItemRepository)
        {
          _inventoryItemRepository = inventoryItemRepository;
        }
        //Create InventoryItem
        [HttpPost]
        public async Task<IActionResult> CreateInventoryItem(InventoryItems model)
        {
            var result = _inventoryItemRepository.InventoryItemAdd(model);
            return Ok(result);
        }

        //edit the inventory item
        [HttpPut("{id}")]

        public IActionResult EditInventory(int id , InventoryItems model)
        {
            var data = _inventoryItemRepository.InventoryItemUpdate(id, model);
            return Ok(data);
        }

        //delete inventory
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _inventoryItemRepository.InventoryItemRemove(id);
            return Ok(data);
        }

    }
}
