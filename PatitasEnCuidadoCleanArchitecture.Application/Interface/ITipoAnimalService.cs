using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Application.Interface
{
    public interface ITipoAnimalService
    {
        Task<List<TipoAnimal>> GetAllTipoAnimalAsync();
        Task<TipoAnimal> GetTipoAnimalsById(int Id);
        Task<TipoAnimal> CreateTipoAnimalAsync(TipoAnimal tipoAnimal);
        Task<int> UpdateTipoAnimalAsync(int Id, TipoAnimal tipoAnimal);
        Task<int> DeleteTipoAnimalAsync(int Id);

    }
}
