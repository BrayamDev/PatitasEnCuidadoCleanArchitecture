using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Application.Services
{
    public interface IAnimalService
    {
        Task<List<Animal>> GetAllAnimalAsync();
        Task<Animal> GetAnimalByIdAsync(int Id);
        Task<Animal> CreateAnimalAsync(Animal animal, byte[] contenidoImagen);
        Task<int> UpdateAnimalAsync(int Id, Animal animal, byte[]? contenidoImagen = null);
        Task<int> DeleteAnimalAsync(int Id);
    }
}
