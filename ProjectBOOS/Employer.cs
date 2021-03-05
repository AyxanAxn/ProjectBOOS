using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBOOS
{
    class Employer : Human
    {

        public List<Vacancy> vacancies = new List<Vacancy>();
        List<CV> employees = new List<CV>();
        List<Vacancy> Search = new List<Vacancy>();
        List<CV> FavoritCvs = new List<CV>();
        public List<CV> ForBidCV = new List<CV>();
        public List<CV> AcceptedCV = new List<CV>();



        public void AddVacancy(string place, string category, double salary, DateTime StartTime, DateTime EndTime, string Requirement, string InformationAboutJob, string Email)
        {
            Vacancy vacancy = new Vacancy()
            {
                Place = place,
                Salary = salary,
                StartTime = StartTime,
                EndTime = EndTime,
                Requirement = Requirement,
                InformationAboutJob = InformationAboutJob,
                Email = Email,
                Category = category

            };
            vacancies.Add(vacancy);
        }
        public void DeleteVacancy(int ID)
        {
            var itemToRemove = vacancies.Single(r => r.ID == ID);
            vacancies.Remove(itemToRemove);
        }
        public void FavoritForEmployer(Employee employee, int id)
        {

            foreach (var item in employee.cv)
            {
                if (item.ID == id)
                {
                    FavoritCvs.Add(item);
                }
            }

        }


        #region UpdateFunk

        public void UpdatePlace(int ID, string place)
        {
            var itemToUpdate = vacancies.Single(p => p.ID == ID);
            itemToUpdate.Place = place;
        }
        public void UpdateSalary(int ID, int salary)
        {
            var itemToUpdate = vacancies.Single(p => p.ID == ID);
            itemToUpdate.Salary = salary;
        }
        public void UpdateRequirement(int ID, string Requirement)
        {
            var itemToUpdate = vacancies.Single(p => p.ID == ID);
            itemToUpdate.Requirement = Requirement;
        }
        public void UpdateExperience(int ID, int Requirement)
        {
            var itemToUpdate = vacancies.Single(p => p.ID == ID);
            itemToUpdate.Experience = Requirement;
        }
        public void UpdateInformationAboutJob(int ID, string InformationAboutJob)
        {
            var itemToUpdate = vacancies.Single(p => p.ID == ID);
            itemToUpdate.InformationAboutJob = InformationAboutJob;
        }
        public void UpdateGmail(int ID, string InformationAboutJob)
        {
            var itemToUpdate = vacancies.Single(p => p.ID == ID);
            itemToUpdate.Email = InformationAboutJob;
        }
        public void UpdateStartTime(int ID, DateTime StartTime)
        {
            var itemToUpdate = vacancies.Single(p => p.ID == ID);
            itemToUpdate.StartTime = StartTime;
        }
        public void UpdateEndTime(int ID, DateTime EndTime)
        {
            var itemToUpdate = vacancies.Single(p => p.ID == ID);
            itemToUpdate.EndTime = EndTime;
        }

        #endregion UpdateFunk
        #region Filtering
        public void SearchByCity(string City)
        {
            if (City != Cities.AllAzerbaijan)
            {


                foreach (var item in vacancies)
                {
                    if (item.Place == City)
                    {
                        Search.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in vacancies)
                {
                    Search.Add(item);
                }
            }
        }


        public void SearchByCategory(string Category)
        {
            if (Category != Categories.IdontKnow)
            {

                foreach (var item in vacancies)
                {
                    if (item.Category != Category)
                    {
                        Search.Remove(item);
                    }
                }
            }
           
        }

        public void SearcyBySalary(int min, int max)
        {
            foreach (var item in vacancies)
            {
                if (min < item.Salary || max > item.Salary)
                {
                    Search.Remove(item);
                }
            }
        }
        public void SearchExperience(int Experience)
        {
            foreach (var item in vacancies)
            {
                if (item.Experience != Experience)
                {
                    Search.Remove(item);
                }
            }
        }
        public void showFilter()
        {
            foreach (var item in Search)
            {
                Console.WriteLine(item);
            }
        }

        #endregion






        public void AcceptCV(Employee employee, int ID)
        {

            var itemToRemove = ForBidCV.Single(r => r.ID == ID);
            AcceptedCV.Add(itemToRemove);
        }
        public void RemoveCV(Employee employee, int ID)
        {

            var itemToRemove = ForBidCV.Single(r => r.ID == ID);
            ForBidCV.Remove(itemToRemove);

        }

        public void ShowVacancies()
        {
            foreach (var item in vacancies)
            {
                Console.WriteLine(item);
            }
        }
        public void ShowAcceptList()
        {
            foreach (var item in employees)
            {
                Console.WriteLine(item);
            }
        }
        public void showForBid()
        {
            foreach (var item in ForBidCV)
            {
                Console.WriteLine(item);
            }


        }
    }
}
