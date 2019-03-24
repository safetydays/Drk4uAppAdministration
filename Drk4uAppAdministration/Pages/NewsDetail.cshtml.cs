namespace Drk4uAppAdministration.Pages {

    using Drk4uAppAdministration.Models;
    using Drk4uAppAdministration.Persistence;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class NewsDetailModel : PageModel {

        private readonly DatabaseContext databaseContext;

        [BindProperty]
        public News News { get; set; }

        public NewsDetailModel(DatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        public ActionResult OnGet(int id) {
            var news = this.databaseContext.News.Include(n => n.Image).SingleOrDefault(n => n.Id == id);
            if (null == news) {
                return NotFound();
            } else {
                this.News = news;
                return Page();
            }
        }

    }

}