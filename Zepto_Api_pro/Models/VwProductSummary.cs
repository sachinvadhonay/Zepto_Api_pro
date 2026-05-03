using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zepto_Api_pro.Models;

[Keyless]
public partial class VwProductSummary
{
    [Column("ProductID")]
    public int ProductId { get; set; }

    [StringLength(100)]
    public string Productname { get; set; } = null!;

    [Column("sales")]
    public int? Sales { get; set; }
}
