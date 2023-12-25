using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading.Tasks;
using WebAPI.Models;
using WebMVC.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InterfaceClient _IClient;

        public HomeController(ILogger<HomeController> logger, InterfaceClient iClient)
        {
            _logger = logger;
            _IClient = iClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var brands = await _IClient.GetAllBrands();
            return View(brands);
            //return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateBrand()
        {
            var users = await _IClient.GetAllUsers();
            List<int> ids = new List<int>();
            foreach (var user in users)
                ids.Add(user.UserId);
            ViewBag.Users = ids;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromForm] BrandDTO brand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _IClient.GetUser(brand.BrandUserId);
                    brand.BrandUserId = user.UserId;
                }
                catch (Exception ex)
                {
                    var users = await _IClient.GetAllUsers();
                    List<int> ids = new List<int>();
                    foreach (var user in users)
                        ids.Add(user.UserId);
                    ViewBag.Users = ids;
                    return View("CreateBrand");
                }
                await _IClient.CreateBrand(brand);
                return RedirectToAction("Index");
            }
            else return View("CreateBrand");
        }

        [HttpGet]
        public async Task<IActionResult> EditBrandView([FromQuery] string search)
        {
            var brands = await _IClient.GetBrand(Convert.ToInt32(search));

            var users = await _IClient.GetAllUsers();
            List<int> ids = new List<int>();
            foreach (var user in users)
                ids.Add(user.UserId);
            ViewBag.Users = ids;

            return View(brands);
        }
        [HttpPost]
        public async Task<IActionResult> EditBrand([FromForm] Brand brand)
        {
            if (ModelState.IsValid)
                await _IClient.EditBrand(brand.BrandId, brand);
            else return View("EditBrandView");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromForm] Users user)
        {
            if (ModelState.IsValid)
                await _IClient.SignUp(user);
            else return View("SignUp");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SignIn()
        {
            return View();
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromForm] UserDTO user)
        {
            if (ModelState.IsValid)
            {
                var response = await _IClient.SignIn(user);
                if (response == "200")
                    return RedirectToAction("Index");
            }
            else return View("SignIn");
            return Redirect("/");
        }
        public async Task<IActionResult> LogoutUser()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}