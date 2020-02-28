using ComputerBuilder.BL.Model.Authorization;
using ComputerBuilder.BL.services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComputerBuilder.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUser(model);
                if (user == null)
                {
                    await _userService.AddUser(model);
                }
            }
        }
    }
}
