namespace Drk4uAppAdministration.Models {

    public class Userskillset {

        public int UserId { get; set; }
        public User User { get; set; }

        public int SkillsetId { get; set; }
        public Skillset Skillset { get; set; }

        public int Level { get; set; }

        public string CertificateNumber { get; set; }

        public Userskillset() {
            // nothing tod o
        }

    }

}