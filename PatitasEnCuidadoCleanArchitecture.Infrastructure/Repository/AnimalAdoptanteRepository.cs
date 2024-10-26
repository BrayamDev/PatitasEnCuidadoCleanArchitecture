using Microsoft.EntityFrameworkCore;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Data;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Infrastructure.Repository
{
    public class AnimalAdoptanteRepository : IAnimalAdoptanteRepository
    {

        private readonly PatitasEnCuidadoDbContext _Context;

        public AnimalAdoptanteRepository(PatitasEnCuidadoDbContext Context)
        {
            this._Context = Context;
        }


        public async Task<AnimalAdoptante> CreateAnimalAdoptanteAsync(AnimalAdoptante animalAdoptante)
        {
            await _Context.AnimalAdoptantes.AddAsync(animalAdoptante);
            await _Context.SaveChangesAsync();

            return animalAdoptante;
        }

        public async Task<int> DeleteAnimalAdoptanteAsync(int Id)
        {
            return await _Context.AnimalAdoptantes
               .Where(model => model.Id == Id).ExecuteDeleteAsync();
        }

        public async Task<List<AnimalAdoptante>> GetAllAnimalAdoptanteAsync()
        {
            return await _Context.AnimalAdoptantes.ToListAsync();
        }

        public async Task<AnimalAdoptante> GetAnimalAdoptanteByIdAsync(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("El ID debe ser un valor positivo.", nameof(Id));
            }

            try
            {
                var animalAdoptante = await _Context.AnimalAdoptantes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(v => v.Id == Id);

                if (animalAdoptante is null)
                {
                    throw new KeyNotFoundException($"No se encontró una vacuna con el ID {Id}.");
                }

                return animalAdoptante;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener la vacuna con ID {Id}.", ex);
            }
        }

        public async Task<int> UpdateAnimalAdoptanteAsync(int Id, AnimalAdoptante animalAdoptante)
        {
            return await _Context.AnimalAdoptantes
              .Where(model => model.Id == Id)
              .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.IdAnimal, animalAdoptante.IdAnimal)
                  .SetProperty(m => m.IdAdoptante, animalAdoptante.IdAdoptante)
                  .SetProperty(m => m.AnimalesAdoptados, animalAdoptante.AnimalesAdoptados)
              );
        }
    }
}
