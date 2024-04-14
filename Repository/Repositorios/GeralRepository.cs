using Repository.Contexto;
using Repository.Contratos;

namespace Repository.Repositorios
{
    public class GeralRepository(ClienteContexto context) : IGeralRepository
    {
        public void Add<T>(T entity) where T : class => context.Add(entity);

        public void Update<T>(T entity) where T : class => context.Update(entity);

        public void Delete<T>(T entity) where T : class => context.Remove(entity);

        public void DeleteRange<T>(T[] entity) where T : class => context.RemoveRange(entity);

        public async Task<bool> SaveChangesAsync() => (await context.SaveChangesAsync()) > 0;
    }
}
