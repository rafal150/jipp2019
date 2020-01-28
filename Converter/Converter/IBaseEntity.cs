using System;
using System.Collections.Generic;
using System.Text;

namespace Converter
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }

        DateTime CreatedAt { get; set; }
    }
}
