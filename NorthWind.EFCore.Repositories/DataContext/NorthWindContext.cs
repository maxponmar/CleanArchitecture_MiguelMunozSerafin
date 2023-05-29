namespace NorthWind.EFCore.Repositories.DataContext
{
    //  Add-Migration InitialCreate -p NorthWind.EFCore.Repositories -s NorthWind.EFCore.Repositories -C NorthWindContext
    //  Update-Database InitialCreate -p NorthWind.EFCore.Repositories -s NorthWind.EFCore.Repositories -context NorthWindContext
    internal class NorthWindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=NorthWindCleanArchitecture;Trusted_Connection=True;");
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
