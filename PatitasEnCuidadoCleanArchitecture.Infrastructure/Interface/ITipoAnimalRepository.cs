using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Infrastructure.Interface
{
    public interface ITipoAnimalRepository
    {
        Task<List<TipoAnimal>> GetAllTipoAnimalAsync();
        Task<TipoAnimal> GetTipoAnimalByIdAsync(int Id);
        Task<TipoAnimal> CreateTipoAnimalAsync(TipoAnimal tipoAnimal);
        Task<int> UpdateTipoAnimalAsync(int Id, TipoAnimal tipoAnimal);
        Task<int> DeleteTipoAnimalAsync(int Id);
    }
}
