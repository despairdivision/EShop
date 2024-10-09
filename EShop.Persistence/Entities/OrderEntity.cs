using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EShop.Core.Models;

namespace EShop.Persistence.Entities;

public class OrderEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual UserEntity User { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public ICollection<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>();

    [Required]
    public decimal TotalAmount { get; set; }
}
