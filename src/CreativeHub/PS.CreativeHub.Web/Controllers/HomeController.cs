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

        // GET: Contact
        [HttpGet]
        public IActionResult Index()
        {
            // Возвращаем страницу с формой
            return View();
        }

        // POST: Contact
        [HttpPost]
        public IActionResult Index(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Логика обработки формы
                // Например, сохранить данные или отправить письмо

                // Можно добавить сообщение об успешной отправке
                ViewBag.SuccessMessage = "Форма успешно отправлена!";
                return View();
            }

            // Если данные некорректны, остаёмся на той же странице с ошибками
            return View(model);
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
