using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Pharmacy.Models
{
    public class Customer
    {   
        [Key]
        public int CustId { get; set; }
        public string Email { get; set; }
        public int TeleNo { get; set; }
    }
}
