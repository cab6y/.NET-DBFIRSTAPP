﻿

namespace Domain.common;
 public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime Created { get; set; }

    public DateTime? LastModified { get; set; }
}