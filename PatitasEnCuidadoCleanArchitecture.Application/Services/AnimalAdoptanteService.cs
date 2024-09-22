using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using PatitasEnCuidadoCleanArchitecture.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Application.Services
{
    public class AnimalAdoptanteService : IAnimalAdoptanteService
    {
        private readonly IAnimalAdoptanteRepository _repositoryAnimalAdoptante;

        public AnimalAdoptanteService(IAnimalAdoptanteRepository _repositoryAnimalAdoptante)
        {
            this._repositoryAnimalAdoptante = _repositoryAnimalAdoptante;
        }

        public async Task<AnimalAdoptante> CreateAnimalAdoptanteAsync(AnimalAdoptante animalAdoptante)
        {
            return await _repositoryAnimalAdoptante.CreateAnimalAdoptanteAsync(animalAdoptante);
        }

        public async Task<int> DeleteAnimalAdoptanteAsync(int Id)
        {
            return await _repositoryAnimalAdoptante.DeleteAnimalAdoptanteAsync(Id);
        }

        public async Task<List<AnimalAdoptante>> GetAllAnimalAdoptanteAsync()
        {
            return await _repositoryAnimalAdoptante.GetAllAnimalAdoptanteAsync();
        }

        public async Task<AnimalAdoptante> GetAnimalAdoptanteByIdAsync(int Id)
        {
            return await _repositoryAnimalAdoptante.GetAnimalAdoptanteByIdAsync(Id);
        }

        public async Task<int> UpdateAnimalAdoptanteAsync(int Id, AnimalAdoptante animalAdoptante)
        {
            return await _repositoryAnimalAdoptante.UpdateAnimalAdoptanteAsync(Id, animalAdoptante);
        }
    }
}
