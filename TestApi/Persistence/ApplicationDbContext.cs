using Microsoft.EntityFrameworkCore;
using TestApi.Persistence.Models;

namespace TestApi.Persistence;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<AuthorEntity> Authors { get; set; } = null!;

    public virtual DbSet<BookEntity> Books { get; set; } = null!;

    public virtual DbSet<BookRequestEntity> BookRequests { get; set; } = null!;


    public ApplicationDbContext(
        DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BookRequestEntity>()
            .Property(x => x.RequestType)
            .HasConversion<string>();

        modelBuilder.Entity<BookRequestEntity>()
            .Property(x => x.ApprovalStatus)
            .HasConversion<string>();


        modelBuilder.Entity<BookRequestEntity>()
            .HasIndex(b => new { b.AuthorId, b.Title, b.ApprovalStatus })
            .IsUnique()
            .HasFilter("""
                       "ApprovalStatus" = 'Pending'
                       """);

        modelBuilder.Entity<BookRequestEntity>()
            .HasIndex(b => new { b.AuthorId, b.NewTitle, b.ApprovalStatus })
            .IsUnique()
            .HasFilter("""
                       "ApprovalStatus" = 'Pending'
                       """);

        modelBuilder.Entity<BookEntity>()
            .HasIndex(b => new { b.AuthorId, b.Title })
            .IsUnique();

        List<AuthorEntity> authors =
        [
            new AuthorEntity(1, "Dr.", "Seuss"),
            new AuthorEntity(2, "Roald", "Dahl"),
            new AuthorEntity(3, "Beatrix", "Potter"),
            new AuthorEntity(4, "Maurice", "Sendak"),
            new AuthorEntity(5, "Eric", "Carle"),
            new AuthorEntity(6, "Shel", "Silverstein"),
            new AuthorEntity(7, "Judy", "Blume")
        ];


        modelBuilder.Entity<AuthorEntity>()
            .HasData(authors);
    }
}