using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zepto_Api_pro.Models;

[Index("OrderId", "ProductId", Name = "idx_Orderitems_orders_products")]
public partial class OrdersItem
{
    [Key]
    [Column("OrdersItemsID")]
    public int OrdersItemsId { get; set; }

    [Column("OrderID")]
    public int? OrderId { get; set; }

    [Column("ProductID")]
    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    [Column("price", TypeName = "decimal(10, 2)")]
    public decimal? Price { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrdersItems")]
    public virtual Order? Order { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("OrdersItems")]
    public virtual Product? Product { get; set; }
}
