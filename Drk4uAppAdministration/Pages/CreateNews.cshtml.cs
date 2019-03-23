namespace Drk4uAppAdministration.Pages {

    using Drk4uAppAdministration.Models;
    using Drk4uAppAdministration.Persistence;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Threading.Tasks;

    public class CreateNewsModel : PageModel {

        private readonly DatabaseContext databaseContext;

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
            var news = new News(this.Title, this.Content, this.Category, this.ImageFile);
            this.databaseContext.News.Add(news);
            await this.databaseContext.SaveChangesAsync();
            return RedirectToPage("./News");
        }

    }

}