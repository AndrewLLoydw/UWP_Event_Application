using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Models
{
    internal class UserInfo
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Allergies { get; set; }
        public string DiscountCode { get; set; }


        public string FullName => $"{FirstName} {LastName}";
    }
}
