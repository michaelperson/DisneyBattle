﻿namespace DisneyBattle.API.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}
