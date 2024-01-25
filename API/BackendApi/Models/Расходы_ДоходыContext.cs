using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackendApi.Models
{
    public partial class Расходы_ДоходыContext : DbContext
    {
        public Расходы_ДоходыContext()
        {
        }

        public Расходы_ДоходыContext(DbContextOptions<Расходы_ДоходыContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Budget> Budgets { get; set; } = null!;
        public virtual DbSet<CategoryType> CategoryTypes { get; set; } = null!;
        public virtual DbSet<Limit> Limits { get; set; } = null!;
        public virtual DbSet<Operation> Operations { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAB116-3\\TEST;Database=Расходы_Доходы;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Budget>(entity =>
            {
                entity.ToTable("Budget");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("End_date");

                entity.Property(e => e.Size).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StartsDate)
                    .HasColumnType("date")
                    .HasColumnName("Starts_date");

                entity.Property(e => e.UsersId).HasColumnName("Users_id");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Budgets)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Budget_Users");
            });

            modelBuilder.Entity<CategoryType>(entity =>
            {
                entity.ToTable("Category_Types");

                entity.Property(e => e.Names)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Limit>(entity =>
            {
                entity.ToTable("Limit");

                entity.Property(e => e.CategoriesId).HasColumnName("Categories_id");

                entity.Property(e => e.DateOpened)
                    .HasColumnType("date")
                    .HasColumnName("Date_opened");

                entity.Property(e => e.Names)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartingBalance)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Starting_balance");

                entity.Property(e => e.Type).HasColumnName("Type_");

                entity.Property(e => e.UsersId).HasColumnName("Users_id");

                entity.HasOne(d => d.Categories)
                    .WithMany(p => p.Limits)
                    .HasForeignKey(d => d.CategoriesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Limit_Category_Types");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Limits)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Limit_Users");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.Property(e => e.CategoriesId).HasColumnName("Categories_id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_time");

                entity.Property(e => e.Sums).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("Type_");

                entity.Property(e => e.UsersId).HasColumnName("Users_id");

                entity.HasOne(d => d.Categories)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.CategoriesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operations_Category_Types");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operations_Users");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.CategoriesId).HasColumnName("Categories_id");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_time");

                entity.Property(e => e.UsersId).HasColumnName("Users_id");

                entity.HasOne(d => d.Categories)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CategoriesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_Category_Types");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Passwords).HasMaxLength(50);

                entity.Property(e => e.UsersName)
                    .HasMaxLength(50)
                    .HasColumnName("Users_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
