using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TpixAPI.Models.Database;

namespace TpixAPI.Data
{
    public partial class TpixContext : DbContext
    {
        public TpixContext()
        {
        }

        public TpixContext(DbContextOptions<TpixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<VotePost> VotePost { get; set; }
        public virtual DbSet<VoteTopic> VoteTopic { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Tpix;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FkCreatedBy).HasColumnName("FK_CreatedBy");

                entity.Property(e => e.ImgUrl).HasMaxLength(300);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.FkCreatedByNavigation)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.FkCreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Category__FK_Cre__06CD04F7");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Member__A9D105347DA6888F")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Member__536C85E439ECE2C6")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.EditedAt).HasColumnType("datetime");

                entity.Property(e => e.FkCreatedBy).HasColumnName("FK_CreatedBy");

                entity.Property(e => e.FkParentTopicId).HasColumnName("FK_ParentTopicId");

                entity.Property(e => e.MainBody)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.HasOne(d => d.FkCreatedByNavigation)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.FkCreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post__FK_Created__0E6E26BF");

                entity.HasOne(d => d.FkParentTopic)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.FkParentTopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post__FK_ParentT__0D7A0286");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => new { e.FkTopicId, e.FkMemberReportedId, e.FkPostId, e.FkReportingMemberId });

                entity.Property(e => e.FkTopicId).HasColumnName("FK_TopicId");

                entity.Property(e => e.FkMemberReportedId).HasColumnName("FK_MemberReportedId");

                entity.Property(e => e.FkPostId).HasColumnName("FK_PostId");

                entity.Property(e => e.FkReportingMemberId).HasColumnName("FK_ReportingMemberId");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Reason).HasMaxLength(500);

                entity.HasOne(d => d.FkMemberReported)
                    .WithMany(p => p.ReportFkMemberReported)
                    .HasForeignKey(d => d.FkMemberReportedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Report__FK_Membe__160F4887");

                entity.HasOne(d => d.FkPost)
                    .WithMany(p => p.Report)
                    .HasForeignKey(d => d.FkPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Report__FK_PostI__18EBB532");

                entity.HasOne(d => d.FkReportingMember)
                    .WithMany(p => p.ReportFkReportingMember)
                    .HasForeignKey(d => d.FkReportingMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Report__FK_Repor__17036CC0");

                entity.HasOne(d => d.FkTopic)
                    .WithMany(p => p.Report)
                    .HasForeignKey(d => d.FkTopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Report__FK_Topic__17F790F9");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.EditedAt).HasColumnType("datetime");

                entity.Property(e => e.FkCategoryId).HasColumnName("FK_CategoryId");

                entity.Property(e => e.FkCreatedBy).HasColumnName("FK_CreatedBy");

                entity.Property(e => e.MainBody)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.FkCategory)
                    .WithMany(p => p.Topic)
                    .HasForeignKey(d => d.FkCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Topic__FK_Catego__09A971A2");

                entity.HasOne(d => d.FkCreatedByNavigation)
                    .WithMany(p => p.Topic)
                    .HasForeignKey(d => d.FkCreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Topic__FK_Create__0A9D95DB");
            });

            modelBuilder.Entity<VotePost>(entity =>
            {
                entity.HasKey(e => new { e.FkPostId, e.FkMemberId });

                entity.Property(e => e.FkPostId).HasColumnName("FK_PostId");

                entity.Property(e => e.FkMemberId).HasColumnName("FK_MemberId");
            });

            modelBuilder.Entity<VoteTopic>(entity =>
            {
                entity.HasKey(e => new { e.FkTopicId, e.FkMemberId });

                entity.Property(e => e.FkTopicId).HasColumnName("FK_TopicId");

                entity.Property(e => e.FkMemberId).HasColumnName("FK_MemberId");
            });
        }
    }
}
