namespace Fuel.Infrastructure.EntityConfigurations
{
    using Fuel.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class DriverVehicleEntityTypeConfiguration : IEntityTypeConfiguration<DcsDriverVehicle>
    {
        public void Configure(EntityTypeBuilder<DcsDriverVehicle> driverVehicleConfiguration)
        {
            driverVehicleConfiguration.ToTable("DCS_DriverVehicle");

            driverVehicleConfiguration.HasKey(e => e.DriverVehicleId);

            driverVehicleConfiguration.HasIndex(e => e.DriverId)
                .HasName("fkIdx_159");

            driverVehicleConfiguration.HasIndex(e => e.VehicleId)
                .HasName("fkIdx_156");

            driverVehicleConfiguration.Property(e => e.DriverVehicleId).ValueGeneratedNever();

            driverVehicleConfiguration.HasOne(d => d.Driver)
                .WithMany(p => p.DcsDriverVehicle)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_159");

            driverVehicleConfiguration.HasOne(d => d.Vehicle)
                .WithMany(p => p.DcsDriverVehicle)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_156");
        }
    }
}
