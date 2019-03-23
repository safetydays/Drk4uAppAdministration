namespace Drk4uAppAdministration.Models {

    using System.Collections.Generic;

    public class User {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public List<Userskillset> Skillsets { get; set; }

        public List<UserCategory> Categories { get; set; }

        public User() {
            // nothing to do
        }

    }

}