using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Pharmacy.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
    }
}
