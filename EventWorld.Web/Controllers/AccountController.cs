using EventWorld.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventWorld.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserDTO> _userManager;

        public AccountController(UserManager<UserDTO> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult SignIn()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (ModelState.IsValid)
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
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("cookies", new ClaimsPrincipal(identity));
                    return Ok();
                }
            }

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync("cookies");
            return View("~/Views/Account/Login.cshtml");
        }
    }
}