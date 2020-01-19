using EventWorld.DTO;
using EventWorld.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Omu.ValueInjecter;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWorld.Web.Controllers
{
    public class UserController : Controller
    {

        private readonly UserManager<UserDTO> _userManager;

        public UserController(UserManager<UserDTO> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View("~/Views/User/Register.cshtml");
        }

        [HttpPost]
        public async Task<JsonResult> Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var entity = await _userManager.FindByEmailAsync(user.Email);
                if (entity == null)
                {
                    entity = (UserDTO)new UserDTO().InjectFrom(user);
                    var result = await _userManager.CreateAsync(entity, user.Password);
                    if (result.Succeeded)
                        return Json(true);
                    var error = string.Join(", ", result.Errors.Select(a => a.Description));
                    return Json(error);
                }
                ModelState.AddModelError("", "User already exists.");
            }
            var errors = new StringBuilder();

            foreach (var modelState in ModelState.Values)
                foreach (ModelError error in modelState.Errors)
                    errors.AppendLine(error.ErrorMessage);

            return Json(errors.ToString());
        }
    }
}