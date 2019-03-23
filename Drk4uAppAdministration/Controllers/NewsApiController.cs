namespace Drk4uAppAdministration.Controllers {

    using Drk4uAppAdministration.Models;
    using Drk4uAppAdministration.Persistence;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/news")]
    public class NewsApiController : ControllerBase {

        private readonly DatabaseContext databaseContext;

        public NewsApiController(DatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<NewsViewModel>> Get() {
            var news = this.databaseContext.News.Include(n => n.Image).OrderByDescending(x => x.CreatedAt).ToList();
            var newsViewModel = new List<NewsViewModel>();
            foreach (var newsItem in news) {
                newsViewModel.Add(new NewsViewModel(newsItem));
            }
            return newsViewModel;
        }

        [HttpGet("{id}")]
        public ActionResult<NewsViewModel> Get(int id) {
            var newsItem = this.databaseContext.News.Include(n => n.Image).SingleOrDefault(n => n.Id == id);
            if (null == newsItem) {
                return NotFound();
            } else {
                return new NewsViewModel(newsItem);
            }
        }

    }

}