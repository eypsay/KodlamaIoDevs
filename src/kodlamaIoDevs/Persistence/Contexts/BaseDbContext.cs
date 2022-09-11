using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<SubTechnology> SubTechnologies { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");

                a.HasMany(p => p.SubTechnologies);
            });

            modelBuilder.Entity<SubTechnology>(a =>
            {
                a.ToTable("SubTechnologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProgramingLanguageId).HasColumnName("ProgramingLanguageId)");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Version).HasColumnName("Version");

                a.HasOne(p => p.ProgrammingLanguage);
            });



            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "JAVA"), new(2, "JavaScript"), new(3, "C#") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            SubTechnology[] subTechnologyEntitySeeds =
            {
                new(1,1, "SpringBoot","1.0"),
                new(2,1, "Hibernate","2.0"),
                new(3,2, "React","1.0"),
                new(4,2, "NodeJs","2.0"),
                new(5,3, "WPF","1.0"),
                new(6,3, "ASP.NET","2.0"),

            };
            modelBuilder.Entity<SubTechnology>().HasData(subTechnologyEntitySeeds);


        }
    }
}
