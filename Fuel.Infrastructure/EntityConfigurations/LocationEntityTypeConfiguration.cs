namespace Fuel.Infrastructure.EntityConfigurations
{
    using Fuel.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class LocationEntityTypeConfiguration : IEntityTypeConfiguration<DcsLocation>
    {
        public void Configure(EntityTypeBuilder<DcsLocation> locationConfiguration)
        {
            locationConfiguration.HasKey(e => e.LocationId);

            locationConfiguration.ToTable("DCS_Location");

            locationConfiguration.Property(e => e.LocationId).ValueGeneratedNever();

            locationConfiguration.HasOne(d => d.VehicleRealTimeInfo)
                .WithMany(p => p.DcsLocation)
                .HasForeignKey(d => d.VehicleRealTimeInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_191");
        }
    }
}
