﻿namespace Domain.common;
public interface ISoftDelete
{
    bool IsDeleted { get; set; }
}