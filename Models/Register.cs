using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Recepboyvat.ECommerceMVCWeb.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adiniz")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Soyadiniz")]
        public string SurName { get; set; }

        [Required]
        [DisplayName("Kullanici Adi")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Eposta")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir eposta adresi giriniz.")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Parola")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Parola tekrar")]
        [Compare("Password",ErrorMessage ="Parolalar uyuşmuyor")]
        public string RePassword { get; set; }
    }
}