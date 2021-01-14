using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Pharmacy.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AcType { get; set; }
        public string AcName { get; set; }
        public string Password { get; set; }
    }
}
