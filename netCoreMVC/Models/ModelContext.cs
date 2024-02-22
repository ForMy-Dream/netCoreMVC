using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace netCoreMVC.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Log4net> Log4nets { get; set; } = null!;
        public virtual DbSet<Logtable> Logtables { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<UserInfo> UserInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User ID=JHA;Password=220717;Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST =localhost)(PORT =1521))) (CONNECT_DATA = (SERVICE_NAME = orcl)))");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JHA")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("BOOK");

                entity.Property(e => e.Id)
                    .HasPrecision(11)
                    .HasColumnName("ID");

                entity.Property(e => e.Abs)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ABS")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Author)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AUTHOR")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Cid)
                    .HasPrecision(11)
                    .HasColumnName("CID")
                    .HasDefaultValueSql("NULL\n\n");

                entity.Property(e => e.Cover)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COVER")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Indate)
                    .HasColumnType("DATE")
                    .HasColumnName("INDATE");

                entity.Property(e => e.Press)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PRESS")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.Id)
                    .HasPrecision(11)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Log4net>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LOG4NET");

                entity.Property(e => e.LogDatetime)
                    .HasColumnType("DATE")
                    .HasColumnName("LOG_DATETIME");

                entity.Property(e => e.LogLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOG_LEVEL");

                entity.Property(e => e.LogLogger)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOG_LOGGER");

                entity.Property(e => e.LogMessage)
                    .IsUnicode(false)
                    .HasColumnName("LOG_MESSAGE");

                entity.Property(e => e.LogThread)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOG_THREAD");
            });

            modelBuilder.Entity<Logtable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LOGTABLE");

                entity.Property(e => e.Datetime)
                    .HasColumnType("DATE")
                    .HasColumnName("DATETIME");

                entity.Property(e => e.LevelL)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LEVEL_L");

                entity.Property(e => e.Logger)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOGGER");

                entity.Property(e => e.Message)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Thread)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("THREAD");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("MOVIES");

                entity.Property(e => e.Id)
                    .HasPrecision(8)
                    .HasColumnName("ID");

                entity.Property(e => e.Price).HasColumnType("NUMBER(8,2)");

                entity.Property(e => e.ReleaseDate).HasColumnType("DATE");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.ToTable("USER_INFOS");

                entity.Property(e => e.Id)
                    .HasPrecision(8)
                    .HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("DATE");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.HasSequence("BOOK_ID_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
