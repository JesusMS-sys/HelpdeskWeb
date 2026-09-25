using System.ComponentModel.DataAnnotations;
namespace HelpDeskWeb.ViewModels

{
    public class VeryfiEmailViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }





    }
}
