using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public abstract class BaseEntities
    {
        [Key,Required]
        public Guid Id { get; set;  }
    }
}
