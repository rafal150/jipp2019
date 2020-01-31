using System;
using System.Collections.Generic;
using System.Text;

namespace Converter
{
    public class Entity : IEntity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
        }

        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
