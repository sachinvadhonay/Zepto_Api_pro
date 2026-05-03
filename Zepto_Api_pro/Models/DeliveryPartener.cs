using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zepto_Api_pro.Models;

[Table("DeliveryPartener")]
public partial class DeliveryPartener
{
    [Key]
    [Column("PartenerID")]
    public int PartenerId { get; set; }

    [StringLength(50)]
    public string? FullName { get; set; }

    [StringLength(10)]
    public string? PhoneNumber { get; set; }
}
