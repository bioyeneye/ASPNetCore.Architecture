using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ArchitectureLearning.CQRS.Persistence.Entities;

namespace ArchitectureLearning.CQRS.Persistence.DbContext
{
    public partial class ArchitectureCqrsContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ArchitectureCqrsContext()
        {
        }

        public ArchitectureCqrsContext(DbContextOptions<ArchitectureCqrsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>(entity =>
            {
                entity.HasKey(x => x.Id)
                    .HasName("todos_pk")
                    .IsClustered(false);

                entity.ToTable("todos");

                entity.Property(e => e.Task)
                    .IsRequired()
                    .HasColumnName("task")
                    .HasViewColumnName("task")
                    .HasMaxLength(1);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
