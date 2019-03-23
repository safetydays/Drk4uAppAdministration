namespace Drk4uAppAdministration.Pages {

    using Drk4uAppAdministration.Models;
    using Drk4uAppAdministration.Persistence;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    public class CreateEmergencyModel : PageModel {

        private readonly DatabaseContext databaseContext;

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        [Range(1, 100, ErrorMessage = "Amount of people must be between 1 and 100.")]
        public int AmountPeople { get; set; }

        [BindProperty]
        public Skillset Skillset { get; set; }

        public CreateEmergencyModel(DatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        public void OnGet() {
            // nothing to do
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            } else {
                var emergency = new Emergency(this.Title, this.Description, this.AmountPeople, this.Skillset);
                this.databaseContext.Emergencies.Add(emergency);
                await this.databaseContext.SaveChangesAsync();
                return RedirectToPage("./Emergencies");
            }
        }

    }

}