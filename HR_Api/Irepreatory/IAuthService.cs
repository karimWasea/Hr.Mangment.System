using apistudy.Models.Entityies;
using DataAcess.layes;

namespace HR_Api.Irepreatory
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
        Task<AuthModel> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
        Task<IEnumerable<Applicaionuser>> GetAllusers();


    }
}
