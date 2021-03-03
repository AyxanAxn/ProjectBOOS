using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBOOS
{
    class Employer : Human
    {
        List<Vacancy> vacancies = new List<Vacancy>();
       
    //    public Employee employee { get; set; }
        List<CV> employees = new List<CV>();
        public void AddVacancy(string place, double salary, DateTime StartTime, DateTime EndTime, string Requirement, string InformationAboutJob, string Email)
        {
            Vacancy vacancy = new Vacancy()
            {
                Place = place,
                Salary = salary,
                StartTime = StartTime,
                EndTime = EndTime,
                Requirement = Requirement,
                InformationAboutJob = InformationAboutJob,
                Email = Email

            };
            vacancies.Add(vacancy);
        }
        void DeleteVacancy(int ID)
        {
            var itemToRemove = vacancies.Single(r => r.ID == ID);
            vacancies.Remove(itemToRemove);
        }
        #region UpdateFunk

        void UpdatePlace(int ID, string place)
        {
            var itemToUpdate = vacancies.Single(p => p.ID == ID);
            itemToUpdate.Place = place;
        }
        void UpdateSalary(int ID, int salary)
        {
            var itemToUpdate = vacancies.Single(p => p.ID == ID);
            itemToUpdate.Salary = salary;
        }
        void UpdateRequirement(int ID, string Requirement)
        {
            var itemToUpdate = vacancies.Single(p => p.ID == ID);
            itemToUpdate.Requirement = Requirement;
        }
        void UpdateInformationAboutJob(int ID, string InformationAboutJob)
        {
            var itemToUpdate = vacancies.Single(p => p.ID == ID);
            itemToUpdate.InformationAboutJob = InformationAboutJob;
        }
        void UpdateStartTime(int ID, DateTime StartTime)
        {
            var itemToUpdate = vacancies.Single(p => p.ID == ID);
            itemToUpdate.StartTime = StartTime;
        }
        void UpdateEndTime(int ID, DateTime EndTime)
        {
            var itemToUpdate = vacancies.Single(p => p.ID == ID);
            itemToUpdate.EndTime = EndTime;
        }

        #endregion

        public void AcceptCV(Employee employee,int ID)
        {
            var itemToRemove = employee.ForBid.Single(r => r.ID == ID);
            employees.Add(itemToRemove);
        }
        void RemoveCV(Employee employee, int ID) {
            var itemToRemove = employee.ForBid.Single(r => r.ID == ID);
            employees.Remove(itemToRemove);

        }
        public void ShowVacancies()
        {
            foreach (var item in vacancies)
            {
                Console.WriteLine(item);
            }
        }
        public void ShowAcceptList() {
            foreach (var item in employees)
            {
                Console.WriteLine(item);
            }
        }
    }
}
