using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Pharmacy.Service
{
    public interface IOrderService
    {
        Task<string> SaveImage(IFormFile ImageData);

        void DeleteImage(String imageName);
    }
}
