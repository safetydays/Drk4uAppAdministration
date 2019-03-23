namespace Drk4uAppAdministration.Models {

    public class EmergencySkillset {

        public int EmergencyId { get; set; }
        public Emergency Emergency { get; set; }

        public Skillset Skillset { get; set; }

        public EmergencySkillset() {
            // nothing to do
        }

    }

}