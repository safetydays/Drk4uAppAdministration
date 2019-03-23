namespace Drk4uAppAdministration {

    using System;
    using System.ComponentModel.DataAnnotations;

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