namespace Drk4uAppAdministration.Models {

    using System.Collections.Generic;

    public class UserViewModel {

        public string Name { get; set; }

        public string Password { get; set; }

        public List<Skillset> Skillsets { get; set; }

        public List<Category> Categories { get; set; }

        public UserViewModel() {
            // nothing to do
        }

    }

}