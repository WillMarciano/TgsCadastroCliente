using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Contexto;
using Repository.Contratos;

namespace Repository.Repositorios
{
    public class LogradouroRepository(ClienteContexto contexto) : GeralRepository(contexto), ILogradouroRepository
    {
        private readonly ClienteContexto _contexto = contexto;

        private IQueryable<Logradouro> FilterQuery(int eventoId)
        {
            
            IQueryable<Logradouro> query = _contexto.Logradouros.Where(e => e.ClienteId == eventoId);

            query = query.OrderBy(e => e.Id);
            return query.AsNoTracking();
        }

        public async Task<Logradouro?> GetLogradouroByIdAsync(int clienteId, int logradouroId)
            => await FilterQuery(clienteId).FirstOrDefaultAsync(e => e.Id == logradouroId && e.ClienteId == clienteId);

        public async Task<Logradouro[]?> GetLogradourosByClienteIdAsync(int clienteId)
            => await FilterQuery(clienteId).ToArrayAsync();
    }
}
