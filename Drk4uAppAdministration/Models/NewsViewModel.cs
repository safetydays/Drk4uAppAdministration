namespace Drk4uAppAdministration.Models {

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;

    public class NewsViewModel {

        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Content { get; private set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Category Category { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public string ImageUrl { get; private set; }

        public NewsViewModel(News newsItem) {
            this.Id = newsItem.Id;
            this.Title = newsItem.Title;
            this.Content = newsItem.Content;
            this.Category = newsItem.Category;
            this.CreatedAt = newsItem.CreatedAt;
            if (null != newsItem.Image) {
                this.ImageUrl = newsItem.Image.ImageUrl;
            }
        }

    }

}