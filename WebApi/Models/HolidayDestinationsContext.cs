//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace WebApi.Models
//{
//    public partial class HolidayDestinationsContext : DbContext
//    {
//        public HolidayDestinationsContext()
//        {
//        }

//        public HolidayDestinationsContext(DbContextOptions<HolidayDestinationsContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Destination> Destinations { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseSqlServer("Server=LAPTOP-G0AD0PCA\\MSSQLSERVER01;Database=HolidayDestinations;Trusted_Connection=True;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Destination>(entity =>
//            {
//                entity.HasKey(e => e.DestinationId)
//                    .HasName("PK_Destination Table");

//                entity.Property(e => e.DestinationId)
//                    .HasColumnName("DestinationID")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.City)
//                    .IsRequired()
//                    .HasMaxLength(50);

//                entity.Property(e => e.Country)
//                    .IsRequired()
//                    .HasMaxLength(50);
//            });
//        }
//    }
//}
