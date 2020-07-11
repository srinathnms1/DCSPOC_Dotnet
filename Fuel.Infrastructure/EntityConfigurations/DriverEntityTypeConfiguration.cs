namespace Fuel.Infrastructure.EntityConfigurations
{
    using Fuel.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class DriverEntityTypeConfiguration : IEntityTypeConfiguration<DcsDriverMaster>
    {
        public void Configure(EntityTypeBuilder<DcsDriverMaster> driverConfiguration)
        {
            driverConfiguration.ToTable("DCS_DriverMaster");

            driverConfiguration.HasKey(b => b.DriverId);

            driverConfiguration.Property(e => e.DriverId)
                    .HasIdentityOptions(null, null, null, 100000L, null, null)
                    .UseIdentityAlwaysColumn();

            driverConfiguration.Property(e => e.DriverMobile).HasMaxLength(50);

            driverConfiguration.Property(e => e.DriverName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
