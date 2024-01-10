﻿using System.ComponentModel.DataAnnotations;

namespace backend.Models.DTOs.UserDTOs;

public class LoginDTO
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}