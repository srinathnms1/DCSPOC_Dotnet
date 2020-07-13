namespace Fuel.Infrastructure
{
    using Fuel.Domain;
    using Fuel.Infrastructure.EntityConfigurations;
    using Microsoft.EntityFrameworkCore;

    public class PostgresContext : DbContext
    {
        public PostgresContext() { }
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }
        public DbSet<DcsDriverMaster> DcsDriverMaster { get; set; }
        public DbSet<DcsDriverService> DcsDriverService { get; set; }
        public DbSet<DcsDriverVehicle> DcsDriverVehicle { get; set; }
        public DbSet<DcsFuelInfo> DcsFuelInfo { get; set; }
        public DbSet<DcsVehicleMaster> DcsVehicleMaster { get; set; }
        public DbSet<DcsVehicleRealTimeInfo> DcsVehicleRealTimeInfo { get; set; }
        public DbSet<DcsLocation> DcsLocation { get; set; }
        public DbSet<DcsLogs> DcsLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=fmspoc.ctsszeh5unue.ap-southeast-1.rds.amazonaws.com;Database=postgres;Username=postgres;Password=Poc123$*");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DriverEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DriverServiceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DriverVehicleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FuelInfoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleRealTimeInfoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LocationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LogsEntityTypeConfiguration());
        }
    }
}
