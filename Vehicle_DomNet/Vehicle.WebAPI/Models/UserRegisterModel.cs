﻿
namespace Vehicle.WebAPI.Models
{
    public class UserRegisterModel
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
    }
}
