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
        public int Experience { get; set; }
        public int UniversitetyScore { get; set; }
        public string Skills { get; set; }
        public string Profecion { get; set; }
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
            return $"\nId : {ID}\nScool NO : {ScoolNO}\nCompanies : {Companies}\nLanguage - {Language}\nEducation : {Education}\nUniversity score : {UniversitetyScore}\nProfession - {Profecion}\nExperience : {Experience}\nSkills : {Skills}\nSertificate : {Certificate}\nGithub : {GitHub}\nLinkedin : {Linkedin}\nStart time : {StartTime.ToShortDateString()}\nEnd time : {EndTime.ToShortDateString()}";
        }


    }
}
