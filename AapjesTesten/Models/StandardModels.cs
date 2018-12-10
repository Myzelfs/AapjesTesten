using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AapjesTesten.Models
{
    class StandardModels
    {
        public class Product
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
        }

        public class Login
        {
            public string username { get; set; }
            public string password { get; set; }
            public int cmp_id { get; set; }
        }

        public class Email
        {
            public string email { get; set; }
            public string subject { get; set; }
            public string body { get; set; }
            public string bccAdress { get; set; }
            public string ccAdress { get; set; }
        }
    }
}
