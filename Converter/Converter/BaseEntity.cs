using System;
using System.Collections.Generic;
using System.Text;

namespace Converter
{
    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
        }

        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
