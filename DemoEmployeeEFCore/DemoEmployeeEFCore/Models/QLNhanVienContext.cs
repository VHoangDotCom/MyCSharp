using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DemoEmployeeEFCore.Models
{
    public partial class QLNhanVienContext : DbContext
    {
        public QLNhanVienContext()
        {
        }

        public QLNhanVienContext(DbContextOptions<QLNhanVienContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-ULU1CBF;Initial Catalog=QLNhanVien;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NhanVien__2725D70A91D1E97B");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(50)
                    .HasColumnName("MaNV");

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.MaPhong)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaPhong)
                    .HasConstraintName("fk_NV_PB");
            });

            modelBuilder.Entity<PhongBan>(entity =>
            {
                entity.HasKey(e => e.MaPhong)
                    .HasName("PK__PhongBan__20BD5E5B37D86492");

                entity.ToTable("PhongBan");

                entity.Property(e => e.MaPhong).HasMaxLength(50);

                entity.Property(e => e.TenPhong).HasMaxLength(60);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
