namespace Drk4uAppAdministration.Models {

    public class UserSkillset {

        public int UserId { get; set; }
        public User User { get; set; }

        public Skillset Skillset { get; set; }

        public UserSkillset() {
            // nothing to do
        }

    }
}
