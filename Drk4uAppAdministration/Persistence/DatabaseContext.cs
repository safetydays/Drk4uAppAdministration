namespace Drk4uAppAdministration.Persistence {

    using Drk4uAppAdministration.Models;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseContext : DbContext {

        public DbSet<News> News { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Skillset> Skillset { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {
            //nothing to do
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<UserCategory>().HasKey(t => new { t.Category, t.UserId });
            modelBuilder.Entity<Userskillset>().HasKey(t => new { t.SkillsetId, t.UserId });
        }

    }

}