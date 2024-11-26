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
            return View();
        }


        // Отображение страницы с формой
        public IActionResult Contact()
        {
            return View();
        }

        // Метод для обработки формы связи
        [HttpPost]
        [ValidateAntiForgeryToken] // Защита от CSRF атак
        public async Task<IActionResult> Contact(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Здесь можно обработать данные, например, сохранить их в базе данных
                // Или отправить email с данными формы, например, через сервис отправки email

                // После успешной обработки данных, можно перенаправить пользователя на страницу с благодарностью
                return RedirectToAction("ThankYou");
            }

            // Если данные формы не прошли валидацию, то возвращаем форму с ошибками
            ViewBag.Anchor = "contactForm"; // Передаем якорь через ViewBag
            return View("Index", model);   // Возвращаем модель с представлением Index
        }

        // Страница благодарности после отправки формы
        public IActionResult ThankYou()
        {
            return View();
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
