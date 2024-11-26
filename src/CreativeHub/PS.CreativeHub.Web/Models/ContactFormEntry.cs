namespace PS.CreativeHub.Web.Models
{
    public class ContactFormEntry
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Zodiac { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Weapon { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
