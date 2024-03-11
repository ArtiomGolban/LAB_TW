using System.ComponentModel.DataAnnotations;

namespace BikeRental.Web.Models
{
    public class UserLogin
    {
        [Required]
        public string Credentials { get; set; }

        [Required]
        public string Password { get; set; }
    }
}