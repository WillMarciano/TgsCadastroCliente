using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Contexto;
using Repository.Contratos;

namespace Repository.Repositorios
{
    public class UserRepository(ClienteContexto contexto) : GeralRepository(contexto), IUserRepository
    {
        private readonly ClienteContexto _contexto = contexto;

        public async Task<IEnumerable<User>> GetUsersAsync() => await _contexto.Users.ToListAsync();

        public async Task<User?> GetUserByIdAsync(int id) => await _contexto.Users.FindAsync(id);

        public async Task<User?> GetUserByUserNameAsync(string userName) => await _contexto.Users
                                 .SingleOrDefaultAsync(user => user.UserName == userName.ToLower());
    }
}
