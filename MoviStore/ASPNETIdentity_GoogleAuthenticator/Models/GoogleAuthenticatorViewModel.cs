using System.ComponentModel.DataAnnotations;

namespace IdentitySample.Models
{
    public class GoogleAuthenticatorViewModel
    {
        [Required]
        public string Code { get; set; }

        public string SecretKey { get; set; }

        public string BarcodeUrl { get; set; }
    }
}