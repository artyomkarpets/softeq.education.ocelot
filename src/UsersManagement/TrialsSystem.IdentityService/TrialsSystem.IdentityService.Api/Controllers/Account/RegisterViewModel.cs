using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrialsSystem.IdentityService.Api.Controllers
{
    public class RegisterViewModel : RegisterInputViewModel
    {
        public List<Consent> Consents { get; set; }
        public List<SelectListItem> Cities { get; set; }
        public List<SelectListItem> Genders { get; set; }
    }

    public class Consent
    {
        public bool Requared { get; set; }
        public string ConsentUrl { get; set; }
    }

    public class IdNameViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
