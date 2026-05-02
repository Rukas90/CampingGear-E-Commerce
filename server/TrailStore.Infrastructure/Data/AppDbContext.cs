using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Models;
using TrailStore.Infrastructure.Data.Config;

namespace TrailStore.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Customer>        Customers        { get; set; }
      
    public DbSet<Address>         Addresses        { get; set; }
  
    public DbSet<RefreshToken>    RefreshTokens    { get; set; }
      
    public DbSet<Cart>            Carts            { get; set; }
      
    public DbSet<CartItem>        CartItems        { get; set; }
      
    public DbSet<Order>           Orders           { get; set; }
      
    public DbSet<OrderItem>       OrderItems       { get; set; }
      
    public DbSet<Category>        Categories       { get; set; }
      
    public DbSet<Brand>           Brands           { get; set; }
      
    public DbSet<OptionGroup>     OptionGroups     { get; set; }
      
    public DbSet<Option>          Options          { get; set; }
      
    public DbSet<Product>         Products         { get; set; }
      
    public DbSet<ProductImage>    ProductImages    { get; set; }
    
    public DbSet<ProductImageUrl> ProductImageUrls { get; set; }
    
    public DbSet<Sku>             Skus             { get; set; }
     
    public DbSet<Review>          Reviews          { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder config)
        => IdConfigConversions.ConfigureIdConversion(config);
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}