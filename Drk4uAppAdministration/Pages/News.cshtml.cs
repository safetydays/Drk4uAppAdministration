namespace Drk4uAppAdministration.Pages {

    using Drk4uAppAdministration.Models;
    using Drk4uAppAdministration.Persistence;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class NewsModel : PageModel {

        private readonly DatabaseContext databaseContext;

        [BindProperty]
        public IList<News> News { get; set; }

        public NewsModel(DatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        public async Task<IActionResult> OnGetAsync() {
            this.News = await this.databaseContext.News.Include(n => n.Image).OrderByDescending(d => d.CreatedAt).ToListAsync();
            return Page();
        }

    }

}