using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zepto_Api_pro.Models;

public partial class Vendor
{
    [Key]
    [Column("vendorID")]
    public int VendorId { get; set; }

    [StringLength(100)]
    public string? Vendorname { get; set; }

    [StringLength(100)]
    public string? ContactEmail { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Vendor")]
    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    [InverseProperty("Vendor")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
