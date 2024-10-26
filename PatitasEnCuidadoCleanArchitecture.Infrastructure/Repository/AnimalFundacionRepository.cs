using Microsoft.EntityFrameworkCore;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Interface;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Infrastructure.Repository
{
    public class AnimalFundacionRepository : IAnimalFundacionRepository
    {
        private readonly PatitasEnCuidadoDbContext _Context;

        public AnimalFundacionRepository(PatitasEnCuidadoDbContext Context)
        {
            this._Context = Context;
        }

        public async Task<AnimalFundacion> CreateAnimalFundacionAsync(AnimalFundacion animalFundacion)
        {
            await _Context.AnimalFundaciones.AddAsync(animalFundacion);
            await _Context.SaveChangesAsync();

            return animalFundacion;
        }

        public async Task<int> DeleteAnimalFundacionAsync(int Id)
        {
            return await _Context.AnimalFundaciones
              .Where(model => model.Id == Id).ExecuteDeleteAsync();
        }

        public async Task<List<AnimalFundacion>> GetAllAnimalFundacionAsync()
        {
            return await _Context.AnimalFundaciones.ToListAsync();
        }

        public async Task<AnimalFundacion> GetAnimalFundacionByIdAsync(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("El ID debe ser un valor positivo.", nameof(Id));
            }

            try
            {
                var animalFundacion = await _Context.AnimalFundaciones
                    .AsNoTracking()
                    .FirstOrDefaultAsync(v => v.Id == Id);

                if (animalFundacion is null)
                {
                    throw new KeyNotFoundException($"No se encontró una vacuna con el ID {Id}.");
                }

                return animalFundacion;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener la vacuna con ID {Id}.", ex);
            }
        }

        public async Task<int> UpdateAnimalFundacionAsync(int Id, AnimalFundacion animalFundacion)
        {
            return await _Context.AnimalFundaciones
              .Where(model => model.Id == Id)
              .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.IdFundacion, animalFundacion.IdFundacion)
                  .SetProperty(m => m.IdAnimal, animalFundacion.IdAnimal)
              );
        }
    }
}
