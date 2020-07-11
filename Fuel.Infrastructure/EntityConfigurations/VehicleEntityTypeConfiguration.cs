namespace Fuel.Infrastructure.EntityConfigurations
{
    using Fuel.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class VehicleEntityTypeConfiguration : IEntityTypeConfiguration<DcsVehicleMaster>
    {
        public void Configure(EntityTypeBuilder<DcsVehicleMaster> vehicleConfiguration)
        {
            vehicleConfiguration.ToTable("DCS_VehicleMaster");

            vehicleConfiguration.HasKey(e => e.VehicleId);

            vehicleConfiguration.Property(e => e.VehicleId).ValueGeneratedNever();

            vehicleConfiguration.Property(e => e.VehicleLicenseNo)
                .IsRequired()
                .HasMaxLength(50);

            vehicleConfiguration.Property(e => e.VehicleName).HasMaxLength(50);
        }
    }
}
