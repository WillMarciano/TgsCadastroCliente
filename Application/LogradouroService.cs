using Application.Contratos;
using Application.Dtos;
using AutoMapper;
using Domain.Entity;
using Repository.Contratos;

namespace Application
{
    public class LogradouroService(ILogradouroRepository logradouroRepository, IMapper mapper) : ILogradouroService
    {
        public async Task<IEnumerable<LogradouroDto>?> GetAllLogradourosAsync(int userId)
        {
            var logradouros = await logradouroRepository.GetLogradourosByClienteIdAsync(userId);
            if (logradouros == null) return null;
            return mapper.Map<IEnumerable<LogradouroDto>>(logradouros);
        }

        public async Task<LogradouroDto?> GetLogradouroByIdAsync(int userId, int logradouroId)
        {
            var logradouro = await logradouroRepository.GetLogradouroByIdAsync(userId, logradouroId);
            if (logradouro == null) return null;
            return mapper.Map<LogradouroDto>(logradouro);
        }
        public async Task<LogradouroDto> SaveLogradouro(int userId, LogradouroDto model)
        {
            var logradouro = mapper.Map<Logradouro>(model);
            logradouro.ClienteId = userId;
            logradouro.DataRegistro = DateTime.Now;

            if (model.Id != 0)
            {
                var busca = await logradouroRepository.GetLogradouroByIdAsync(userId, model.Id);
                if (busca == null)
                    throw new Exception("Logradouro não encontrado.");
                logradouroRepository.Update(logradouro);
            }
            else
                logradouroRepository.Add(logradouro);

            if (await logradouroRepository.SaveChangesAsync())
                return mapper.Map<LogradouroDto>(logradouro);

            return model;
        }

        public async Task<bool> DeleteLogradouro(int userId, int logradouroId)
        {
            var logradouro = await logradouroRepository.GetLogradouroByIdAsync(userId, logradouroId);
            if (logradouro == null) throw new Exception("Logradouro não encontrado.");

            logradouroRepository.Delete(logradouro);
            return await logradouroRepository.SaveChangesAsync();
        }

        public async Task<List<LogradouroDto>> SaveLogradourosAsync(int userId, List<LogradouroDto> model)
        {
            var logradouros = await logradouroRepository.GetLogradourosByClienteIdAsync(userId);
            if (logradouros == null) return null;

            foreach (var logradouro in logradouros)
            {
                var logradouroDto = model.FirstOrDefault(x => x.Id == logradouro.Id);
                if (logradouroDto == null)
                {
                    logradouroRepository.Delete(logradouro);
                }
                else
                {
                    logradouro.DataRegistro = DateTime.Now;
                    mapper.Map(logradouroDto, logradouro);
                    logradouroRepository.Update(logradouro);
                }
            }

            foreach (var logradouroDto in model)
            {
                if (logradouros.Any(x => x.Id == logradouroDto.Id)) continue;

                var logradouro = mapper.Map<Logradouro>(logradouroDto);
                logradouro.ClienteId = userId;
                logradouroRepository.Add(logradouro);
            }

            if (await logradouroRepository.SaveChangesAsync())
                return mapper.Map<List<LogradouroDto>>(logradouros);
            return model;
        }
    }
}
