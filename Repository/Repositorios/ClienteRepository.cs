using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Contexto;
using Repository.Contratos;

namespace Repository.Repositorios
{
    public class ClienteRepository(ClienteContexto contexto) : GeralRepository(contexto), IClienteRepository
    {
        private readonly ClienteContexto _contexto = contexto;

        private IQueryable<Cliente> FilterQuery()
        {
            var query = _contexto.Clientes
                .Include(p => p.Logradouros)
                .OrderBy(p => p.Id)
                .AsNoTracking();

            return query;
        }

        public async Task<Cliente?> GetClienteByIdAsync(int clienteId)        
            => await FilterQuery().FirstOrDefaultAsync(x => x.Id == clienteId) ?? null;        
    }
}
