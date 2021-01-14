using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Pharmacy.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime Date { get; set; }
        public char PharmacyName { get; set; }
        [ForeignKey("Pharmacy")]
        public int PharmacyID { get; set; }
        public Pharmacy Pharmacy { get; set; }
    }
}
