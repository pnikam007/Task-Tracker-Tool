using System;

namespace TaskTrackerWebAPI.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public string Hours { get; set; }
        public DateTime Date { get; set; } 

}
}
