using Microsoft.AspNetCore.Mvc;
using PS.CreativeHub.Web.Models;
using System.Diagnostics;

namespace PS.CreativeHub.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (TempData["FormData"] != null)
            {
                var formData = Newtonsoft.Json.JsonConvert.DeserializeObject<ContactFormModel>((string)TempData["FormData"]);
                ViewBag.FormData = formData;
                TempData.Remove("FormData"); // Очистка
            }

            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
                TempData.Remove("ErrorMessage"); // Очистка
            }

            return View();
        }


        // GET: Contact
        [HttpGet]
        public IActionResult ContactForm()
        {
            return View();
        }

        // POST: Contact
        [HttpPost]
        public IActionResult SubmitContact(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Логика обработки данных
                TempData["SuccessMessage"] = "Форма успешно отправлена!";
                return RedirectToAction("ContactForm");
            }

            // Если есть ошибки, возвращаемся к форме с ними
            return View("ContactForm", model);
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
