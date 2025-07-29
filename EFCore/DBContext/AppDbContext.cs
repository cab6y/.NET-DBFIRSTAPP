
using Domain.Entities.TodoItem;
using EFCore.Interceptors;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    private readonly SoftDeleteInterceptor? _softDeleteInterceptor;

    public AppDbContext(DbContextOptions<AppDbContext> options, SoftDeleteInterceptor? softDeleteInterceptor)
        : base(options)
    {
        _softDeleteInterceptor = softDeleteInterceptor;
    }

    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.DueDate).HasColumnType("date");
            entity.Property(e => e.Created).HasColumnType("date");

            // IsDeleted = false olanları default query'de filtrele
            entity.HasQueryFilter(x => !x.IsDeleted);
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_softDeleteInterceptor);
    }
}
