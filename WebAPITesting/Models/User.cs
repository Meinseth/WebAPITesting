﻿using Microsoft.EntityFrameworkCore;

namespace WebAPITesting.Models
{
    public class User
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public required string Password { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string Email { get; set; }
        public string Fullname => Firstname + " " + Lastname;
        public List<Movie> Movies { get; set; } = new();

    }
}
