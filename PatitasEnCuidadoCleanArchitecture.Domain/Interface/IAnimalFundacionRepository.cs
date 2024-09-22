using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Domain.Interface
{
    public interface IAnimalFundacionRepository
    {
        Task<List<AnimalFundacion>> GetAllAnimalFundacionAsync();
        Task<AnimalFundacion> GetAnimalFundacionByIdAsync(int Id);
        Task<AnimalFundacion> CreateAnimalFundacionAsync(AnimalFundacion animalFundacion);
        Task<int> UpdateAnimalFundacionAsync(int Id, AnimalFundacion animalFundacion);
        Task<int> DeleteAnimalFundacionAsync(int Id);
    }
}
