namespace Drk4uAppAdministration.Models {

    using System;
    using System.Collections.Generic;

    public class Emergency {

        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string City { get; private set; }

        public int AmountPeople { get; private set; }

        public List<EmergencySkillset> Skillsets { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Emergency() {
            this.CreatedAt = DateTime.UtcNow;
            this.Skillsets = new List<EmergencySkillset>();
        }

        public Emergency(string title, string description, int amountPeople, List<Skillset> skillsets, string city)
            :this () {
            this.Title = title;
            this.Description = description;
            this.AmountPeople = amountPeople;
            foreach (var skillset in skillsets) {
                this.Skillsets.Add(new EmergencySkillset() { Emergency = this, Skillset = skillset });
            }
            this.City = city;
        }

    }

}