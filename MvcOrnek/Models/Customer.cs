using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcOrnek.Models
{
    public class Customer
    {

       // public int Id{ get; set; }

        [Required(ErrorMessage ="isim boş geçilemez")]
        [StringLength(50,ErrorMessage ="max 50 karakter olsun")]
        public string Name { get; set; }
        public string Surname { get; set; }

        [EmailAddress(ErrorMessage ="emailini kontorl et")]
        public string Email { get; set; }
    }
}
