namespace Drk4uAppAdministration.Models {

    using System.ComponentModel.DataAnnotations;

    public enum Category {

        [Display(Name = "News")]
        News = 1,

        [Display(Name = "Jobnews")]
        Jobnews = 2,

        [Display(Name = "Warning")]
        Warning = 3,

        [Display(Name = "Event")]
        Event = 4,

        [Display(Name = "Seminar")]
        Seminar = 5

    }

}