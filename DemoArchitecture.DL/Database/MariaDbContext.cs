using System;
using DemoArchitecture.Entity;
using DemoArchitecture.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoArchitecture.DL.Database
{
    public partial class MariaDbContext : DbContext
    {
        //public MariaDbContext()
        //{
        //}

        public MariaDbContext(DbContextOptions<MariaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Position> Position { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasComment("Bảng danh mục Nhân viên");

                entity.HasIndex(e => e.EmployeeCode)
                    .HasName("UK_Employee_Employeecode")
                    .IsUnique();

                entity.HasIndex(e => e.FullName);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(36)
                    .IsFixedLength();

                entity.Property(e => e.CitizenIdentityCode)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("Số chứng minh thư");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("Ngày tạo bản ghi");

                entity.Property(e => e.DateOfBieth)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("Ngày sinh");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("Email");

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("Họ");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("Họ và tên");

                entity.Property(e => e.Gender)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("Giới tính (0-Nữ, 1- Nam, 2- Khác)");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("Tên");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ModifiedDate)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("Ngày thực hiện chỉnh sửa gần nhất");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("Số điện thoại");

                entity.Property(e => e.PositionId)
                    .HasColumnName("PositionID")
                    .HasMaxLength(36)
                    .IsFixedLength()
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.WorkState)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("Tình trạng công việc (0- ĐÃ nghỉ việc, 1- Đang làm việc, 2- Đã nghỉ hưu)");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasComment("Vị trí");

                entity.Property(e => e.PositionId)
                    .HasColumnName("PositionID")
                    .HasMaxLength(36)
                    .IsFixedLength();

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("Tên vị trí");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
