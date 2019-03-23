namespace Drk4uAppAdministration.Pages {

    using Drk4uAppAdministration.Models;
    using Drk4uAppAdministration.Persistence;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EmergenciesModel : PageModel {

        private readonly DatabaseContext databaseContext;

        [BindProperty]
        public IList<Emergency> Emergencies { get; set; }

        public EmergenciesModel(DatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        public async Task<IActionResult> OnGetAsync() {
            this.Emergencies = await this.databaseContext.Emergencies.OrderByDescending(d => d.CreatedAt).ToListAsync();
            return Page();
        }

    }

}