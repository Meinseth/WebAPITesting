﻿using Microsoft.EntityFrameworkCore;

namespace WebAPITesting.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Password { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string Email { get; set; }
        public string Fullname => Firstname + " " + Lastname;
    }
}
