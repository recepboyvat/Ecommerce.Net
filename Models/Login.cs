using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Recepboyvat.ECommerceMVCWeb.Models
{
    public class Login
    {
        [Required]
        [DisplayName("Kullanici Adi")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Parola")]
        public string Password { get; set; }
        
        [DisplayName("Beni Hatirla")]
        public bool RememberMe { get; set; }
    }
}