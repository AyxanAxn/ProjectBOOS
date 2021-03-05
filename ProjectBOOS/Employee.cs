using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectBOOS
{
    class Employee : Human
    {
        public List<string> Notifi = new List<string>();
        public List<CV> cv = new List<CV>();
        public List<Vacancy> ForBid = new List<Vacancy>();
        public List<Vacancy> FavoritVacancies = new List<Vacancy>();
        public void AddCV(string profession, string education, string school, int experience, int score, string skills, string companies, DateTime startTime, DateTime endTime, string languages, bool certificate, string github, string linkedin)
        {
            CV cv1 = new CV
            {
                Profecion = profession,
                ScoolNO = school,
                Education = education,
                Experience = experience,
                UniversitetyScore = score,
                Skills = skills,
                Companies = companies,
                StartTime = startTime,
                EndTime = endTime,
                Language = languages,
                Certificate = certificate,
                GitHub = github,
                Linkedin = linkedin
            };
            cv.Add(cv1);
        }

        public void DeleteCV(int ID)
        {
            var itemToRemove = cv.SingleOrDefault(r => r.ID == ID);
            cv.Remove(itemToRemove);
        }
        #region UpdateMetods
        public void UpdateCVForEducation(int ID, string education)
        {
            var itemToUpdate = cv.Single(n => n.ID == ID);
            itemToUpdate.Education = education;
        }
        public void UpdateCVForProf(int ID, string prof)
        {
            var itemToUpdate = cv.Single(n => n.ID == ID);
            itemToUpdate.Profecion = prof;
        }
        public void UpdateCVForScoolNO(int ID, string ScoolNo)
        {
            var itemToUpdate = cv.Single(n => n.ID == ID);
            itemToUpdate.ScoolNO = ScoolNo;
        }

        public void UpdateCVForCompanies(int ID, string Companies)
        {
            var itemToUpdate = cv.Single(n => n.ID == ID);
            itemToUpdate.Companies = Companies;
        }
        public void UpdateCVForExperience(int ID, int Experience)
        {
            var itemToUpdate = cv.Single(n => n.ID == ID);
            itemToUpdate.Experience = Experience;
        }
        public void UpdateCVForSkills(int ID, string Skills)
        {
            var itemToUpdate = cv.Single(n => n.ID == ID);
            itemToUpdate.Skills = Skills;
        }
        public void UpdateCVForCertificate(int ID, bool Certificate)
        {
            var itemToUpdate = cv.Single(n => n.ID == ID);
            itemToUpdate.Certificate = Certificate;
        }
        public void UpdateCVForGitHub(int ID, string GitHub)
        {
            var itemToUpdate = cv.Single(n => n.ID == ID);
            itemToUpdate.GitHub = GitHub;
        }
        public void UpdateCVForLinkedin(int ID, string Linkedin)
        {
            var itemToUpdate = cv.Single(n => n.ID == ID);
            itemToUpdate.Linkedin = Linkedin;
        }
        public void UpdateCVForLanguage(int ID, string Language)
        {
            var itemToUpdate = cv.Single(n => n.ID == ID);
            itemToUpdate.Language = Language;
        }
        public void UpdateCVForStartTime(int ID, DateTime StartTime)
        {
            var itemToUpdate = cv.Single(n => n.ID == ID);
            itemToUpdate.StartTime = StartTime;
        }
        public void UpdateCVForEndTime(int ID, DateTime EndTime)
        {
            var itemToUpdate = cv.Single(n => n.ID == ID);
            itemToUpdate.EndTime = EndTime;
        }


        #endregion
        public void Bid(Employer emp, int ID, int vacancyID)
        {
            var itemToRemove = cv.Single(r => r.ID == ID);
            if (itemToRemove != null)
            {
                foreach (var item in emp.vacancies)
                {
                    if (vacancyID == item.ID)
                    {
                        ForBid.Add(item);
                    }
                }
                emp.ForBidCV.Add(itemToRemove);
            }
        }
        public void showNotifi() {
            foreach (var item in Notifi)
            {
                Console.WriteLine(item);
            }
        
        }
        void RemoveBid(int ID)
        {
            var itemToRemove = ForBid.Single(r => r.ID == ID);
            if (itemToRemove != null)
                ForBid.Remove(itemToRemove);
            else throw new Exception();
        }
        public void FavoritForEmployee(Employer employer, int id)
        {
            int cou = 0;
            foreach (var item in employer.vacancies)
            {
                if (item.ID == id)
                {
                    cou++;
                    FavoritVacancies.Add(item);
                }

            }
            if (cou == 0)
            {
                throw new Exception();
            }
        }
        public void RomoveFromFavorit(int id)
        {
            var itemToRemove = FavoritVacancies.SingleOrDefault(r => r.ID == id);
            FavoritVacancies.Remove(itemToRemove);
        }
        public void showFavorit()
        {
            foreach (var item in FavoritVacancies)
            {
                Console.WriteLine(item);
            }


        }
        public void showBidList()
        {
            foreach (var item in ForBid)
            {
                Console.WriteLine(item);
            }
        }
        public void ShowCV()
        {
            foreach (var item in cv)
            {
                Console.WriteLine(item);
            }

        }



    }
}
