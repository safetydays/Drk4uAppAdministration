namespace Drk4uAppAdministration.Pages {

    using Drk4uAppAdministration.Models;
    using Drk4uAppAdministration.Persistence;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Twilio;
    using Twilio.Rest.Api.V2010.Account;

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
        public string City { get; set; }

        [BindProperty]
        public List<Skillset> Skillsets { get; set; }

        [BindProperty]
        public bool IsSendSms { get; set; }

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
                try {
                    var emergency = new Emergency(this.Title, this.Description, this.AmountPeople, this.Skillsets, this.City);
                    if (this.IsSendSms) {
                        await this.SendSms(emergency.Description, emergency.Skillsets);
                    }
                    this.databaseContext.Emergencies.Add(emergency);
                    await this.databaseContext.SaveChangesAsync();
                } catch (Exception ex) {
                    this.ModelState.AddModelError(nameof(IsSendSms), ex.Message);
                    return Page();
                }
            }
            return RedirectToPage("./Emergencies");
        }

        private async Task SendSms(string description, List<EmergencySkillset> requiredEmergencySkillsets) {
            const string accountSid = "AC9ba6ce62aae30c0f359addc9cf9f0a33";
            const string authToken = "5ed4a45f8bc456c09c23b5978973cea0";
            var skillsets = new List<Skillset>();
            foreach (var requiredEmergencySkillset in requiredEmergencySkillsets) {
                skillsets.Add(requiredEmergencySkillset.Skillset);
            }
            var users = this.databaseContext.UserSkillsets
                .Where(s => skillsets.Contains(s.Skillset))
                .Select(s => s.User)
                .ToList();
            foreach (var user in users) {
                TwilioClient.Init(accountSid, authToken);
                var message = await MessageResource.CreateAsync(
                    body: description,
                    from: new Twilio.Types.PhoneNumber("4915114321743"),
                    to: new Twilio.Types.PhoneNumber(user.MobilPhone)
                );
            }
            return;
        }

    }

}