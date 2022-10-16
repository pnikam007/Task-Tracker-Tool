using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerWebAPI.Models
{
    public class TaskStatus
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
