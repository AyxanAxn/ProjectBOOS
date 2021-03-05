using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBOOS
{
    class Vacancy
    {
        public Vacancy()
        {
            ID = ++StaticID;
        }

        public int ID { get; set; }
        public static int StaticID { get; set; } = 0;
        public string Place { get; set; } = "Baku";
        public double Salary { get; set; } = 500;
        public string Category { get; set; }
        public DateTime StartTime { get; set; }
      
        public DateTime EndTime { get; set; }
        public string Requirement { get; set; } = "";
        public string InformationAboutJob { get; set; } = "";
        public string Email { get; set; } = "@gmail.com";
        public int Experience { get; set; } = 0;

        public override string ToString()
        {
            return $"\n\nId : {ID}\t\tStart time : {StartTime.ToShortTimeString()} - {EndTime.ToShortTimeString()}\nPlace : {Place}\nCategory - {Category}\nSalary : {Salary}\nRequirement - {Requirement}\nInformation about : {InformationAboutJob},\nEmail : {Email}";
        }

    }
}
