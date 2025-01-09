using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebTeploobmen.Data;
using Microsoft.AspNetCore.Authentication;

namespace WebTeploobmen.Controllers
{
    public class AuthController : Controller
    {
        private readonly WebTeploobmenContext _context;
        public AuthController(WebTeploobmenContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Index(string login, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new("UserId", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, login)
                };
                ClaimsIdentity claimsidentity = new ClaimsIdentity(claims, "Cookies");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentity));

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}