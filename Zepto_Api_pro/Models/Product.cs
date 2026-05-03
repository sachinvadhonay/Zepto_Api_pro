using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zepto_Api_pro.Models;

[Index("Productname", Name = "idx_ProductName")]
public partial class Product
{
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    [StringLength(100)]
    public string Productname { get; set; } = null!;

    [StringLength(100)]
    public string? Description { get; set; }

    [Column("CategoryID")]
    public int? CategoryId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Price { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(255)]
    public string? ImageUrl { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual ProductCategory? Category { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    [InverseProperty("Product")]
    public virtual ICollection<OrdersItem> OrdersItems { get; set; } = new List<OrdersItem>();

    [InverseProperty("Product")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
