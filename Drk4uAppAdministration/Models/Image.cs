namespace Drk4uAppAdministration.Models {

    using Microsoft.AspNetCore.Http;
    using System.IO;
    using System.Text.RegularExpressions;

    public class Image {

        public int Id { get; set; }

        public string ContentType { get; private set; }

        public string Extension { get; private set; }

        public byte[] File { get; set; }

        public string Name { get; set; }

        public string ImageUrl {
            get {
                return "/api/images/" + this.GetSlugifiedFileName();
            }
        }

        public Image() {
            // nothing to do
        }

        public Image(IFormFile imageFile) : this() {
            this.ContentType = imageFile.ContentType;
            this.Extension = Path.GetExtension(imageFile.FileName);
            this.Name = Path.GetFileNameWithoutExtension(imageFile.FileName);
            this.File = this.GetAsByteArray(imageFile);
        }

        private byte[] GetAsByteArray(IFormFile file) {
            using (var memoryStream = new MemoryStream()) {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public string GetSlugifiedFileName() {
            var url = (this.Name + this.Extension).ToLower();
            url = Regex.Replace(url, "ö", "oe");
            url = Regex.Replace(url, "ä", "ae");
            url = Regex.Replace(url, "ü", "ue");
            url = Regex.Replace(url, "ß", "ss");
            url = Regex.Replace(url, @"[^a-z0-9\s-.]", "");
            url = Regex.Replace(url, @"\s+", " ").Trim();
            url = Regex.Replace(url, @"\s", "-");
            return url;
        }

    }

}