using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IFriendWebservice.Models
{
    public partial class FriendDatabaseContext : DbContext
    {
        public FriendDatabaseContext()
        {
        }

        public FriendDatabaseContext(DbContextOptions<FriendDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Friends> Friends { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=frienddb.database.windows.net;Database=FriendDatabase;User ID=avengers;Password=Mads12345;Trusted_Connection=false;Encrypt=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friends>(entity =>
            {
                entity.ToTable("FRIENDS");

                entity.Property(e => e.FriendsId).HasColumnName("friendsID");

                entity.Property(e => e.Dress).HasColumnName("dress");

                entity.Property(e => e.FriendsName)
                    .IsRequired()
                    .HasColumnName("friendsName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fun).HasColumnName("fun");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Hunger).HasColumnName("hunger");

                entity.Property(e => e.OwnerId).HasColumnName("ownerID");

                entity.Property(e => e.Task).HasColumnName("task");

                entity.Property(e => e.Thirst).HasColumnName("thirst");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Friends)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_FRIENDS_USERS");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.ToTable("TASKS");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.FriendId).HasColumnName("FriendID");

                entity.Property(e => e.TaskDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TaskName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.FriendId)
                    .HasConstraintName("FK_TASKS_FRIENDS");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("USERS");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("userPassword")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
