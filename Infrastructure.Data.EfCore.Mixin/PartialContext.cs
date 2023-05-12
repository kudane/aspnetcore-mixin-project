namespace Infrastructure.Data.EfCore.Mixin
{
    public partial class AppDbContext : DbContext
    {
        public virtual DbSet<BlogWithPost> GetBlogWithPost { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            // Set HasNoKey() Only
            modelBuilder.Entity<BlogWithPost>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}