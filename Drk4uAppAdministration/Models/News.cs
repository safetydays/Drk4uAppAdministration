namespace Drk4uAppAdministration.Models {

    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;

    public class News {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Image Image { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Category Category { get; set; }

        public DateTime CreatedAt { get; private set; }

        public News() 
            : base() {
            this.CreatedAt = DateTime.UtcNow;
        }

        public News(string title, string content, Category category)
            : this(title, content, category, null) {
            // nothing to do
        }

        public News(string title, string content, Category category, IFormFile imageFile) 
            : this() {
            this.Title = title;
            this.Content = content;
            this.Category = category;
            if (null != imageFile) {
                this.Image = new Image(imageFile);
            }
        }

    }

}