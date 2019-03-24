namespace Drk4uAppAdministration.Pages {

    using Drk4uAppAdministration.Models;
    using Drk4uAppAdministration.Persistence;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class CreateNewsModel : PageModel {

        private readonly DatabaseContext databaseContext;
        private readonly int MAX_BYTES = 5 * 1024 * 1024; //5MB
        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".jpg", ".jpeg", ".png", ".tif", ".bmp" };

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Content { get; set; }

        [BindProperty]
        public Category Category { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public CreateNewsModel(DatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        public void OnGet() {
            // nothing to do
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!this.IsValidImage(this.ImageFile)) {
                return Page();
            } else {
                var news = new News(this.Title, this.Content, this.Category, this.ImageFile);
                this.databaseContext.News.Add(news);
                await this.databaseContext.SaveChangesAsync();
                return RedirectToPage("./News");
            }
        }

        private bool IsValidImage(IFormFile image) {
            var isValid = false;
            if (!this.ACCEPTED_FILE_TYPES.Any(s => s == Path.GetExtension(image.FileName))) {
                this.ModelState.AddModelError(nameof(ImageFile), "Image in wrong format (can only be JPG, PNG, BMP oder GIF).");
            } else if (image.Length > this.MAX_BYTES) {
                this.ModelState.AddModelError(nameof(ImageFile), $"Image size too big (max size {this.MAX_BYTES / 1024 / 1024}MB).");
            } else {
                isValid = true;
            }
            return isValid;
        }

    }

}