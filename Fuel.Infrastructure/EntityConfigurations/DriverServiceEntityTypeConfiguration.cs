namespace Fuel.Infrastructure.EntityConfigurations
{
    using Fuel.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class DriverServiceEntityTypeConfiguration : IEntityTypeConfiguration<DcsDriverService>
    {
        public void Configure(EntityTypeBuilder<DcsDriverService> driverServiceConfiguration)
        {
            driverServiceConfiguration.ToTable("DCS_DriverService");

            driverServiceConfiguration.HasKey(e => e.DriverServiceId);

            driverServiceConfiguration.HasIndex(e => e.DriverVehicleId)
                .HasName("fkIdx_171");

            driverServiceConfiguration.Property(e => e.DriverServiceId).ValueGeneratedNever();

            driverServiceConfiguration.HasOne(d => d.DriverVehicle)
                .WithMany(p => p.DcsDriverService)
                .HasForeignKey(d => d.DriverVehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_171");
        }
    }
}
