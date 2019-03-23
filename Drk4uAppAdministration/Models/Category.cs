namespace Drk4uAppAdministration.Models {

    using System;
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

    public static class Extensions {

        public static string DisplayName(this Enum @enum) {
            var displayName = string.Empty;
            var fields = @enum.GetType().GetFields();
            foreach (var field in fields) {
                var displayNameAttribute = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;
                if (displayNameAttribute != null && field.Name.Equals(@enum.ToString(), StringComparison.InvariantCultureIgnoreCase)) {
                    displayName = displayNameAttribute.Name;
                    break;
                }
            }
            return displayName;
        }

    }

}