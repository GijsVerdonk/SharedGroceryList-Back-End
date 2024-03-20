using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedGroceryListAPI.Models;

public class Item
{
    [Key]
    public int id { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string name { get; set; }
    // public int quantity { get; set; }
}