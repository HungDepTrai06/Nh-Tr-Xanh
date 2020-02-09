namespace WebBanHang.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBWebThue : DbContext
    {
        public DBWebThue()
            : base("name=DBWebThue")
        {
        }

        public virtual DbSet<DSANH> DSANH { get; set; }
        public virtual DbSet<HUYENQUAN> HUYENQUAN { get; set; }
        public virtual DbSet<LOAITT> LOAITT { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNG { get; set; }
        public virtual DbSet<TINTUC> TINTUC { get; set; }
        public virtual DbSet<TINHTP> TINHTP { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HUYENQUAN>()
                .Property(e => e.MAHUYEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HUYENQUAN>()
                .Property(e => e.MATINH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HUYENQUAN>()
                .HasMany(e => e.TINTUC)
                .WithRequired(e => e.HUYENQUAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAITT>()
                .HasMany(e => e.TINTUC)
                .WithRequired(e => e.LOAITT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.EMAIL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.SDT1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.SDT2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .HasMany(e => e.TINTUC)
                .WithRequired(e => e.NGUOIDUNG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TINTUC>()
                .Property(e => e.MAHUYEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TINTUC>()
                .HasMany(e => e.DSANH)
                .WithRequired(e => e.TINTUC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TINHTP>()
                .Property(e => e.MATINH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TINHTP>()
                .HasMany(e => e.HUYENQUAN)
                .WithRequired(e => e.TINHTP)
                .WillCascadeOnDelete(false);
        }
    }
}
