using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectBOOS
{
    class Program
    {
        static void Notifications(Employee employee, string choose)
        {

            if (choose == "Acc")
            {
                employee.Notifi.Add("CV was accepted!");

            }
            else if (choose == "Ref")
            {
                employee.Notifi.Add("Refused.");
            }
            else Console.WriteLine("Wait your answer.");
        }
        static string signIn(List<Employee> employee, List<Employer> employer, string username, string password)
        {
            foreach (var item in employee)
            {
                if (item.Username == username)
                {
                    if (item.Password == password)
                    {
                        return "Employee";
                    }
                }
            }
            foreach (var item in employer)
            {
                if (item.Username == username)
                {
                    if (item.Password == password)
                    {
                        return "Employers";
                    }
                }
            }
            return "Nothings";

        }
        static void PrintMenuForEmployee()
        {
            //bir List yaratmaq notification listi.
            // Notifications 
            Console.WriteLine("1)Your CV");
            Console.WriteLine("2)Information about you");
            Console.WriteLine("3)Add CV");
            Console.WriteLine("4)Update CV");
            Console.WriteLine("5)Delete CV");
            Console.WriteLine("6)Bid");
            Console.WriteLine("7)Refuse your bid");
            Console.WriteLine("8)Show vacancies");
            Console.WriteLine("9)Show favorit list");
            Console.WriteLine("10)Notifications");
            Console.WriteLine("11)Filtering");
            Console.WriteLine("20)Exit");
        }
        static void printForEmployer()
        {
            Console.WriteLine("1)Your vacancy/vacancies");
            Console.WriteLine("2)Your information");
            Console.WriteLine("3)Add vacancy");
            Console.WriteLine("4)Delete vacancy");
            Console.WriteLine("5)Update vacancy");
            Console.WriteLine("6)Accept bid");
            Console.WriteLine("7)Refuse bid");
            Console.WriteLine("10)Exit");

        }
        static void PrintFilterinSystem()
        {

            Console.WriteLine("\n1)City\n2)Category\n3)Salary\n4)Experienxe\n");
        }
        static void showEmployerUpdatList()
        {

            Console.WriteLine("\n1)Update place\n2)Update salary\n3)Update Requirement\n4)Update info\n5)Update gmail\n6)Update experience\n7)Update start time\n8)update endtime\n");
        }
        static Employee FindEmployee(List<Employee> employees, string username)
        {
            Employee employee = new Employee();
            Employer employer = new Employer();
            foreach (var item in employees)
            {
                if (username == item.Username)
                {
                    return item;
                }

            }
            return employee;
        }
        static Employer FindEmployer(List<Employer> employers, string username)
        {
            Employer employer = new Employer();
            foreach (var item in employers)
            {
                if (username == item.Username)
                {
                    return item;
                }

            }
            return employer;
        }
        static void PrintCities()
        {
            Console.WriteLine("\n1)Baku\n2)Ganja\n3)Tovuz\n4)Balaken\n5)Aqhstafa\n6)Susha\n7)Xankendi\n8)Cebrayil\n");
        }
        static void PrintCategories()
        {
            Console.WriteLine("\n1)IT\n2)Marketting\n3)Design\n4)Programmer\n5)Support\n6)Sales managger\n7)Managger\n8)Teacher\n");

        }
        static Employer FindFavoritForEmployee(List<Employer> emp, int id)
        {
            Employer employer = new Employer();
            foreach (var empItem in emp)
            {

                foreach (var item in empItem.vacancies)
                {
                    if (item.ID == id)
                    {
                        return empItem;
                    }
                }
            }
            return employer;
        }
        static Employee FindFavoritForEmployeee(List<Employee> emp, int id)
        {
            Employee employee = new Employee();
            foreach (var empItem in emp)
            {

                foreach (var item in empItem.cv)
                {
                    if (item.ID == id)
                    {
                        return empItem;
                    }
                }
            }
            return employee;
        }
        static void printLanguage()
        {
            Console.WriteLine("1)English\n2)Spain\n3)Russian\n4)Turkish\n5)French\n");
        }
        static void printForEducation()
        {
            Console.WriteLine("1)Bakalavr\n2)Master\n3)Doktorantura");
        }
        static void PrintForUpgrate()
        {
            Console.WriteLine("\n1)Upgrate profession\n2)Upgrate scool N\n3)Upgrate company\n4)Upgrate experience\n5)Upfrate skills\n6)Upgrate certificate\n7)Uprate git\n8)Upgrate linkedin\n9)Upgrate language\n10)Upgrate start time\n11)Upgrate end time\n12)Education");

        }

        static void Main(string[] args)
        {

            List<Employee> employees =FileHelper.ReadFromEmployee("Employee.json");
           List<Employer> employers = FileHelper.ReadFromEmployer("Employer.json");
            #region Employees


            //Employee employee = new Employee
            //{
            //    Age = 19,
            //    Name = "Ayxan",
            //    Surname = "Axundov",
            //    PhoneNum = "070-123-45-67",
            //    Username = "Ayxan",
            //    Password = "Ayxan1",
            //    City = Cities.Baku,
            //    Email = "axundovayxan@gmail.com"
            //};
            //Employee employee1 = new Employee
            //{
            //    Age = 19,
            //    Name = "Zaur",
            //    Surname = "Caferov",
            //    PhoneNum = "050-123-45-67",
            //    Username = "Zaur",
            //    Password = "Zaur1",
            //    City = Cities.Aqhstafa,
            //    Email = "zaurceferov@gmail.com"
            //};
            //Employee employee2 = new Employee
            //{
            //    Age = 21,
            //    Name = "Elvin",
            //    Surname = "Jamalzade",
            //    PhoneNum = "055-123-45-67",
            //    Username = "Elvin",
            //    Password = "Elvin1",
            //    City = Cities.Balaken,
            //    Email = "elvincamalzade@gmail.com"
            //};
            //Employee employee3 = new Employee
            //{
            //    Age = 20,
            //    Name = "Elgun",
            //    Surname = "Abbasguliyev",
            //    PhoneNum = "051-123-45-67",
            //    Username = "Elgun",
            //    Password = "Elgun1",
            //    City = Cities.Ganja,
            //    Email = "elgunabbasguliyev@gmail.com"
            //};

            //Employee employee4 = new Employee
            //{
            //    Age = 20,
            //    Name = "Resul",
            //    Surname = "Osmanli",
            //    PhoneNum = "051-321-45-67",
            //    Username = "Resul",
            //    Password = "Resul1",
            //    City = Cities.Susha,
            //    Email = "resulosmanli@gmail.com"
            //};

            //Employee employee5 = new Employee
            //{
            //    Age = 20,
            //    Name = "Amin",
            //    Surname = "Aliyev",
            //    PhoneNum = "051-321-45-67",
            //    Username = "Amin",
            //    Password = "Amin1",
            //    City = Cities.Susha,
            //    Email = "aminaliyev@gmail.com"
            //};
            //Employee employee6 = new Employee
            //{
            //    Age = 20,
            //    Name = "Metin",
            //    Surname = "Rzayev",
            //    PhoneNum = "077-876-54-32",
            //    Username = "Metin",
            //    Password = "Metin1",
            //    City = Cities.Xankendi,
            //    Email = "metinrzayev@gmail.com"
            //};


            //employees.Add(employee);
            //employees.Add(employee1);
            //employees.Add(employee2);
            //employees.Add(employee3);
            //employees.Add(employee4);
            //employees.Add(employee5);
            //employees.Add(employee6);

            //employee.AddCV(Categories.Programmer, Education.Bakalavr, "1", 2, 500, "C, C++, C# HTML, CSS", "SOCAR, BP", new DateTime(2021, 03, 03, 09, 00, 00), new DateTime(2021, 03, 03, 18, 00, 00), Language.English, true, "axundov", "axun");
            //employee1.AddCV(Categories.Design, Education.Bakalavr, "1", 1, 150, "Photoshop", "Design.az", new DateTime(2021, 03, 03, 09, 00, 00), new DateTime(2021, 03, 03, 18, 00, 00), Language.Turkish, true, "Zaur", "zaur");
            //employee2.AddCV(Categories.IT, Education.Master, "1", 4, 600, "Network, Windows server", "Mincrosoft", new DateTime(2021, 03, 03, 09, 00, 00), new DateTime(2021, 03, 03, 18, 00, 00), Language.English, true, "Elvin", "Elvin123");
            //employee3.AddCV(Categories.Marketing, Education.Doktorantura, "1", 3, 523, "Market marketing", "Bravo, Araz, Oba market", new DateTime(2021, 03, 03, 09, 00, 00), new DateTime(2021, 03, 03, 18, 00, 00), Language.English, true, "eabasguliyev", "MarketingElgun");
            //employee4.AddCV(Categories.Support, Education.Bakalavr, "1", 1, 590, "Axrana", "Embawood", new DateTime(2021, 03, 03, 09, 00, 00), new DateTime(2021, 03, 03, 18, 00, 00), Language.English, true, "ResulAxran", "Daveriya123");
            //employee5.AddCV(Categories.SalesManager, Education.Bakalavr, "1", 3, 560, "Satis islerine baxiram. ingilis dilinnen aram yaxshi deyil amma oz uzerimde isleyirem :-)", "MZ group", new DateTime(2021, 03, 03, 09, 00, 00), new DateTime(2021, 03, 03, 18, 00, 00), Language.Turkish, true, "Amin", "Ameno23");
            //employee6.AddCV(Categories.Manager, Education.Bakalavr, "1", 2, 500, "Men meneccerem", "Summer hotel", new DateTime(2021, 03, 03, 09, 00, 00), new DateTime(2021, 03, 03, 18, 00, 00), Language.English, true, "Metin", "Metinoo");
            //foreach (var item in employees)
            //{
            //    Console.WriteLine(item);
            //    item.ShowCV();
            //}
          //FileHelper.WriteToFIleEmployee("Employee.json", employees);
            #endregion Employees
            #region Employers



            //Employer employer = new Employer
            //{
            //    Age = 28,
            //    City = Cities.Baku,
            //    Email = "Mehrac@gmail.com",
            //    Name = "Mehrac",
            //    Surname = "Letifli",
            //    PhoneNum = "012-543-21-76",
            //    Username = "Mehrac",
            //    Password = "Mehrac1"

            //};
            //Employer employer1 = new Employer
            //{
            //    Age = 30,
            //    City = Cities.Baku,
            //    Email = "Jhon@gmail.com",
            //    Name = "Jhon",
            //    Surname = "Jhonlu",
            //    PhoneNum = "077-111-11-11",
            //    Username = "John",
            //    Password = "John1"

            //};
            //Employer employer2 = new Employer
            //{
            //    Age = 35,
            //    City = Cities.Tovuz,
            //    Email = "Aleksey@gmail.com",
            //    Name = "Aleksey",
            //    Surname = "Alekseyli",
            //    PhoneNum = "077-222-22-22",
            //    Username = "Alek",
            //    Password = "Alek1"

            //};
            //employers.Add(employer);
            //employers.Add(employer1);
            //employers.Add(employer2);
            //employer.AddVacancy(Cities.Baku, Categories.Programmer, 2000, new DateTime(2021, 03, 03, 09, 00, 00), new DateTime(2021, 03, 03, 18, 00, 00), "C ve c++ -i yaxsi bilmeli ve stepin menzunu olmaildir.", Categories.Programmer, employer.Email);
            //employer1.AddVacancy(Cities.Aqhstafa, Categories.IT, 3000, new DateTime(2021, 03, 03, 09, 00, 00), new DateTime(2021, 03, 03, 18, 00, 00), "Windows server minimum CCNA ve CCIE sertifikatlari olmali + olaraq boyuk kollektivle  islemeyi bacarmalidir!", Categories.IT, employer1.Email);
            //employer2.AddVacancy(Cities.Tovuz, Categories.Teacher, 3500, new DateTime(2021, 03, 03, 09, 00, 00), new DateTime(2021, 03, 03, 18, 00, 00), "Ders kecmesi yaxsi olmali tecrubeli adam teleb olunur", Categories.IT, employer2.Email);
            //FileHelper.WriteToFIleEmployer("Employer.json", employers);
            #endregion Employers


            Console.Clear();
            //internal void Add(string education, int experience, int universitetyScore, string skills, bool sertificate, string gitHub, string linkedin, string language)
            //string profession, string school, int experience, int score, string skills, string companies, DateTime startTime, DateTime endTime, string languages, bool certificate, string github, string linkedin
            string scool, profession, skills, Git, Linkedin, language, companies, forID;
            string userName, passWord, forWritingSomething;
            int count = 0, experience, univecityScore, enteringID;
            bool Sertificate;
            DateTime date1, date2;

            //(string place, double salary, DateTime StartTime, DateTime EndTime, string Requirement, string InformationAboutJob, string Email)
            string city, category;
            double salary;
            DateTime date3, date4;
            string Requirement;
            string informationAbout;
            string Email, forUpdate;
            string education;



            while (true)
            {
                Console.WriteLine("Enter username : ");
                userName = Console.ReadLine();
                Console.WriteLine("Enter Password : ");
                passWord = Console.ReadLine();
                Console.Clear();
                if (signIn(employees, employers, userName, passWord) == "Employee")
                {
                    while (true)
                    {


                        PrintMenuForEmployee();
                        forWritingSomething = Console.ReadLine();
                        switch (forWritingSomething)
                        {
                            case "1":
                                {
                                    Console.WriteLine("Your CV : ");
                                    FindEmployee(employees, userName).ShowCV();
                                    break;
                                }
                            case "2":
                                {
                                    Console.WriteLine("Information about you : ");
                                    Console.WriteLine($"Employee menu : {FindEmployee(employees, userName)}");
                                    break;
                                }

                            case "3":
                                {
                                    #region AddCv

                                    Console.WriteLine("Whitch vacancy do you want : ");
                                    try
                                    {
                                        Console.WriteLine("Profession : ");
                                        PrintCategories();
                                        profession = Console.ReadLine();
                                        if (profession == "1") category = Categories.IT;
                                        else if (profession == "2") category = Categories.Marketing;
                                        else if (profession == "3") category = Categories.Design;
                                        else if (profession == "4") category = Categories.Programmer;
                                        else if (profession == "5") category = Categories.Support;
                                        else if (profession == "6") category = Categories.SalesManager;
                                        else if (profession == "7") category = Categories.Manager;
                                        else if (profession == "8") category = Categories.Teacher;
                                        else
                                        {
                                            category = Categories.IdontKnow;
                                        }

                                        Console.WriteLine("Scool : ");
                                        scool = Console.ReadLine();
                                        Console.WriteLine("Experience : ");
                                        experience = int.Parse(Console.ReadLine());
                                        Console.WriteLine();
                                        Console.WriteLine("Univercity score : ");
                                        univecityScore = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Skills : ");
                                        skills = Console.ReadLine();
                                        Console.WriteLine("Company : ");
                                        companies = Console.ReadLine();
                                        Console.WriteLine("Education : ");
                                        printForEducation();
                                        companies = Console.ReadLine();

                                        printForEducation();
                                        if (companies == "1") education = Education.Bakalavr;
                                        else if (companies == "2") education = Education.Master;
                                        else if (companies == "3") education = Education.Doktorantura;
                                        else education = Education.Nothing;

                                        
                                        date1 = DateTime.Now;

                                        date2 = DateTime.Now.AddMonths(1);
                                        Console.WriteLine("Language : ");
                                        printLanguage();
                                        language = Console.ReadLine();
                                        if (language == "1") language = Language.English;
                                        else if (language == "2") language = Language.Spain;
                                        else if (language == "3") language = Language.Russian;
                                        else if (language == "4") language = Language.Turkish;
                                        else if (language == "5") language = Language.French;
                                        else language = Language.IdontKnowNothing;
                                        Console.WriteLine("Certificate : ");
                                        Sertificate = bool.Parse(Console.ReadLine());
                                        Console.WriteLine("Git account : ");
                                        Git = Console.ReadLine();
                                        Console.WriteLine("Linkedin account : ");
                                        Linkedin = Console.ReadLine();

                                        FindEmployee(employees, userName).AddCV(profession, education, scool, experience, univecityScore, skills, companies, date1, date2, language, Sertificate, Git, Linkedin); ;
                                        FileHelper.WriteToFIleEmployee("Employee.json", employees);

                                    }
                                    catch (Exception ex)
                                    {

                                        Console.WriteLine(ex.Message);
                                    }
                                    Console.WriteLine($"Your CV :\n");
                                    FindEmployee(employees, userName).ShowCV();
                                    break;
                                    #endregion AddCv
                                }
                            case "4":
                                {
                                    // Update eve qalsin
                                    Console.WriteLine("Whichone do you want to upgrate : ");
                                    string upgrating;
                                    PrintForUpgrate();
                                    upgrating = Console.ReadLine();
                                    //n1)Upgrate education\n2)Upgrate scool N\n3)Upgrate company\n4)Upgrate experience\n5)Upfrate skills\n6)Upgrate certificate\n7)Uprate git\n8)Upgrate linkedin\n9)Upgrate language\n10)Upgrate start time\n11)Upgrate end time");
                                    try
                                    {
                                        if (upgrating == "1")
                                        {
                                            Console.Clear();
                                            FindEmployee(employees, userName).ShowCV();
                                            Console.WriteLine("Which ID do you want to update : ");
                                            enteringID = int.Parse(Console.ReadLine());
                                            Console.WriteLine("What do you want to write : ");
                                            PrintCategories();
                                            profession = Console.ReadLine();
                                            if (profession == "1") category = Categories.IT;
                                            else if (profession == "2") category = Categories.Marketing;
                                            else if (profession == "3") category = Categories.Design;
                                            else if (profession == "4") category = Categories.Programmer;
                                            else if (profession == "5") category = Categories.Support;
                                            else if (profession == "6") category = Categories.SalesManager;
                                            else if (profession == "7") category = Categories.Manager;
                                            else if (profession == "8") category = Categories.Teacher;
                                            else
                                            {
                                                category = Categories.IdontKnow;
                                            }
                                            FindEmployee(employees, userName).UpdateCVForProf(enteringID, category);
                                            FindEmployee(employees, userName).ShowCV();
                                            FileHelper.WriteToFIleEmployee("Employee.json", employees);
                                        }

                                        else if (upgrating == "2")
                                        {
                                            Console.Clear();
                                            FindEmployee(employees, userName).ShowCV();
                                            Console.WriteLine("Which ID do you want to update : ");
                                            enteringID = int.Parse(Console.ReadLine());
                                            Console.WriteLine("What do you want to write : ");
                                            scool = Console.ReadLine();
                                            FindEmployee(employees, userName).UpdateCVForScoolNO(enteringID, scool);
                                            FindEmployee(employees, userName).ShowCV();
                                            FileHelper.WriteToFIleEmployee("Employee.json", employees);
                                        }
                                        else if (upgrating == "3")
                                        {
                                            Console.Clear();
                                            FindEmployee(employees, userName).ShowCV();
                                            Console.WriteLine("Which ID do you want to update : ");
                                            enteringID = int.Parse(Console.ReadLine());
                                            Console.WriteLine("What do you want to write : ");
                                            forUpdate = Console.ReadLine();
                                            FindEmployee(employees, userName).UpdateCVForCompanies(enteringID, forUpdate);
                                            FindEmployee(employees, userName).ShowCV();
                                            FileHelper.WriteToFIleEmployee("Employee.json", employees);
                                        }
                                        else if (upgrating == "4")
                                        {
                                            Console.Clear();
                                            FindEmployee(employees, userName).ShowCV();
                                            Console.WriteLine("Which ID do you want to update : ");
                                            enteringID = int.Parse(Console.ReadLine());
                                            Console.WriteLine("What do you want to write : ");
                                            experience = int.Parse(Console.ReadLine());
                                            FindEmployee(employees, userName).UpdateCVForExperience(enteringID, experience);
                                            FindEmployee(employees, userName).ShowCV();
                                            FileHelper.WriteToFIleEmployee("Employee.json", employees);
                                        }
                                        else if (upgrating == "5")
                                        {
                                            Console.Clear();
                                            FindEmployee(employees, userName).ShowCV();
                                            Console.WriteLine("Which ID do you want to update : ");
                                            enteringID = int.Parse(Console.ReadLine());
                                            Console.WriteLine("What do you want to write : ");
                                            forUpdate = Console.ReadLine();
                                            FindEmployee(employees, userName).UpdateCVForSkills(enteringID, forUpdate);
                                            FindEmployee(employees, userName).ShowCV();
                                            FileHelper.WriteToFIleEmployee("Employee.json", employees);
                                        }
                                        else if (upgrating == "6")
                                        {
                                            Console.Clear();
                                            FindEmployee(employees, userName).ShowCV();
                                            Console.WriteLine("Which ID do you want to update : ");
                                            enteringID = int.Parse(Console.ReadLine());
                                            Console.WriteLine("What do you want to write : ");
                                            Sertificate = bool.Parse(Console.ReadLine());
                                            FindEmployee(employees, userName).UpdateCVForCertificate(enteringID, Sertificate);
                                            FindEmployee(employees, userName).ShowCV();
                                            FileHelper.WriteToFIleEmployee("Employee.json", employees);
                                        }
                                        else if (upgrating == "7")
                                        {
                                            Console.Clear();
                                            FindEmployee(employees, userName).ShowCV();
                                            Console.WriteLine("Which ID do you want to update : ");
                                            enteringID = int.Parse(Console.ReadLine());
                                            Console.WriteLine("What do you want to write : ");
                                            forUpdate = Console.ReadLine();
                                            FindEmployee(employees, userName).UpdateCVForGitHub(enteringID, forUpdate);
                                            FindEmployee(employees, userName).ShowCV();
                                            FileHelper.WriteToFIleEmployee("Employee.json", employees);
                                        }
                                        else if (upgrating == "8")
                                        {
                                            Console.Clear();
                                            FindEmployee(employees, userName).ShowCV();
                                            Console.WriteLine("Which ID do you want to update : ");
                                            enteringID = int.Parse(Console.ReadLine());
                                            Console.WriteLine("What do you want to write : ");
                                            forUpdate = Console.ReadLine();
                                            FindEmployee(employees, userName).UpdateCVForLinkedin(enteringID, forUpdate);
                                            FindEmployee(employees, userName).ShowCV();
                                            FileHelper.WriteToFIleEmployee("Employee.json", employees);
                                        }
                                        else if (upgrating == "9")
                                        {
                                            Console.Clear();
                                            FindEmployee(employees, userName).ShowCV();
                                            Console.WriteLine("Which ID do you want to update : ");
                                            enteringID = int.Parse(Console.ReadLine());
                                            Console.WriteLine("What do you want to write : ");
                                            printLanguage();
                                            forUpdate = Console.ReadLine();
                                            if (forUpdate == "1") language = Language.English;
                                            else if (forUpdate == "2") language = Language.Spain;
                                            else if (forUpdate == "3") language = Language.Russian;
                                            else if (forUpdate == "4") language = Language.Turkish;
                                            else if (forUpdate == "5") language = Language.French;
                                            else language = Language.IdontKnowNothing;
                                            FindEmployee(employees, userName).UpdateCVForLanguage(enteringID, language);
                                            FindEmployee(employees, userName).ShowCV();
                                            FileHelper.WriteToFIleEmployee("Employee.json", employees);
                                        }
                                        else if (upgrating == "10")
                                        {
                                            Console.Clear();
                                            FindEmployee(employees, userName).ShowCV();
                                            Console.WriteLine("Which ID do you want to update : ");
                                            enteringID = int.Parse(Console.ReadLine());
                                            Console.WriteLine("What do you want to write : ");
                                            date1 = DateTime.Parse(Console.ReadLine());
                                            FindEmployee(employees, userName).UpdateCVForStartTime(enteringID, date1);
                                            FindEmployee(employees, userName).ShowCV();
                                            FileHelper.WriteToFIleEmployee("Employee.json", employees);
                                        }
                                        else if (upgrating == "11")
                                        {
                                            Console.Clear();
                                            FindEmployee(employees, userName).ShowCV();
                                            Console.WriteLine("Which ID do you want to update : ");
                                            enteringID = int.Parse(Console.ReadLine());
                                            Console.WriteLine("What do you want to write : ");
                                            date1 = DateTime.Parse(Console.ReadLine());
                                            FindEmployee(employees, userName).UpdateCVForEndTime(enteringID, date1);
                                            FindEmployee(employees, userName).ShowCV();
                                            FileHelper.WriteToFIleEmployee("Employee.json", employees);
                                        }
                                        else if (upgrating == "12")
                                        {
                                            Console.Clear();
                                            FindEmployee(employees, userName).ShowCV();
                                            Console.WriteLine("Which ID do you want to update : ");
                                            enteringID = int.Parse(Console.ReadLine());
                                            printForEducation();
                                            Console.WriteLine("What do you want to write : ");
                                            companies = Console.ReadLine();
                                            if (companies == "1") education = Education.Bakalavr;
                                            else if (companies == "2") education = Education.Master;
                                            else if (companies == "3") education = Education.Doktorantura;
                                            else education = Education.Nothing;
                                            FindEmployee(employees, userName).UpdateCVForEducation(enteringID, education);
                                            FindEmployee(employees, userName).ShowCV();
                                            FileHelper.WriteToFIleEmployee("Employee.json", employees);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;
                                }
                            case "5":
                                {
                                    // Delete CV
                                    bool a;
                                    int b;
                                    FindEmployee(employees, userName).ShowCV();
                                    Console.WriteLine("Which cv do you want to delete (Enter ID): ");
                                    do
                                    {
                                        forID = Console.ReadLine();
                                        a = int.TryParse(forID, out int result);
                                        if (a == false)
                                        {
                                            Console.WriteLine("I want int not string!");
                                        }

                                    } while (a != true);
                                    b = Convert.ToInt32(forID);
                                    FindEmployee(employees, userName).DeleteCV(b);
                                    // fh.WriteToFIleEmployee("Employee.json", employees);
                                    FindEmployee(employees, userName).ShowCV();
                                    FileHelper.WriteToFIleEmployee("Employee.json", employees);
                                    break;
                                }
                            case "6":
                                {
                                    try
                                    {
                                        int id, vacancyID;
                                        foreach (var item in employers)
                                        {
                                            item.ShowVacancies();
                                        }
                                        Console.WriteLine("Enter the id of employer : ");
                                        vacancyID = int.Parse(Console.ReadLine());
                                        FindEmployee(employees, userName).ShowCV();
                                        Console.WriteLine("Enter the id of your cv : ");
                                        id = int.Parse(Console.ReadLine());
                                        FindEmployee(employees, userName).Bid(FindFavoritForEmployee(employers, vacancyID), id, vacancyID);
                                        Console.WriteLine("Your cv sended successufully!");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        FindEmployee(employees, userName).showBidList();
                                        Console.ResetColor();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;
                                }
                            case "8":
                                {
                                    int idFav;
                                    try
                                    {
                                        foreach (var item in employers)
                                        {
                                            item.ShowVacancies();
                                        }
                                        Console.WriteLine("---------------------------");
                                        Console.WriteLine("Enter the ID : ");

                                        idFav = int.Parse(Console.ReadLine());

                                        FindEmployee(employees, userName).FavoritForEmployee(FindFavoritForEmployee(employers, idFav), idFav);
                                        FindEmployee(employees, userName).showFavorit();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    //try parse ele !

                                    break;
                                }
                            case "9":
                                {
                                    //   "1)Your CV");
                                    //   "2)Information about
                                    // "3)Add CV");
                                    //   "4)Update CV");
                                    //   "5)Delete CV");
                                    //   "6)Bid");
                                    //   "7)Refuse bid");
                                    //   "8)Add to favorit");
                                    //   "9)Show favorit list
                                    // "10)Notifications");
                                    FindEmployee(employees, userName).showFavorit();
                                    break;
                                }
                            case "10":
                                {
                                    try
                                    {
                                        Console.Clear();
                                        FindEmployee(employees, userName).showNotifi();

                                        Console.WriteLine("Wait!");
                                        Thread.Sleep(2000);

                                    }
                                    catch (Exception ex)
                                    {

                                        Console.WriteLine(ex.Message);
                                    }
                                    break;
                                }

                            case "11":
                                {

                                    try
                                    {
                                        PrintCities();
                                        Console.WriteLine("Whichone do you want to select : ");
                                        forUpdate = Console.ReadLine();
                                        foreach (var item in employers)
                                        {
                                            if (forUpdate == "1") item.SearchByCity(Cities.Baku);
                                            else if (forUpdate == "2") item.SearchByCity(Cities.Ganja);
                                            else if (forUpdate == "3") item.SearchByCity(Cities.Tovuz);
                                            else if (forUpdate == "4") item.SearchByCity(Cities.Balaken);
                                            else if (forUpdate == "5") item.SearchByCity(Cities.Aqhstafa);
                                            else if (forUpdate == "6") item.SearchByCity(Cities.Susha);
                                            else if (forUpdate == "7") item.SearchByCity(Cities.Xankendi);
                                            else if (forUpdate == "8") item.SearchByCity(Cities.Cebrayil);
                                            else
                                            {
                                                city = Cities.AllAzerbaijan;
                                                Console.WriteLine("What is it bro?");
                                            }
                                        };


                                        PrintCategories();
                                        Console.WriteLine("Whichone do you want to select : ");
                                        forUpdate = Console.ReadLine();
                                        foreach (var item in employers)
                                        {

                                            if (forUpdate == "1") item.SearchByCategory(Categories.IT);
                                            else if (forUpdate == "2") item.SearchByCategory(Categories.Marketing);
                                            else if (forUpdate == "3") item.SearchByCategory(Categories.Design);
                                            else if (forUpdate == "4") item.SearchByCategory(Categories.Programmer);
                                            else if (forUpdate == "5") item.SearchByCategory(Categories.Support);
                                            else if (forUpdate == "6") item.SearchByCategory(Categories.SalesManager);
                                            else if (forUpdate == "7") item.SearchByCategory(Categories.Manager);
                                            else if (forUpdate == "8") item.SearchByCategory(Categories.Teacher);
                                            else
                                            {
                                                category = Categories.IdontKnow;
                                            }
                                        }

                                        int max;
                                        int min;
                                        Console.WriteLine("Min salary : ");
                                        min = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Max salary : ");
                                        max = int.Parse(Console.ReadLine());


                                        foreach (var item in employers)
                                        {
                                            item.SearcyBySalary(min, max);
                                        }


                                        //Console.WriteLine("Min experience");
                                        //int minExperience;
                                        //minExperience = int.Parse(Console.ReadLine());
                                        //foreach (var item in employers)
                                        //{
                                        //    item.SearchExperience(minExperience);
                                        //}
                                        //   FindEmployer(employers, userName).SearchByCategory(category);
                                        foreach (var item in employers)
                                        {
                                            item.showFilter();
                                        }
                                        //Console.ReadLine();
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }


                                    break;





                                }
                        }
                        if (forWritingSomething == "20")
                        {
                            break;
                        }
                    }
                }
                else if (signIn(employees, employers, userName, passWord) == "Employers")
                {
                    while (true)
                    {
                        printForEmployer();
                        forWritingSomething = Console.ReadLine();
                        switch (forWritingSomething)
                        {
                            case "1":
                                {
                                    FindEmployer(employers, userName).ShowVacancies();
                                    break;
                                }
                            case "2":
                                {
                                    Console.WriteLine($"Emploters menu : {FindEmployer(employers, userName)}");
                                    break;
                                }

                            case "3":
                                {
                                    try
                                    {
                                        Console.WriteLine("Enter the category : ");
                                        string choise;
                                        PrintCities();
                                        choise = Console.ReadLine();
                                        //Console.WriteLine("\n1)Baku\n2)Ganja\n3)Tovuz\n4)Balaken\n5)Aqhstafa\n6)Susha\n7)Xankendi\n8)Cebrayil\n");
                                        if (choise == "1") city = Cities.Baku;
                                        else if (choise == "2") city = Cities.Ganja;
                                        else if (choise == "3") city = Cities.Tovuz;
                                        else if (choise == "4") city = Cities.Balaken;
                                        else if (choise == "5") city = Cities.Aqhstafa;
                                        else if (choise == "6") city = Cities.Susha;
                                        else if (choise == "7") city = Cities.Xankendi;
                                        else if (choise == "8") city = Cities.Cebrayil;
                                        else
                                        {
                                            city = Cities.AllAzerbaijan;
                                            Console.WriteLine("What is it bro?");
                                        }

                                        PrintCategories();
                                        choise = Console.ReadLine();
                                        //1)IT\n2)Marketting\n3)Design\n4)Programmer\n5)Support\n6)Sales managger\n7)Managger\n8)Teacher\n");
                                        if (choise == "1") category = Categories.IT;
                                        else if (choise == "2") category = Categories.Marketing;
                                        else if (choise == "3") category = Categories.Design;
                                        else if (choise == "4") category = Categories.Programmer;
                                        else if (choise == "5") category = Categories.Support;
                                        else if (choise == "6") category = Categories.SalesManager;
                                        else if (choise == "7") category = Categories.Manager;
                                        else if (choise == "8") category = Categories.Teacher;
                                        else
                                        {
                                            category = Categories.IdontKnow;

                                        }

                                        //string place,string category, double salary, DateTime StartTime, DateTime EndTime, string Requirement, string InformationAboutJob, string Email
                                        Console.WriteLine("Enter the salary : ");
                                        salary = double.Parse(Console.ReadLine());
                                        Console.WriteLine("");
                                        Console.WriteLine("Start time(like this : ) mm dd yy: ");
                                        date3 = Convert.ToDateTime(Console.ReadLine());
                                        Console.WriteLine("End time mm dd yy: : ");
                                        date4 = Convert.ToDateTime(Console.ReadLine());
                                        Console.WriteLine("Requirement : ");
                                        Requirement = Console.ReadLine();
                                        Console.WriteLine("Information about job : ");
                                        informationAbout = Console.ReadLine();
                                        Console.WriteLine("Email : ");
                                        Email = Console.ReadLine();
                                        FindEmployer(employers, userName).AddVacancy(city, category, salary, date3, date4, Requirement, informationAbout, Email);
                                        FileHelper.WriteToFIleEmployer("Employer.json", employers);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                break;

                            case "4":
                                {
                                    FindEmployer(employers, userName).ShowVacancies();
                                    Console.WriteLine("Which vacancy do you want to delete : ");
                                    enteringID = int.Parse(Console.ReadLine());
                                    FindEmployer(employers, userName).DeleteVacancy(enteringID);
                                    FindEmployer(employers, userName).ShowVacancies();
                                    FileHelper.WriteToFIleEmployer("Employer.json", employers);
                                    break;
                                }
                            case "5":
                                {
                                    try
                                    {


                                        showEmployerUpdatList();
                                        forUpdate = Console.ReadLine();
                                        switch (forUpdate)
                                        {
                                            // \n1)Update place\n2)Update salary\n4)Update Requirement\n5)Update info\n6)Update gmail\n7)Update experience\n8)Update start time\n9)update endtime\n");
                                            case "1":
                                                {
                                                    FindEmployer(employers, userName).ShowVacancies();
                                                    Console.WriteLine("Which ID do you want to update : ");
                                                    enteringID = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("What do you want to write : ");
                                                    PrintCities();
                                                    forUpdate = Console.ReadLine();
                                                    if (forUpdate == "1") city = Cities.Baku;
                                                    else if (forUpdate == "2") city = Cities.Ganja;
                                                    else if (forUpdate == "3") city = Cities.Tovuz;
                                                    else if (forUpdate == "4") city = Cities.Balaken;
                                                    else if (forUpdate == "5") city = Cities.Aqhstafa;
                                                    else if (forUpdate == "6") city = Cities.Susha;
                                                    else if (forUpdate == "7") city = Cities.Xankendi;
                                                    else if (forUpdate == "8") city = Cities.Cebrayil;
                                                    else
                                                    {
                                                        city = Cities.AllAzerbaijan;
                                                        Console.WriteLine("What is it bro?");
                                                    }
                                                    FindEmployer(employers, userName).UpdatePlace(enteringID, city);
                                                    FindEmployer(employers, userName).ShowVacancies();
                                                    FileHelper.WriteToFIleEmployer("Employer.json", employers);
                                                    break;
                                                }

                                            case "2":
                                                {
                                                    FindEmployer(employers, userName).ShowVacancies();
                                                    Console.WriteLine("Which ID do you want to update : ");
                                                    enteringID = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("What do you want to write : ");

                                                    experience = int.Parse(Console.ReadLine());
                                                    FindEmployer(employers, userName).UpdateSalary(enteringID, experience);
                                                    FindEmployer(employers, userName).ShowVacancies();
                                                    FileHelper.WriteToFIleEmployer("Employer.json", employers);
                                                    break;
                                                }

                                            case "3":
                                                {
                                                    FindEmployer(employers, userName).ShowVacancies();
                                                    Console.WriteLine("Which ID do you want to update : ");
                                                    enteringID = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("What do you want to write : ");
                                                    PrintCities();
                                                    forUpdate = Console.ReadLine();

                                                    FindEmployer(employers, userName).UpdateRequirement(enteringID, forUpdate);
                                                    FindEmployer(employers, userName).ShowVacancies();
                                                    FileHelper.WriteToFIleEmployer("Employer.json", employers);
                                                    break;
                                                }

                                            case "4":
                                                {
                                                    FindEmployer(employers, userName).ShowVacancies();

                                                    Console.WriteLine("Which ID do you want to update : ");
                                                    enteringID = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("What do you want to write : ");
                                                    PrintCities();
                                                    forUpdate = Console.ReadLine();

                                                    FindEmployer(employers, userName).UpdateInformationAboutJob(enteringID, forUpdate);
                                                    FileHelper.WriteToFIleEmployer("Employer.json", employers);
                                                    break;

                                                }

                                            case "5":
                                                {
                                                    Console.WriteLine("Which ID do you want to update : ");
                                                    enteringID = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("What do you want to write : ");
                                                    PrintCities();
                                                    forUpdate = Console.ReadLine();
                                                    FindEmployer(employers, userName).UpdateGmail(enteringID, forUpdate);
                                                    FindEmployer(employers, userName).ShowVacancies();
                                                    FileHelper.WriteToFIleEmployer("Employer.json", employers);
                                                    break;
                                                }

                                            case "6":
                                                {
                                                    FindEmployer(employers, userName).ShowVacancies();
                                                    Console.WriteLine("Which ID do you want to update : ");
                                                    enteringID = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("What do you want to write : ");
                                                    PrintCities();
                                                    experience = int.Parse(Console.ReadLine());
                                                    FindEmployer(employers, userName).UpdateExperience(enteringID, experience);
                                                    FindEmployer(employers, userName).ShowVacancies();
                                                    FileHelper.WriteToFIleEmployer("Employer.json", employers);
                                                    break;
                                                }
                                            case "7":
                                                {
                                                    FindEmployer(employers, userName).ShowVacancies();
                                                    Console.Clear();
                                                    Console.WriteLine("Which ID do you want to update : ");
                                                    enteringID = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("What do you want to write : ");
                                                    date1 = DateTime.Parse(Console.ReadLine());
                                                    FindEmployer(employers, userName).UpdateStartTime(enteringID, date1);
                                                    FindEmployer(employers, userName).ShowVacancies();
                                                    FileHelper.WriteToFIleEmployer("Employer.json", employers);


                                                    break;
                                                }

                                            case "8":
                                                {
                                                    FindEmployer(employers, userName).ShowVacancies();
                                                    Console.Clear();
                                                    Console.WriteLine("Which ID do you want to update : ");
                                                    enteringID = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("What do you want to write : ");
                                                    date1 = DateTime.Parse(Console.ReadLine());
                                                    FindEmployer(employers, userName).UpdateEndTime(enteringID, date1);
                                                    FindEmployer(employers, userName).ShowVacancies();
                                                    FileHelper.WriteToFIleEmployer("Employer.json", employers);
                                                    break;
                                                }


                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;
                                }

                            case "6":
                                {
                                    try
                                    {
                                        Console.Clear();
                                        FindEmployer(employers, userName).showForBid();
                                        Console.WriteLine("Enter ID : ");
                                        int enterId = int.Parse(Console.ReadLine());
                                        var emplo = FindFavoritForEmployeee(employees, enterId);
                                        FindEmployer(employers, userName).AcceptCV(FindFavoritForEmployeee(employees, enterId), enterId);
                                        Console.WriteLine("Done!");
                                        
                                        Notifications(emplo, "Acc");
                                    }

                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);

                                    }

                                    break;
                                }
                            case "7":
                                {
                                    try
                                    {
                                        Console.Clear();
                                        FindEmployer(employers, userName).showForBid();
                                        Console.WriteLine("Enter ID : ");
                                        int enterId = int.Parse(Console.ReadLine());
                                        var emplo = FindFavoritForEmployeee(employees, enterId);
                                        FindEmployer(employers, userName).RemoveCV(FindFavoritForEmployeee(employees, enterId), enterId);
                                        Console.WriteLine("Done!");
                                        Notifications(emplo, "Ref");

                                    }
                                    catch (Exception ex)
                                    {

                                        Console.WriteLine(ex.Message);
                                    }

                                    break;
                                }

                                //    FindEmployer(employers, userName)

                        }





                        if (forWritingSomething == "10")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    count++;
                    Console.WriteLine($"You have {3 - count} chance!");
                    if (count == 3)
                    {
                        break;
                    }
                }
            }
        }
    }
}
