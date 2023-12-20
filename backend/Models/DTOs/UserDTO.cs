﻿namespace backend.Models.DTOs;

public class UserDTO
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public ProfileDTO Profile { get; set; }
}