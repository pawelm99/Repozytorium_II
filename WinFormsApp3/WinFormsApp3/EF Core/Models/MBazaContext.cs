using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WinFormsApp3.Models
{
    public partial class MBazaContext : DbContext
    {
        public MBazaContext()
        {
        }

        public MBazaContext(DbContextOptions<MBazaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ImgwogolneDane> ImgwogolneDanes { get; set; }
        public virtual DbSet<ObszarZagrozony> ObszarZagrozonies { get; set; }
        public virtual DbSet<ObszaryZalewowe> ObszaryZalewowes { get; set; }
        public virtual DbSet<OstrzeganieInstytucji> OstrzeganieInstytucjis { get; set; }
        public virtual DbSet<PomiarRzeki> PomiarRzekis { get; set; }
        public virtual DbSet<PowiadomienieSm> PowiadomienieSms { get; set; }
        public virtual DbSet<PowodzieHistoryczne> PowodzieHistorycznes { get; set; }
        public virtual DbSet<PrognozaPogody> PrognozaPogodies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-9SL4PUT;Database=MBaza;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<ImgwogolneDane>(entity =>
            {
                entity.HasKey(e => e.ImgwstanZagrozenia)
                    .HasName("PK__IMGWOgol__D63595B166C09ABE");

                entity.ToTable("IMGWOgolneDane", "dane");

                entity.Property(e => e.ImgwstanZagrozenia)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IMGWStanZagrozenia");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ObszarZagrozony>(entity =>
            {
                entity.HasKey(e => e.Miejscowosc)
                    .HasName("PK__ObszarZa__726D9DB7951D029F");

                entity.ToTable("ObszarZagrozony", "dane");

                entity.Property(e => e.Miejscowosc)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NazwaRzeki)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SluzbaRatunkowa)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.NazwaRzekiNavigation)
                    .WithMany(p => p.ObszarZagrozonies)
                    .HasForeignKey(d => d.NazwaRzeki)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NazwaRzeki");
            });

            modelBuilder.Entity<ObszaryZalewowe>(entity =>
            {
                entity.HasKey(e => e.NazwaRzeki)
                    .HasName("PK__ObszaryZ__D7B57E02222793B7");

                entity.ToTable("ObszaryZalewowe", "dane");

                entity.Property(e => e.NazwaRzeki)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OstrzeganieInstytucji>(entity =>
            {
                entity.HasKey(e => e.MiejscowoscOrganizacji)
                    .HasName("PK__Ostrzega__EB708083F3731B5D");

                entity.ToTable("OstrzeganieInstytucji", "dane");

                entity.Property(e => e.MiejscowoscOrganizacji)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.MiastoOrganizacji)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MiejscowoscZagrozona)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SluzbaRatunkowa)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.StanZagrozenia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.MiejscowoscZagrozonaNavigation)
                    .WithMany(p => p.OstrzeganieInstytucjis)
                    .HasForeignKey(d => d.MiejscowoscZagrozona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Miejscowosc");
            });

            modelBuilder.Entity<PomiarRzeki>(entity =>
            {
                entity.HasKey(e => e.NazwaRzeki)
                    .HasName("PK__PomiarRz__D7B57E020A039002");

                entity.ToTable("PomiarRzeki", "dane");

                entity.Property(e => e.NazwaRzeki)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PowiadomienieSm>(entity =>
            {
                entity.HasKey(e => e.NumerTelefonu)
                    .HasName("PK__Powiadom__6C70F0C2239BCF5F");

                entity.ToTable("PowiadomienieSMS", "dane");

                entity.Property(e => e.NumerTelefonu)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Miejscowosc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StanZagrozenia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.MiejscowoscNavigation)
                    .WithMany(p => p.PowiadomienieSms)
                    .HasForeignKey(d => d.Miejscowosc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Miejscowosc2");
            });

            modelBuilder.Entity<PowodzieHistoryczne>(entity =>
            {
                entity.HasKey(e => e.Miejscowosc)
                    .HasName("PK__Powodzie__A551532136C135D3");

                entity.ToTable("PowodzieHistoryczne", "dane");

                entity.Property(e => e.Miejscowosc)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataPowodzi).HasColumnType("date");

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrognozaPogody>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PrognozaPogody", "dane");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RodzajPogody)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
