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
        public IEnumerable<News> Get() {
            var news = this.databaseContext.News.OrderByDescending(x => x.CreatedAt).ToList();
            return news;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

    }

}