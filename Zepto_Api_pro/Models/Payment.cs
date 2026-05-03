using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zepto_Api_pro.Models;

public partial class Payment
{
    [Key]
    [Column("PaymentID")]
    public int PaymentId { get; set; }

    [Column("OrderID")]
    public int? OrderId { get; set; }

    [StringLength(50)]
    public string? PaymentMode { get; set; }

    [StringLength(50)]
    public string? PaymentStatus { get; set; }

    [Column("PaidAT", TypeName = "datetime")]
    public DateTime? PaidAt { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("Payments")]
    public virtual Order? Order { get; set; }
}
