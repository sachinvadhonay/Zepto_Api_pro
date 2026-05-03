using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zepto_Api_pro.Models;

[Table("Inventory")]
public partial class Inventory
{
    [Key]
    [Column("InventoryID")]
    public int InventoryId { get; set; }

    [Column("VendorID")]
    public int? VendorId { get; set; }

    [Column("ProductID")]
    public int? ProductId { get; set; }

    public int? QuatityAvailable { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastUpdated { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Inventories")]
    public virtual Product? Product { get; set; }

    [ForeignKey("VendorId")]
    [InverseProperty("Inventories")]
    public virtual Vendor? Vendor { get; set; }
}
