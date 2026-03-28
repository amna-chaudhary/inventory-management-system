using System.Data.Entity;
using MVCPro.Models;

public partial class MVCProEntities : DbContext
{
    public MVCProEntities()
        : base("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=MVCPro;Integrated Security=True;")
    {
    }

    public DbSet<SalesOrder> SalesOrders { get; set; }
    public DbSet<SalesOrderItem> SalesOrderItems { get; set; }
    public DbSet<CustomerTable> CustomerTable { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<Product> Products { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // No custom mapping needed, EF will use class names by convention
    }
}
