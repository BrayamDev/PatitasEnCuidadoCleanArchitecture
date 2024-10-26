using PatitasEnCuidadoCleanArchitecture.Application.Interface;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Application.Services
{
    public class AnimalFundacionService : IAnimalFundacionService
    {
        private readonly IAnimalFundacionService _repositoryAnimalFundacionService;

        public AnimalFundacionService(IAnimalFundacionService repositoryFundacionService)
        {
            this._repositoryAnimalFundacionService = repositoryFundacionService;
        }

        public async Task<AnimalFundacion> CreateAnimalFundacionAsync(AnimalFundacion animalFundacion)
        {
            return await _repositoryAnimalFundacionService.CreateAnimalFundacionAsync(animalFundacion);
        }

        public async Task<int> DeleteAnimalFundacionAsync(int Id)
        {
            return await _repositoryAnimalFundacionService.DeleteAnimalFundacionAsync(Id);
        }

        public async Task<List<AnimalFundacion>> GetAllAnimalFundacionAsync()
        {
            return await _repositoryAnimalFundacionService.GetAllAnimalFundacionAsync();
        }

        public async Task<AnimalFundacion> GetAnimalFundacionByIdAsync(int Id)
        {
            return await _repositoryAnimalFundacionService.GetAnimalFundacionByIdAsync(Id);
        }

        public async Task<int> UpdateAnimalFundacionAsync(int Id, AnimalFundacion animalFundacion)
        {
            return await _repositoryAnimalFundacionService.UpdateAnimalFundacionAsync(Id, animalFundacion);
        }
    }
}
