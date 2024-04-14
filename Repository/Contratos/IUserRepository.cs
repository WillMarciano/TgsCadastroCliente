using Domain.Identity;

namespace Repository.Contratos
{
    public interface IUserRepository : IGeralRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByUserNameAsync(string userName);
    }
}
