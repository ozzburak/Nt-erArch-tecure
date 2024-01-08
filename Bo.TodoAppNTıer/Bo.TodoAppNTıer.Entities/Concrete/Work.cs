using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bo.TodoAppNTİer.Entities.Concrete
{
    public class Work : BaseEntity
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public bool IsComplete { get; set; }
    }
}
