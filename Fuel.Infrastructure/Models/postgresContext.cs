using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fuel.Infrastructure.Models
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<A> A { get; set; }
        public virtual DbSet<B> B { get; set; }
        public virtual DbSet<DcsDriverMaster> DcsDriverMaster { get; set; }
        public virtual DbSet<DcsDriverService> DcsDriverService { get; set; }
        public virtual DbSet<DcsDriverVehicle> DcsDriverVehicle { get; set; }
        public virtual DbSet<DcsFuelInfo> DcsFuelInfo { get; set; }
        public virtual DbSet<DcsLocation> DcsLocation { get; set; }
        public virtual DbSet<DcsLogs> DcsLogs { get; set; }
        public virtual DbSet<DcsLogs1> DcsLogs1 { get; set; }
        public virtual DbSet<DcsVehicleMaster> DcsVehicleMaster { get; set; }
        public virtual DbSet<DcsVehicleRealTimeInfo> DcsVehicleRealTimeInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=dcspoc.c2fl44ylxyy9.us-east-1.rds.amazonaws.com;Database=postgres;Username=postgres;Password=Poc123$*");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<A>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("a");

                entity.Property(e => e.RegexpReplace).HasColumnName("regexp_replace");
            });

            modelBuilder.Entity<B>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("b");

                entity.Property(e => e.RegexpReplace).HasColumnName("regexp_replace");
            });

            modelBuilder.Entity<DcsDriverMaster>(entity =>
            {
                entity.HasKey(e => e.DriverId);

                entity.ToTable("DCS_DriverMaster");

                entity.Property(e => e.DriverId)
                    .HasIdentityOptions(null, null, null, 100000L, null, null)
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.DriverMobile).HasMaxLength(50);

                entity.Property(e => e.DriverName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DcsDriverService>(entity =>
            {
                entity.HasKey(e => e.DriverServiceId);

                entity.ToTable("DCS_DriverService");

                entity.HasIndex(e => e.DriverVehicleId)
                    .HasName("fkIdx_171");

                entity.Property(e => e.DriverServiceId).ValueGeneratedNever();

                entity.HasOne(d => d.DriverVehicle)
                    .WithMany(p => p.DcsDriverService)
                    .HasForeignKey(d => d.DriverVehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_171");
            });

            modelBuilder.Entity<DcsDriverVehicle>(entity =>
            {
                entity.HasKey(e => e.DriverVehicleId);

                entity.ToTable("DCS_DriverVehicle");

                entity.HasIndex(e => e.DriverId)
                    .HasName("fkIdx_159");

                entity.HasIndex(e => e.VehicleId)
                    .HasName("fkIdx_156");

                entity.Property(e => e.DriverVehicleId).ValueGeneratedNever();

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.DcsDriverVehicle)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_159");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.DcsDriverVehicle)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_156");
            });

            modelBuilder.Entity<DcsFuelInfo>(entity =>
            {
                entity.HasKey(e => e.FuelInfoId);

                entity.ToTable("DCS_FuelInfo");

                entity.HasIndex(e => e.DriverVehicleId)
                    .HasName("fkIdx_192");

                entity.Property(e => e.FuelInfoId).ValueGeneratedNever();

                entity.HasOne(d => d.DriverVehicle)
                    .WithMany(p => p.DcsFuelInfo)
                    .HasForeignKey(d => d.DriverVehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_192");
            });

            modelBuilder.Entity<DcsLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("DCS_Location");

                entity.Property(e => e.LocationId).ValueGeneratedNever();

                entity.HasOne(d => d.VehicleRealTimeInfo)
                    .WithMany(p => p.DcsLocation)
                    .HasForeignKey(d => d.VehicleRealTimeInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_191");
            });

            modelBuilder.Entity<DcsLogs>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dcs_logs");

                entity.Property(e => e.Exception).HasColumnName("exception");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.LogEvent)
                    .HasColumnName("log_event")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.MessageTemplate).HasColumnName("message_template");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");
            });

            modelBuilder.Entity<DcsLogs1>(entity =>
            {
                entity.ToTable("DCS_Logs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Application)
                    .HasColumnName("application")
                    .HasMaxLength(100);

                entity.Property(e => e.Callsite)
                    .HasColumnName("callsite")
                    .HasMaxLength(8000);

                entity.Property(e => e.Exception)
                    .HasColumnName("exception")
                    .HasMaxLength(8000);

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasMaxLength(100);

                entity.Property(e => e.Logged).HasColumnName("logged");

                entity.Property(e => e.Logger)
                    .HasColumnName("logger")
                    .HasMaxLength(8000);

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasMaxLength(8000);
            });

            modelBuilder.Entity<DcsVehicleMaster>(entity =>
            {
                entity.HasKey(e => e.VehicleId);

                entity.ToTable("DCS_VehicleMaster");

                entity.Property(e => e.VehicleId).ValueGeneratedNever();

                entity.Property(e => e.VehicleLicenseNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleName).HasMaxLength(50);
            });

            modelBuilder.Entity<DcsVehicleRealTimeInfo>(entity =>
            {
                entity.HasKey(e => e.VehicleRealTimeInfoId);

                entity.ToTable("DCS_VehicleRealTimeInfo");

                entity.HasIndex(e => e.DriverVehicleId)
                    .HasName("fkIdx_184");

                entity.Property(e => e.VehicleRealTimeInfoId).ValueGeneratedNever();

                entity.Property(e => e.IgnitionStatus).HasColumnType("bit(1)");

                entity.HasOne(d => d.DriverVehicle)
                    .WithMany(p => p.DcsVehicleRealTimeInfo)
                    .HasForeignKey(d => d.DriverVehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_184");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
