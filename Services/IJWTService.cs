using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Pharmacy.Models;

namespace E_Pharmacy.Services
{
   public interface IJWTService
   {
        public string GenerateJWTtoken(Login user);
    }
}
