namespace Fuel.Infrastructure.EntityConfigurations
{
    using Fuel.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class LogsEntityTypeConfiguration : IEntityTypeConfiguration<DcsLogs>
    {
        public void Configure(EntityTypeBuilder<DcsLogs> logsConfiguration)
        {
            logsConfiguration.HasNoKey();

            logsConfiguration.ToTable("dcs_logs");

            logsConfiguration.Property(e => e.Exception).HasColumnName("exception");

            logsConfiguration.Property(e => e.Level).HasColumnName("level");

            logsConfiguration.Property(e => e.LogEvent)
                .HasColumnName("log_event")
                .HasColumnType("jsonb");

            logsConfiguration.Property(e => e.Message).HasColumnName("message");

            logsConfiguration.Property(e => e.MessageTemplate).HasColumnName("message_template");

            logsConfiguration.Property(e => e.Timestamp).HasColumnName("timestamp");
        }
    }
}
