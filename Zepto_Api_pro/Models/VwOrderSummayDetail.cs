using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zepto_Api_pro.Models;

[Keyless]
public partial class VwOrderSummayDetail
{
    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column("Customer Name")]
    [StringLength(100)]
    [Unicode(false)]
    public string CustomerName { get; set; } = null!;

    [Column("Vendor Name")]
    [StringLength(100)]
    public string? VendorName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderDate { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? TotalAmount { get; set; }

    [StringLength(50)]
    public string? StatusName { get; set; }
}
