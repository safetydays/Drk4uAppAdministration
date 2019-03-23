namespace Drk4uAppAdministration.Models {

    public class UserCategory {

        public int UserId { get; set; }
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool IsPushActive { get; set; }

        public UserCategory() {
            // nothing to do
        }

    }

}