using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBOOS
{
    class CV
    {
        public int ID { get; set; }
        public static int StaticID { get; set; } = 0;
        public string Education { get; set; }
        public string ScoolNO { get; set; }
        public string  Companies { get; set; }

        internal void Add(string education, int experience, int universitetyScore, string skills, bool sertificate, string gitHub, string linkedin, string language)
        {
            throw new NotImplementedException();
        }

        public int Experience { get; set; }
        public int UniversitetyScore { get; set; }
        public string Skills { get; set; }
        public bool Certificate { get; set; } = false;
        public string GitHub { get; set; }
        public string Linkedin { get; set; }
        public string Language { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public CV()
        {
            ID = ++StaticID;
        }



        public override string ToString()
        {
            return $"\nId : {ID}\nScool NO : {ScoolNO}\nCompanies : {Companies}\nEducation : {Education}\nUniversity score : {UniversitetyScore}\nExperience : {Experience}\nSkills : {Skills}\nSertificate : {Certificate}\nGithub : {GitHub}\nLinkedin : {Linkedin}\nStart time : {StartTime}\nEnd time : {EndTime}";
        }


    }
}
