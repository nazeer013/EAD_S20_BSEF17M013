using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myForm1
{
    class UserDTO
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string NIC { get; set; }
        public DateTime DOB { get; set; }
        public string IsCricket { get; set; }
        public string Hockey { get; set; }
        public string Chess { get; set; }
        public string ImageName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
