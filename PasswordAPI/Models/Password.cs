using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace PasswordAPI.Models
{
    public class Password 
    {
        // The Id of the password in the DB
        public int Id { get; set; }

        // The Id of the User the password entity belongs to
        public string UserId { get; set; } = string.Empty;

        // A Tag for the Psssword 
        public string Tag { get; set; } = string.Empty;

        // The Username for the Password
        public string Username { get; set; } = string.Empty;

        // The Password Value
        public string Value { get; set; } = string.Empty;

    }
}
