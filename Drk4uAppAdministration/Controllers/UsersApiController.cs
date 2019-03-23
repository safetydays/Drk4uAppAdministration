namespace Drk4uAppAdministration.Controllers {

    using Drk4uAppAdministration.Models;
    using Drk4uAppAdministration.Persistence;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    [Route("api/users")]
    public class UsersApiController : Controller {

        private readonly DatabaseContext databaseContext;

        public UsersApiController(DatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id) {
            var user = this.databaseContext.User.Include(u => u.Skillsets).SingleOrDefault(u => u.Id == id);
            if (null == user) {
                return NotFound();
            } else {
                return user;
            }            
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody]UserViewModel userViewModel) {
            var user = new User(userViewModel);
            this.databaseContext.User.Add(user);
            this.databaseContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

    }

}