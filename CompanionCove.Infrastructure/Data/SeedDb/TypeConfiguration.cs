using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionCove.Infrastructure.Data.SeedDb
{
    internal class TypeConfiguration : IEntityTypeConfiguration<Models.Type>
    {
        public void Configure(EntityTypeBuilder<Models.Type> builder)
        {
            var data = new SeedData();

            builder.HasData(new Models.Type[] {data.CatType,data.DogType,data.BirdType,data.ExoticType});
        }
    }
}
