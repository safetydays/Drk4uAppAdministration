namespace Drk4uAppAdministration.Models {

    using System;
    using System.Collections.Generic;

    public class User {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; private set; }

        public List<Userskillset> Skillsets { get; set; }

        public List<UserCategory> Categories { get; set; }

        public User() {
            this.CreatedAt = DateTime.UtcNow;
        }

    }

}