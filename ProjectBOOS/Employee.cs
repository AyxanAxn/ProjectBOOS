using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBOOS
{
    class Employee : Human
    {

        public List<CV> cv = new List<CV>();
        public List<CV> ForBid = new List<CV>();
        public void AddCV(string profession, string school, int score, string skills, string companies, DateTime startTime, DateTime endTime, string languages, bool certificate, string github, string linkedin)
        {
            CV cv1 = new CV
            {
                Education = profession,
                ScoolNO = school,
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
        public void UpdateCVForEducation(int ID, string Education)
        {
            var itemToUpdate = cv.Single(n => n.ID == ID);
            itemToUpdate.Education = Education;
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
      public  void Bid(int ID) {
            var itemToRemove = cv.Single(r => r.ID == ID);
            ForBid.Add(itemToRemove);
        }
        void RemoveBid(int ID) {
            var itemToRemove = ForBid.Single(r => r.ID == ID);
            ForBid.Remove(itemToRemove);

        }

        public void showBidList() {
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
