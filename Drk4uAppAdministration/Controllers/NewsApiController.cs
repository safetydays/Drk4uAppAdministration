namespace Drk4uAppAdministration.Controllers {

    using Drk4uAppAdministration.Models;
    using Drk4uAppAdministration.Persistence;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/news")]
    public class NewsApiController : ControllerBase {

        private readonly DatabaseContext databaseContext;

        public NewsApiController(DatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<News>> Get() {
            return this.databaseContext.News.OrderByDescending(x => x.CreatedAt).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<News> Get(int id) {
            var newsItem = this.databaseContext.News.SingleOrDefault(n => n.Id == id);
            if (null == newsItem) {
                return NotFound();
            } else {
                return newsItem;
            }
        }

    }

}