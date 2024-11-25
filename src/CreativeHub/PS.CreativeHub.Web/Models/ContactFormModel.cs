using System.ComponentModel.DataAnnotations;

namespace PS.CreativeHub.Web.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Имя обязательно.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Знак зодиака обязателен.")]
        public string Zodiac { get; set; } = null!;

        [Required(ErrorMessage = "Номер телефона обязателен.")]
        [Phone(ErrorMessage = "Введите корректный номер телефона.")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Любимое оружие обязательно.")]
        public string Weapon { get; set; } = null!;

        [Required(ErrorMessage = "Описание обязательно.")]
        public string Description { get; set; } = null!;
    }
}
