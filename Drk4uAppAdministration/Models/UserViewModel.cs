namespace Drk4uAppAdministration.Models {

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UserViewModel {

        public string Name { get; set; }

        public string Password { get; set; }

        public List<Skillset> Skillsets { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string MobilPhone { get; set; }

        public UserViewModel() {
            // nothing to do
        }

    }

}