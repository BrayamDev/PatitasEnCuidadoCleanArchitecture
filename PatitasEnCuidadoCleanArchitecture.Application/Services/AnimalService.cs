using PatitasEnCuidadoCleanArchitecture.Application.Interface;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Interface;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Application.Services
{
    public class AnimalService : IAnimalService 
    {
        private readonly IAnimalRepository _animalService;

        public AnimalService(IAnimalRepository animalService)
        {
            this._animalService = animalService;
        }

        public async Task<Animal> CreateAnimalAsync(Animal animal, byte[] contenidoImagen)
        {
            return await _animalService.CreateAnimalAsync(animal, contenidoImagen);
        }

        public async Task<int> DeleteAnimalAsync(int Id)
        {
            return await _animalService.DeleteAnimalAsync(Id);
        }

        public async Task<List<Animal>> GetAllAnimalAsync()
        {
            return await _animalService.GetAllAnimalAsync();
        }

        public async Task<Animal> GetAnimalByIdAsync(int Id)
        {
            return await _animalService.GetAnimalByIdAsync(Id);
        }

        public async Task<int> UpdateAnimalAsync(int Id, Animal animal, byte[]? contenidoImagen = null)
        {
            return await _animalService.UpdateAnimalAsync(Id, animal, contenidoImagen);
        }
    }
}
