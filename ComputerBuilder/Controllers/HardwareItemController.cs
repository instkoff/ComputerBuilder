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

        [HttpGet("get_all_hw_items")]
        public async Task<IActionResult> GetAllHwItems()
        {
            return Ok(await _hardwareItemService.GetAllHwItemsFull());
        }
        [HttpPost("add_hw_item")]
        public async Task<ActionResult<int>> AddHwItem(HardwareItemModel itemModel)
        {
            var result = await _hardwareItemService.AddHwItem(itemModel);
            return Ok(result);
        }


    }
}
