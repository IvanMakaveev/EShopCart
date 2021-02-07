using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShopCart.Models
{
    public class OrderInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Number { get; set; }

        [Display(Name = "Other Address Info")]
        public string Other { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CityItems { get; set; }
    }
}
