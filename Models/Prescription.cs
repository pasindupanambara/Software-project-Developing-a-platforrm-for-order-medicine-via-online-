using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Pharmacy.Models
{
    public class Prescription
    {
        [Key]
        public int OrderId { get; set; }
        public char PatientName { get; set; }
        public int PatientAge { get; set; }
        public char Address { get; set; }
        public char Email { get; set; }
        public int TeleNo { get; set; }
    }
}
