namespace Fuel.Infrastructure.EntityConfigurations
{
    using Fuel.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class VehicleRealTimeInfoEntityTypeConfiguration : IEntityTypeConfiguration<DcsVehicleRealTimeInfo>
    {
        public void Configure(EntityTypeBuilder<DcsVehicleRealTimeInfo> vehicleRealTimeInfoConfiguration)
        {
            vehicleRealTimeInfoConfiguration.HasKey(e => e.VehicleRealTimeInfoId);

            vehicleRealTimeInfoConfiguration.ToTable("DCS_VehicleRealTimeInfo");

            vehicleRealTimeInfoConfiguration.HasIndex(e => e.DriverVehicleId)
                .HasName("fkIdx_184");

            vehicleRealTimeInfoConfiguration.Property(e => e.VehicleRealTimeInfoId).ValueGeneratedNever();

            vehicleRealTimeInfoConfiguration.Property(e => e.IgnitionStatus).HasColumnType("bit(1)");

            vehicleRealTimeInfoConfiguration.HasOne(d => d.DriverVehicle)
                .WithMany(p => p.DcsVehicleRealTimeInfo)
                .HasForeignKey(d => d.DriverVehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_184");
        }
    }
}
