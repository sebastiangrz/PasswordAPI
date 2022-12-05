using PasswordAPI.Models;

namespace PasswordAPI.Services.PasswordService
{
    public interface IPasswordService
    {
        Task<List<Password>> GetAllPasswords(string userId);
        Task<Password?> GetPassword(int id, string userId);
        Task<List<Password>> AddPassword(Password newPassword, string userId);
        Task<List<Password>?> DeletePassword(int id, string userId);
        Task<List<Password>?> UpdatePassword(int id, Password request, string userId);
    }
}
