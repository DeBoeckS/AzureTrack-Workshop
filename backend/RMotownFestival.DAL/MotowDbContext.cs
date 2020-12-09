using Microsoft.EntityFrameworkCore;
using RMotownFestival.DAL.Entities;
using System;

namespace RMotownFestival.DAL
{
    public class MotowDbContext : DbContext
    {
        public MotowDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var description = "A music festival is a festival oriented towards music that is sometimes presented with a theme such as musical genre, nationality or locality of musicians, or holiday. They are commonly held outdoors, and are often inclusive of other attractions such as food and merchandise vending machines, performance art, and social activities. Large music festivals such as Lollapalooza are constructed around well known main stage acts and lesser known musicians and bands on side stages. Many festivals are annual, or repeat at some other interval, and have modular staging of many types. Each year Lollapalooza often features multiple acts on its main and side stages.";
            modelBuilder.Entity<Artist>().HasData(new Artist { Id = 1, Name = "Diana Ross", ImagePath = "dianaross.jpg", Website = new Uri("http://www.dianaross.co.uk/indexb.html") },
                      new Artist { Id = 2, Name = "The Commodores", ImagePath = "thecommodores.jpg", Website = new Uri("http://en.wikipedia.org/wiki/Commodores") },
                      new Artist { Id = 3, Name = "Stevie Wonder", ImagePath = "steviewonder.jpg", Website = new Uri("http://www.steviewonder.net/") },
                      new Artist { Id = 4, Name = "Lionel Richie", ImagePath = "lionelrichie.jpg", Website = new Uri("http://lionelrichie.com/") },
                      new Artist { Id = 5, Name = "Marvin Gaye", ImagePath = "marvingaye.jpg", Website = new Uri("http://www.marvingayepage.net/") });

            modelBuilder.Entity<Stage>().HasData(new Stage { Id = 1, Name = "Main Stage", Description = description },
                         new Stage { Id = 2, Name = "Orange Room", Description = description },
                         new Stage { Id = 3, Name = "StarDust", Description = description },
                         new Stage { Id = 4, Name = "Marvin Gaye", Description = description });
        }


        public DbSet<Artist> Artists { get; set; }

        public DbSet<Stage> Stages { get; set; }
    }
}
