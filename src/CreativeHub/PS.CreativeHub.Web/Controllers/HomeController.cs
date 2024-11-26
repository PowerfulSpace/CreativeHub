using Microsoft.AspNetCore.Mvc;
using PS.CreativeHub.Web.Data;
using PS.CreativeHub.Web.Models;
using System.Diagnostics;

namespace PS.CreativeHub.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
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
                // Сохраняем данные формы в базу данных
                var contactEntry = new ContactFormEntry
                {
                    Name = model.Name,
                    Zodiac = model.Zodiac,
                    Phone = model.Phone,
                    Weapon = model.Weapon,
                    Description = model.Description
                };

                _context.ContactFormEntries.Add(contactEntry);
                await _context.SaveChangesAsync(); // Сохраняем изменения в базе данных

                // После успешного сохранения, перенаправляем на страницу благодарности
                return RedirectToAction("ThankYou");
            }

            // Если данные формы не прошли валидацию, возвращаем форму с ошибками
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
