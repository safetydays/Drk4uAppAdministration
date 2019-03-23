namespace Drk4uAppAdministration.Pages {

    using Drk4uAppAdministration.Models;
    using Drk4uAppAdministration.Persistence;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersModel : PageModel {

        private readonly DatabaseContext databaseContext;

        [BindProperty]
        public IList<User> Users { get; set; }

        public UsersModel(DatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        public async Task<IActionResult> OnGetAsync() {
            this.Users = await this.databaseContext.User.Include(u => u.Skillsets).OrderByDescending(u => u.CreatedAt).ToListAsync();
            return Page();
        }

    }

}