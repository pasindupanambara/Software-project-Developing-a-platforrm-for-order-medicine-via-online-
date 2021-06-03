using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Pharmacy.Models
{
    public class Pharmacy

    {
        [Key]
        public int Id { get; set; }
        public string RegNo { get; set; }
        public string Pharmacyname { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Email { get; set; }
        public string TeleNo { get; set; }
        public string Password { get; set; }
        public string Pharmacyimagename { get; set; }

        [NotMapped]
        public IFormFile Pharmacyimagefile { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }

        public string UserRole = "Pharmacy";
        internal int pharmacyId;
    }
}
