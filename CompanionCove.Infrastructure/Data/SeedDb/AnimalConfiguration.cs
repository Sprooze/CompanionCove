using CompanionCove.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionCove.Infrastructure.Data.SeedDb
{
    internal class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder
               .HasOne(h => h.Type)
               .WithMany(c => c.Animals)
               .HasForeignKey(x => x.TypeId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(h => h.Agent)
               .WithMany(c => c.Animals)
               .HasForeignKey(x => x.AgentId)
               .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Animal[] { data.FirstAnimal, data.SecondAnimal, data.ThirdAnimal });
        }
    }
}
