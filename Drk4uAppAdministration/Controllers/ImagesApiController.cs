namespace Drk4uAppAdministration.Controllers {

    using Drk4uAppAdministration.Persistence;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    [Route("api/images")]
    public class ImagesApiController : ControllerBase {

        private readonly DatabaseContext databaseContext;

        public ImagesApiController(DatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        [HttpGet("{slugifiedFileName}")]
        public ActionResult Get(string slugifiedFileName) {
            var image = this.databaseContext.Images.SingleOrDefault(i => i.GetSlugifiedFileName() == slugifiedFileName);
            if (null == image) {
                return NotFound();
            } else {
                return File(image.File, image.ContentType);
            }
        }

    }

}