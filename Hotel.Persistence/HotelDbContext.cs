using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hotel.Application.Interfaces;
using Hotel.Domain;
using Hotel.Persistence.EntityTypeConfigurations;

namespace Hotel.Persistence
{
    public class HotelDbContext : DbContext, IHotelDbContext
    {
        public DbSet<Human> Humans { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public HotelDbContext(DbContextOptions<HotelDbContext> options)
            : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new HumanConfiguration());
            builder.ApplyConfiguration(new RoomConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
