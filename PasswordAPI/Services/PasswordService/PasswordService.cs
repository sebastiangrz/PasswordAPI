using PasswordAPI.Data;
using PasswordAPI.Models;

namespace PasswordAPI.Services.PasswordService
{
    public class PasswordService : IPasswordService
    {
        private readonly DataContext _context;
        public PasswordService(DataContext context) 
        {
            this._context = context;
        }

        public async Task<List<Password>> AddPassword(Password newPassword, string userId)
        {
            _context.Add(newPassword);
            await _context.SaveChangesAsync(); 

            var passwords = await _context.Passwords.Where((p) => p.UserId == userId).ToListAsync();
            return passwords;
        }

        public async Task<List<Password>?> DeletePassword(int id, string userId)
        {
            var password = await _context.Passwords.FindAsync(id);

            if (password is null)
                return null;

            if (password.UserId != userId)
                return null;

            _context.Passwords.Remove(password);
            await _context.SaveChangesAsync();

            var passwords = await _context.Passwords.Where((p) => p.UserId == userId).ToListAsync();
            return passwords;
        }

        public async Task<List<Password>> GetAllPasswords(string userId)
        {
            var passwords = await _context.Passwords.Where((p) => p.UserId == userId).ToListAsync();

            return passwords;
        }

        public async Task<Password?> GetPassword(int id, string userId)
        {
            var password = await _context.Passwords.FindAsync(id);
            if(password is null)
                return null;

            if (password.UserId != userId)
                return null;

            return password;
        }

        public async Task<List<Password>?> UpdatePassword(int id, Password request, string userId)
        {
            var password = await _context.Passwords.FindAsync(id);
            if (password is null)
                return null;

            if (password.UserId != userId)
                return null;

            password.Tag= request.Tag;
            password.Username = request.Username;
            password.Value = request.Value;

            await _context.SaveChangesAsync();

            var passwords = await _context.Passwords.Where((p) => p.UserId == userId).ToListAsync();

            return passwords;

        }
    }
}
