namespace Drk4uAppAdministration.Models {

    using Microsoft.AspNetCore.Http;
    using System;
    using System.IO;

    public class News {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public byte[] ImageFile { get; set; }

        public Category Category { get; set; }

        public DateTime CreatedAt { get; private set; }

        public News() : base() {
            this.CreatedAt = DateTime.UtcNow;
        }

        public News(string title, string content) : this(title, content, null) {
            // nothing to do
        }

        public News(string title, string content, IFormFile imageFile) : this() {
            this.Title = title;
            this.Content = content;
            if (null != imageFile) {
                this.ImageFile = this.GetAsByteArray(imageFile);
            }
        }

        private byte[] GetAsByteArray(IFormFile file) {
            using (var memoryStream = new MemoryStream()) {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

    }

}