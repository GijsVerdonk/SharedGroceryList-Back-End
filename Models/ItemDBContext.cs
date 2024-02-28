using Microsoft.EntityFrameworkCore;

namespace SharedGroceryListAPI.Models;

public class ItemDBContext : DbContext
{
    public ItemDBContext(DbContextOptions<ItemDBContext> options):base(options)
    {
        
    }
    
    public DbSet<Item> items { get; set; }
    
}