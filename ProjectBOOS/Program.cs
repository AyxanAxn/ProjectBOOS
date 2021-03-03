using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBOOS
{
    class Program
    {
        static void Main(string[] args)
        {
            CV cv = new CV() {
                Experience = 1,
                UniversitetyScore = 700,
                Skills = "C#, C++",
                Education = "Univercitety",
                Certificate = true,
                GitHub="AyxanAxn",
                Linkedin="AyxanAxn"

            };
            //Console.WriteLine(cv);
            Employee employee = new Employee();
            Employee employee1 = new Employee() ;

            employee.AddCV("Computer Science", "123", 123, "Helpdesk, Python", "STMHSTM", new DateTime(2011, 01, 01), DateTime.Now, "Azerbaijani, English", true, "git", "link");
            employee.AddCV("Computer Science", "123", 123, "Helpdesk, Python", "STMHSTM", new DateTime(2011, 01, 01), DateTime.Now, "Azerbaijani, English", true, "git", "link");
            employee.AddCV("Computer Science", "123", 123, "Helpdesk, Python", "STMHSTM", new DateTime(2011, 01, 01), DateTime.Now, "Azerbaijani, English", true, "git", "link");
            employee1.AddCV("Computer Science", "123", 123, "Helpdesk, Python", "STMHSTM", new DateTime(2011, 01, 01), DateTime.Now, "Azerbaijani, English", true, "git", "link");
            employee1.AddCV("Computer Science", "123", 123, "Helpdesk, Python", "STMHSTM", new DateTime(2011, 01, 01), DateTime.Now, "Azerbaijani, English", true, "git", "link");
            //     employee.ShowCV(); 
            employee.DeleteCV(2);
            employee.AddCV("Computer Science1111", "123", 123, "Helpdesk, Python", "STMHSTM", new DateTime(2011, 01, 01), DateTime.Now, "Azerbaijani, English", true, "git", "link");
            employee.UpdateCVForEducation(3, "Dassag");
            // employee.UpdateCVForCertificate(3, false);
            //employee.UpdateCVForEndTime(3, new DateTime(2001, 10, 06));
            //  employee.ShowCV();

           // Employee[] Arr = new Employee(employee, employee1);



            Employer employer = new Employer();
            Employer employer1 = new Employer();

            employer.AddVacancy("Yasamal",1500,new DateTime(2020,10,06,8,0,0,0),new DateTime(2020,10,06,6,0,2,2),"qesey","mmc","Axx@gmail.com");
            employer.ShowVacancies();
            employee.Bid(7);
            //employee.ShowCV();
            try
            {

           // employer.AcceptCV(employee,7);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            employee.showBidList();
            employer.ShowAcceptList();
           


        }
    }
}
