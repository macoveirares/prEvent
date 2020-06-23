using EventWorld.DTO;
using EventWorld.Services.Services.Events;
using EventWorld.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Omu.ValueInjecter;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventWorld.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserDTO> _userManager;
        private readonly IEventService _eventService;

        public AccountController(UserManager<UserDTO> userManager, IEventService eventService)
        {
            _userManager = userManager;
            _eventService = eventService;
        }

        public IActionResult SignIn()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        [HttpPost]
        public async Task<JsonResult> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var identity = new ClaimsIdentity("cookies");
                identity.AddClaim(new Claim("FirstName", user.FirstName));
                identity.AddClaim(new Claim("LastName", user.LastName));
                identity.AddClaim(new Claim("DateOfBirth", user.DateOfBirth.ToString("dd/mm/yyyy")));
                identity.AddClaim(new Claim("Email", user.Email));
                identity.AddClaim(new Claim("Id", user.Id.ToString()));
                identity.AddClaim(new Claim("IsAdmin", user.IsEventAdmin.ToString()));
                if (user.IsEventAdmin)
                {
                    identity.AddClaim(new Claim("HasAdminRights", user.IsEventAdmin.ToString()));
                }
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("cookies", new ClaimsPrincipal(identity));
                var eventId = _eventService.GetUserYesterdayEvent(user.Id);
                return Json(new { isSuccess = true, eventId });
            }
            return Json(new { isSuccess = false, error = "Email or password incorrect" });
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync("cookies");
            return RedirectToAction("SignIn", "Account");
        }

        public IActionResult Register()
        {
            return View("~/Views/Account/Register.cshtml");
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
                    var error = string.Join("\n ", result.Errors.Select(a => a.Description));
                    return Json(error);
                }
                ModelState.AddModelError("", "User already exists.");
            }
            var errors = new StringBuilder();

            foreach (var modelState in ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                    errors.AppendLine(error.ErrorMessage);
            }

            return Json(errors.ToString());
        }
    }
}