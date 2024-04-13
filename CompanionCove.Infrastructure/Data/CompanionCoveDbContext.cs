using CompanionCove.Infrastructure.Data.Models;
using CompanionCove.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompanionCove.Infrastructure.Data
{
    public class CompanionCoveDbContext : IdentityDbContext
    {
        public CompanionCoveDbContext(DbContextOptions<CompanionCoveDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AgentConfiguration());
            builder.ApplyConfiguration(new TypeConfiguration());
            builder.ApplyConfiguration(new AnimalConfiguration());
            base.OnModelCreating(builder);  
        }

        public DbSet<Agent> Agents { get; set; } = null!;
        public DbSet<Models.Type> Types { get; set; } = null!;
        public DbSet<Animal> Animals { get; set; } = null!;
    }
}
