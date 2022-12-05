namespace PasswordAPI.Services.CryptoService
{
    public interface ICryptographyService
    {
        string Encrypt(string value, string key);
        string Decrypt(string value, string key);
    }
}
