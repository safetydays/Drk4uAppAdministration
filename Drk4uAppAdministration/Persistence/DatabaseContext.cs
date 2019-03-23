namespace Drk4uAppAdministration.Persistence {

    using Drk4uAppAdministration.Models;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseContext : DbContext {

        public DbSet<News> News { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Emergency> Emergencies { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<UserSkillset> UserSkillsets { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {
            //nothing to do
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<UserSkillset>().HasKey(t => new { t.Skillset, t.UserId });
            modelBuilder.Entity<EmergencySkillset>().HasKey(t => new { t.Skillset, t.EmergencyId });
        }

    }

}