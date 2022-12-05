using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasswordAPI.Models;
using PasswordAPI.Services.CryptoService;
using PasswordAPI.Services.PasswordService;
using System.Security.Claims;

namespace PasswordAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : Controller
    {
        private readonly IPasswordService _passwordService;
        private readonly ICryptographyService _cryptographyService;
        public PasswordController(IPasswordService passwordService, ICryptographyService cryptographyService)
        {
            _passwordService = passwordService;
            _cryptographyService = cryptographyService;
        }

        [HttpGet]
        [Route("getPasswords")]
        public async Task<ActionResult<List<Password>>> GetPasswords()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            return await _passwordService.GetAllPasswords(userId);
        }

        [HttpGet]
        [Route("getPassword/{id}")]
        public async Task<ActionResult<Password>> GetPassword(int id, string masterPassword)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var result = await _passwordService.GetPassword(id, userId);
            if (result is null)
                return NotFound("No Password found with this Id ");

            var decryptedPassword = _cryptographyService.Decrypt(result.Value, masterPassword);

            result.Value = decryptedPassword;

            return Ok(result);
        }

        [HttpPost]
        [Route("addPassword")]
        public async Task<ActionResult<Password>> AddPassword(PasswordRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var encryptedPw = _cryptographyService.Encrypt(request.Value, request.MasterKey);

            var password = new Password {
                Tag = request.Tag,
                UserId = userId,
                Username = request.Username,
                Value = encryptedPw
             };

            var result = await _passwordService.AddPassword(password, userId);

            return Ok(result);
        }

        [HttpPut]
        [Route("updatePassword/{id}")]
        public async Task<ActionResult<Password>> UpdatePassword(int id, PasswordRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var encryptedPw = _cryptographyService.Encrypt(request.Value, request.MasterKey);

            var password = new Password
            {
                Tag = request.Tag,
                UserId = userId,
                Username = request.Username,
                Value = encryptedPw
            };

            var result = await _passwordService.UpdatePassword(id, password, userId);
            if (result is null)
                return NotFound("No Password found with this Id ");

            return Ok(result);
        }
    }
}
