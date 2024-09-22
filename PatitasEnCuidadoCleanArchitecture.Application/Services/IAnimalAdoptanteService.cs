using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Application.Services
{
    public interface IAnimalAdoptanteService
    {
        Task<List<AnimalAdoptante>> GetAllAnimalAdoptanteAsync();
        Task<AnimalAdoptante> GetAnimalAdoptanteByIdAsync(int Id);
        Task<AnimalAdoptante> CreateAnimalAdoptanteAsync(AnimalAdoptante animalAdoptante);
        Task<int> UpdateAnimalAdoptanteAsync(int Id, AnimalAdoptante animalAdoptante);
        Task<int> DeleteAnimalAdoptanteAsync(int Id);
    }
}
