using Microsoft.AspNetCore.Identity;
namespace HelpDeskWeb.Models
{
    public class TicketPriority : IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
