namespace Drk4uAppAdministration.Models {

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; private set; }

        public List<UserSkillset> Skillsets { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string MobilPhone { get; set; }

        public User() {
            this.CreatedAt = DateTime.UtcNow;
            this.Skillsets = new List<UserSkillset>();
        }

        public User(UserViewModel userViewModel)
            :this() {
            this.Name = userViewModel.Name;
            this.Password = userViewModel.Password;
            foreach (var skillset in userViewModel.Skillsets) {
                this.Skillsets.Add(new UserSkillset() { User = this, Skillset = skillset });
            }
            this.MobilPhone = userViewModel.MobilPhone;
        }

    }

}