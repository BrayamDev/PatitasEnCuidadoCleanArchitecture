using PatitasEnCuidadoCleanArchitecture.Application.Interface;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Interface;

namespace PatitasEnCuidadoCleanArchitecture.Application.Services
{
    public class TipoAnimalService : ITipoAnimalService
    {
        private readonly ITipoAnimalRepository _tipoAnimalRepository;

        public TipoAnimalService(ITipoAnimalRepository tipoAnimalRepository)
        {
            this._tipoAnimalRepository = tipoAnimalRepository;
        }

        public async Task<TipoAnimal> CreateTipoAnimalAsync(TipoAnimal tipoAnimal)
        {
            return await _tipoAnimalRepository.CreateTipoAnimalAsync(tipoAnimal);
        }

        public async Task<int> DeleteTipoAnimalAsync(int Id)
        {
            return await _tipoAnimalRepository.DeleteTipoAnimalAsync(Id);
        }

        public async Task<List<TipoAnimal>> GetAllTipoAnimalAsync()
        {
            return await _tipoAnimalRepository.GetAllTipoAnimalAsync();
        }

        public Task<TipoAnimal> GetTipoAnimalByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<TipoAnimal> GetTipoAnimalsById(int Id)
        {
            return await _tipoAnimalRepository.GetTipoAnimalByIdAsync(Id);
        }

        public async Task<int> UpdateTipoAnimalAsync(int Id, TipoAnimal tipoAnimal)
        {
            return await _tipoAnimalRepository.UpdateTipoAnimalAsync(Id, tipoAnimal);
        }
    }
}
