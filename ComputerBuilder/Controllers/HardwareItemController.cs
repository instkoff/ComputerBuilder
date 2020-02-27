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
        [HttpGet("get_item/")]
        public IActionResult GetItem(int id)
        {
            var item = _hardwareItemService.Get(id);
            return Ok(item);
        }
        [HttpGet("get_all_items/")]
        public IActionResult GetAllItems()
        {
            var items = _hardwareItemService.GetAll();
            return Ok(items);
        }
        [HttpPost("add_hwitem/")]
        public async Task<ActionResult<int>> AddHwItem(HardwareItemModel itemModel)
        {
            var result = await _hardwareItemService.Create(itemModel);
            return Ok(result);//как сделать Created и нужно ли?
        }

    }
}
