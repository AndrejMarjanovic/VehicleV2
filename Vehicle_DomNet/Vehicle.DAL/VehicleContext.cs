using Microsoft.EntityFrameworkCore;
using Vehicle.DAL.Entities;

namespace Vehicle.DAL
{
    public partial class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options) { }

        public VehicleContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VehicleModel>()
                 .HasOne(pt => pt.VehicleMake).WithMany().HasForeignKey(pt => pt.VehicleMakeId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VehicleEntity>()
                 .HasOne(pt => pt.VehicleModel).WithMany().HasForeignKey(pt => pt.VehicleModelId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VehicleEntity>()
                 .HasOne(pt => pt.Seats).WithMany().HasForeignKey(pt => pt.SeatsId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VehicleEntity>()
                 .HasOne(pt => pt.VehicleType).WithMany().HasForeignKey(pt => pt.VehicleTypeId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VehicleEntity>()
                 .HasOne(pt => pt.Engine).WithMany().HasForeignKey(pt => pt.EngineId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VehicleEntity>()
                 .HasOne(pt => pt.Colour).WithMany().HasForeignKey(pt => pt.ColourId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Seats>()
                .HasOne(pt => pt.SeatTypeColour).WithMany().HasForeignKey(pt => pt.SeatTypeColourId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Engine>()
                .HasOne(pt=> pt.FuelType).WithMany().HasForeignKey(pt => pt.FuelTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VehicleEntity>()
               .HasOne(pt => pt.Transmission).WithMany().HasForeignKey(pt => pt.TransmissionId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SeatTypeColour>()
               .HasOne(pt => pt.Colour).WithMany().HasForeignKey(pt => pt.ColourId)
               .OnDelete(DeleteBehavior.Restrict); 
            
            modelBuilder.Entity<SeatTypeColour>()
               .HasOne(pt => pt.SeatType).WithMany().HasForeignKey(pt => pt.SeatTypeId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MaintainanceHistory>()
                .HasOne(pt => pt.Vehicle).WithMany().HasForeignKey(pt => pt.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VehicleMake>()
                .HasOne(pt => pt.Country).WithMany().HasForeignKey(pt =>pt.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarShop>()
                .HasOne(pt => pt.Country).WithMany().HasForeignKey(pt => pt.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contract>()
               .HasOne(pt => pt.CarShopVehicle).WithMany().HasForeignKey(pt => pt.CarShopVehicleId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contract>()
               .HasOne(pt => pt.Customer).WithMany().HasForeignKey(pt => pt.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarShopVehicle>()
               .HasOne(pt => pt.CarShop).WithMany().HasForeignKey(pt => pt.CarShopId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarShopVehicle>()
              .HasOne(pt => pt.Vehicle).WithMany().HasForeignKey(pt => pt.VehicleId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
              .HasOne(pt => pt.Role).WithMany().HasForeignKey(pt => pt.RoleId)
              .OnDelete(DeleteBehavior.Restrict);

            SeedRoles(modelBuilder);
        }

        public DbSet<VehicleMake> VehicleMake { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }
        public DbSet<VehicleEntity> Vehicle { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<Seats> Seats { get; set;}
        public DbSet<Colour> Colour { get; set; }
        public DbSet<Transmission> Transmission { get; set; }
        public DbSet<FuelType> FuelType { get; set;}
        public DbSet<Engine> Engine { get; set; }
        public DbSet<SeatType> SeatType { get; set; }
        public DbSet<SeatTypeColour> SeatTypeColour { get; set;}
        public DbSet<MaintainanceHistory> MaintainanceHistory { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<CarShop> CarShop { get; set; }
        public DbSet<CarShopVehicle> CarShopVehicle { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin"},
                new Role { Id = 2, Name = "User"}
                );
        }

    }
}
