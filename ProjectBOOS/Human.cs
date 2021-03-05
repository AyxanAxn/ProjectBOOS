using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBOOS
{
    abstract class Human
    {
        public int Id { get; set; }
        public static int StaticId { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public int Age { get; set; } = 0;
        public string PhoneNum { get; set; } = "000-000-000";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string City { get; set; }
        public string Email{ get; set; }

        public Human()
        {
            Id = ++StaticId;
        }
        public override string ToString()
        {
            return $"\nId - {Id}\nName - {Name}\nSurname - {Surname}\nAge - {Age}" +
                $"\nPhone num - {PhoneNum}\nUsername - {Username}\nCity - {City}\nEmail - {Email}";
        }
    }
}