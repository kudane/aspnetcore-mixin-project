namespace Infrastructure.Data.EfCore.StoredProcedures
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<DbContext> options)
            : base(options)
        {
            
        }

        public StoreContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                optionsBuilder.UseSqlServer("Server=DESKTOP-????;Database=blogging;User ID=???;Password=???");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set HasNoKey() Only
            modelBuilder.Entity<BlogWithPost>(entity =>
            {
                entity.HasNoKey();
            });
        }

        // Setting Stored Procedure
        public virtual DbSet<BlogWithPost> GetBlogWithPost { get; set; }
    }
}