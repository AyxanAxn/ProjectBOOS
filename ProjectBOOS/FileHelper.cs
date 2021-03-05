using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBOOS
{
    static class FileHelper
    {
        public static void WriteToFIleEmployee(string NameOfFile, List<Employee> employees)
        {
            var write = new JsonSerializer();
            using (var sw = new StreamWriter(NameOfFile))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    write.Serialize(jw, employees);
                }
            }
        }
        public static void WriteToFIleEmployer(string NameOfFile, List<Employer> employers)
        {
            var write = new JsonSerializer();
            using (var sw = new StreamWriter(NameOfFile))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    write.Serialize(jw, employers);
                }
            }
        }

        public static void WriteToFIleVacancies(string NameOfFile, List<Vacancy> vacancies)
        {
            var write = new JsonSerializer();
            using (var sw = new StreamWriter(NameOfFile))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    write.Serialize(jw, vacancies);
                }
            }
        }
        public static void WriteToFIleCV(string NameOfFile, List<CV> cVs)
        {
            var write = new JsonSerializer();
            using (var sw = new StreamWriter(NameOfFile))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    write.Serialize(jw, cVs);
                }
            }
        }
        public static List<Employee> ReadFromEmployee(string NameOfFile)
        {
            List<Employee> employees = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(NameOfFile))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    employees = serializer.Deserialize<List<Employee>>(jr);
                }
            }
            return employees;

        }
        public static List<Employer> ReadFromEmployer(string NameOfFile)
        {
            List<Employer> employers = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(NameOfFile))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    employers = serializer.Deserialize<List<Employer>>(jr);
                }

            }
            return employers;
        }

        public static void ReadFromVacancy(string NameOfFile)
        {
            List<Vacancy> vacancies = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(NameOfFile))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    vacancies = serializer.Deserialize<List<Vacancy>>(jr);
                }

            }
            foreach (var item in vacancies)
            {
                Console.WriteLine(item);
            }
        }

        public static void ReadFromCV(string NameOfFile)
        {
            List<CV> cVs = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(NameOfFile))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    cVs = serializer.Deserialize<List<CV>>(jr);
                }

            }
            foreach (var item in cVs)
            {
                Console.WriteLine(item);
            }
        }




    }
}
