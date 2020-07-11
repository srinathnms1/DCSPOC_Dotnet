namespace Fuel.Infrastructure.EntityConfigurations
{
    using Fuel.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class FuelInfoEntityTypeConfiguration : IEntityTypeConfiguration<DcsFuelInfo>
    {
        public void Configure(EntityTypeBuilder<DcsFuelInfo> fuelInfoConfiguration)
        {
            fuelInfoConfiguration.ToTable("DCS_FuelInfo");

            fuelInfoConfiguration.HasKey(e => e.FuelInfoId);

            fuelInfoConfiguration.HasIndex(e => e.DriverVehicleId)
                .HasName("fkIdx_192");

            fuelInfoConfiguration.Property(e => e.FuelInfoId).ValueGeneratedNever();

            fuelInfoConfiguration.HasOne(d => d.DriverVehicle)
                .WithMany(p => p.DcsFuelInfo)
                .HasForeignKey(d => d.DriverVehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_192");
        }
    }
}
