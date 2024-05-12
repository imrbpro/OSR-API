using Models;

namespace Services.Interface
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email);
    }
}
