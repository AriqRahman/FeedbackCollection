using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FeedbackCollectionAPI.Models
{
    public partial class Feedback_Collection_DBContext : DbContext
    {
        public Feedback_Collection_DBContext()
        {
        }

        public Feedback_Collection_DBContext(DbContextOptions<Feedback_Collection_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PostDetail> PostDetails { get; set; }
        public virtual DbSet<PostLikeOrDislike> PostLikeOrDislikes { get; set; }
        public virtual DbSet<PostMaster> PostMasters { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=FeedbackCollectionConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModefiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PostLikeOrDislike>(entity =>
            {
                entity.ToTable("PostLikeOrDislike");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModefiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PostMaster>(entity =>
            {
                entity.ToTable("PostMaster");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModefiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModefiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
