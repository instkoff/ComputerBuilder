using ComputerBuilder.BL.Model;
using ComputerBuilder.BL.services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComputerBuilder.Controllers
{
    [Route("api/[controller]")]
    public class HardwareItemController : BaseController
    {
        private readonly IHardwareItemService _hardwareItemService;

        public HardwareItemController(IHardwareItemService hardwareItemService)
        {
            _hardwareItemService = hardwareItemService;
        }

        [HttpPut("update_hw_item/{id}")]
        public async Task<ActionResult<HardwareItemModel>> UpdateItem(int id, [FromBody]HardwareItemModel itemModel)
        {
            if (id == 0)
                return BadRequest();
            var result = await _hardwareItemService.UpdateHwItemAsync(id, itemModel);
            if (result == null)
                return NotFound();
            return result;
        }

        [HttpGet("get_hw_item_by_id/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id == 0)
                return BadRequest("Id не должен быть равен 0");

            var result = await _hardwareItemService.GetHwItemByIdAsync(id);
           if (result == null)
               return NotFound("Объект с таким Id не найден");
           return Ok(result);
        }

        [HttpGet("get_all_hw_items")]
        public async Task<IActionResult> GetAllHwItems()
        {
            return Ok(await _hardwareItemService.GetAllHwItemsFull());
        }

        [HttpPost("add_hw_item")]
        public async Task<ActionResult<int>> AddHwItem([FromBody]HardwareItemModel itemModel)
        {
            var result = await _hardwareItemService.AddHwItem(itemModel);
            return Ok(result);
        }

        [HttpDelete("delete_hw_item/{id}")]
        public async Task<IActionResult> DeleteHwItem(int id)
        {
            if (id == 0)
                return BadRequest();
            var result = await _hardwareItemService.RemoveHwItem(id);
            if (result == 0)
                return NotFound();
            return Ok(result);

        }

        [HttpPost("filter_items")]
        public async Task<IActionResult> GetFilteredHwItems(FilterModel filter)
        {
            var result = await _hardwareItemService.GetFilteredItems(filter);
            return Ok(result);
        }

    }
}
