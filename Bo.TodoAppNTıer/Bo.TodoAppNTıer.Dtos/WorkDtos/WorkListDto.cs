using Bo.TodoAppNTİer.Dtos.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bo.TodoAppNTİer.Dtos.WorkDtos
{
    public class WorkListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public bool IsComplete { get; set; }
    }
}
