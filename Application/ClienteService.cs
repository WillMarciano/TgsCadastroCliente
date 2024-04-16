using Application.Contratos;
using Application.Dtos;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Repository.Contratos;

namespace Application
{
    public class ClienteService(IClienteRepository clienteRepository, IMapper mapper) : IClienteService
    {
        public async Task<ClienteDto?> GetClienteByIdAsync(int userId)
        {
            var cliente = await clienteRepository.GetClienteByIdAsync(userId);
            return cliente == null ? null : mapper.Map<ClienteDto?>(cliente);
        }

        public async Task<byte[]?> GetLogoAsync(int id)
        {
            var customer = await clienteRepository.GetClienteByIdAsync(id);
            if (customer == null || customer.Logotipo == null || customer.Logotipo.Length == 0)
                return null;

            return customer.Logotipo;
        }

        public async Task<ClienteDto?> AddClienteAsync(int userId, ClienteDto model)
        {
            var cliente = mapper.Map<Cliente>(model);
            cliente.Id = userId;
            cliente.DataRegistro = DateTime.Now;

            clienteRepository.Add(cliente);
            if (await clienteRepository.SaveChangesAsync())
                return mapper.Map<ClienteDto>(await clienteRepository.GetClienteByIdAsync(userId));

            return null;
        }

        public async Task<ClienteDto?> UpdateClienteAsync(int userId, ClienteUpdateDto model)
        {
            var cliente = await clienteRepository.GetClienteByIdAsync(userId);
            if (cliente == null) return null;
            clienteRepository.Update(mapper.Map(model, cliente));

            if (await clienteRepository.SaveChangesAsync())
                return mapper.Map<ClienteDto>(await clienteRepository.GetClienteByIdAsync(userId));

            return null;
        }

        public async Task<bool> SaveLogoAsync(int userId, LogotipoDto model)
        {
            var customer = await clienteRepository.GetClienteByIdAsync(userId);
            if(customer == null) return false;

            if(model.LogoByte == null || model.LogoByte.Length == 0 && model.LogoFile.Length > 0) 
                model.LogoByte = GetBytesFromImage(model.LogoFile);

            customer.Logotipo = model.LogoByte;            
            clienteRepository.Update(customer);

            if (await clienteRepository.SaveChangesAsync())
                return true;

            return false;
        }

        private static byte[] GetBytesFromImage(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }
            return fileBytes;
        }
    }
}
