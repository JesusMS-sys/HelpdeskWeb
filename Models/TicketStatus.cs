using Microsoft.AspNetCore.Identity;
namespace HelpDeskWeb.Models

{
    public class TicketStatus : IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
