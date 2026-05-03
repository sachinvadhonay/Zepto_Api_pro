using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zepto_Api_pro.Models;

[Table("tbl_user_Audit")]
public partial class TblUserAudit
{
    [Key]
    [Column("Audit_id")]
    public int AuditId { get; set; }

    [Column("Audit_info")]
    [Unicode(false)]
    public string? AuditInfo { get; set; }
}
