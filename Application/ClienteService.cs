using Application.Contratos;
using Application.Dtos;
using AutoMapper;
using Domain.Entity;
using Repository.Contratos;

namespace Application
{
    public class ClienteService(IClienteRepository clienteRepository, IMapper mapper) : IClienteService
    {
        public async Task<ClienteDto?> AddCliente(int userId, ClienteDto model)
        {
            var cliente = mapper.Map<Cliente>(model);
            cliente.Id = userId;
            cliente.DataRegistro = DateTime.Now;

            clienteRepository.Add(cliente);
            if (await clienteRepository.SaveChangesAsync())
                return mapper.Map<ClienteDto>(await clienteRepository.GetClienteByIdAsync(userId));

            return null;
        }

        public async Task<ClienteDto?> GetClienteByIdAsync(int userId)
        {            
            var cliente = await clienteRepository.GetClienteByIdAsync(userId);
            return cliente == null ? null : mapper.Map<ClienteDto?>(cliente);
        }

        public async Task<ClienteDto?> UpdateCliente(int userId, ClienteUpdateDto model)
        {
            var cliente = await clienteRepository.GetClienteByIdAsync(userId);
            if (cliente == null) return null;

            clienteRepository.Update(mapper.Map(model, cliente));

            if (await clienteRepository.SaveChangesAsync())
                return mapper.Map<ClienteDto>(await clienteRepository.GetClienteByIdAsync(userId));

            return null;
        }
    }
}
