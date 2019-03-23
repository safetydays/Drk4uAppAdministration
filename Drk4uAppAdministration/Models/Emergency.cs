namespace Drk4uAppAdministration.Models {

    using System;

    public class Emergency {

        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public int AmountPeople { get; private set; }

        public Skillset Skillset { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Emergency() {
            this.CreatedAt = DateTime.UtcNow;
        }

        public Emergency(string title, string description, int amountPeople, Skillset skillset)
            :this () {
            this.Title = title;
            this.Description = description;
            this.AmountPeople = amountPeople;
            this.Skillset = skillset;
        }

    }

}