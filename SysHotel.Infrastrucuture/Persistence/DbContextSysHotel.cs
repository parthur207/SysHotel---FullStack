using Microsoft.EntityFrameworkCore;
using SysHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Infrastrucuture.Persistence
{
    public class DbContextSysHotel : DbContext
    {
        public DbContextSysHotel(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserEntity> User { get; set; }

        public DbSet<BookingEntity> Booking { get; set; }

        public DbSet<HotelUnitEntity> HotelUnit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
