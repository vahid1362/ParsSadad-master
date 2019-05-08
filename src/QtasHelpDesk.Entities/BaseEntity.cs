using System;
using System.Collections.Generic;
using System.Text;

namespace QtasHelpDesk.Domain
{
    public abstract class BaseEntity<T>
    {
        public  T Id { get; set; }
    }
}
