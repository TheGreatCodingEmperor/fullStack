using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace fullStack
{
    public partial class test01Context : DbContext
    {
        public test01Context()
        {
            
        }

        public test01Context(DbContextOptions<test01Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ApiClaims> ApiClaims { get; set; }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseMySql("server=192.168.99.100;port=3306;user id=root;password=it404410098;database=test05", x => x.ServerVersion("10.3.22-mariadb"));
//             }
//         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiClaims>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ApiResourceId).HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
