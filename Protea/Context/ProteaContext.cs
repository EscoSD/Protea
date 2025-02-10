using Microsoft.EntityFrameworkCore;
using Protea.Models;
using Protea.Models.Configuration;

namespace Protea.Context;

public class ProteaContext : DbContext
{
    
    public ProteaContext() { }

    public ProteaContext(DbContextOptions<ProteaContext> options, ConfigurationApp configurationApp)
        : base(options) { }

    public virtual DbSet<Guild> Guilds { get; init; }

    public virtual DbSet<GuildUserVcTimeRecord> GuildUsers { get; init; }

    public virtual DbSet<UserTimeSpentVc> UserTimeSpentVcs { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Guild>(entity =>
        {
            entity.ToTable("Guild");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasColumnType("TEXT(50)");
        });

        modelBuilder.Entity<GuildUserVcTimeRecord>(entity =>
        {
            entity.HasKey(e => new { e.GuildId, e.UserId });

            entity.ToTable("GuildUserVcTimeRecord");

            entity.HasOne(d => d.Guild).WithMany(p => p.GuildUsers)
                .HasForeignKey(d => d.GuildId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.GuildUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<UserTimeSpentVc>(entity =>
        {
            entity.ToTable("UserTimeSpentVc");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Username).HasColumnType("TEXT(50)");
        });

        //OnModelCreatingPartial(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseLazyLoadingProxies();

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
