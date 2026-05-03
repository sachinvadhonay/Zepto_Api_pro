using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zepto_Api_pro.Models;

[Table("DeliveryStatus")]
public partial class DeliveryStatus
{
    [Key]
    [Column("DeliveryID")]
    public int DeliveryId { get; set; }

    [Column("OrderID")]
    public int? OrderId { get; set; }

    [Column("StatusID")]
    public int? StatusId { get; set; }

    [Column("UpdatedAT", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("DeliveryStatuses")]
    public virtual Order? Order { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("DeliveryStatuses")]
    public virtual Status? Status { get; set; }
}
