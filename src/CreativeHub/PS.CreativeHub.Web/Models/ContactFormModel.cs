using System.ComponentModel.DataAnnotations;

namespace PS.CreativeHub.Web.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Имя обязательно.")]
        [Display(Name = "Ваше имя")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Знак зодиака обязателен.")]
        [Display(Name = "Знак зодиака")]
        public string Zodiac { get; set; } = null!;


        [Required(ErrorMessage = "Номер телефона обязателен.")]
        [RegularExpression(@"^\+375 (25|29|33|44) \d{3}-\d{2}-\d{2}$|^8 0(25|29|33|44) \d{3}-\d{2}-\d{2}$",
        ErrorMessage = "Введите номер в формате +375 XX XXX-XX-XX или 8 0XX XXX-XX-XX.")]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; } = null!;


        [Required(ErrorMessage = "Любимое оружие обязательно.")]
        [Display(Name = "Любимое оружие")]
        public string Weapon { get; set; } = null!;

        [Required(ErrorMessage = "Описание обязательно.")]
        [Display(Name = "Описание")]
        public string Description { get; set; } = null!;
    }
}
