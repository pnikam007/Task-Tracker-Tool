﻿namespace TaskTrackerWebAPI.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public int Status { get; set; }

    }
}
