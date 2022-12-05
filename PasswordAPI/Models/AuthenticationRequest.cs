﻿using System.ComponentModel.DataAnnotations;

namespace PasswordAPI.Models
{
    public class AuthenticationRequest
    {
        [Required] public string UserName { get; set; } = string.Empty;
        [Required] public string Password { get; set; } = string.Empty;
    }
}
