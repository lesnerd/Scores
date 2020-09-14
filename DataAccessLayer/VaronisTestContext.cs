using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer
{
    public partial class VaronisTestContext : DbContext
    {
        private readonly IConfiguration Configuration;
        private string _dbConnectionString;

        public VaronisTestContext()
        {
        }

        public VaronisTestContext(DbContextOptions<VaronisTestContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
            _dbConnectionString = Configuration["ApplicationSetting:DBConnectionString"];
            if (string.IsNullOrEmpty(_dbConnectionString))
                throw new ArgumentException("Please make sure your params are exist.");
        }

        public virtual DbSet<SourceLocations> SourceLocations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(_dbConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SourceLocations>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.LocationOnDisk)
                    .HasMaxLength(23)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
