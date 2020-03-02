using ComputerBuilder.BL.Model;
using ComputerBuilder.BL.services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuilder.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : BaseController
    {
        private readonly IComputerBuildService _buildComputerService;

        public HomeController(IComputerBuildService buildComputerService)
        {
            _buildComputerService = buildComputerService;
        }

        [HttpPost("build_pc")]
        public async Task<ActionResult<int>> Index(ComputerInfoModel model)
        {
            return await _buildComputerService.BuildPcAsync(model);
        }

        [HttpGet("get_all_pcbuilds")]
        public async Task<IActionResult> GetAllPcBuilds()
        {
            return Ok(await _buildComputerService.GetAllPcAsync());
        }


    }
    

}
