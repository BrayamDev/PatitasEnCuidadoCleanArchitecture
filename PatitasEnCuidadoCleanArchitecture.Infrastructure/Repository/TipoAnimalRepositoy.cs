using Microsoft.EntityFrameworkCore;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Infrastructure.Repository
{
    public class TipoAnimalRepositoy
    {

        private readonly PatitasEnCuidadoDbContext _Context;

        public TipoAnimalRepositoy(PatitasEnCuidadoDbContext Context)
        {
            this._Context = Context;
        }

        public async Task<TipoAnimal> CreateTipoAnimalAsync(TipoAnimal tipoAnimal)
        {
            await _Context.TipoAnimales.AddAsync(tipoAnimal);
            await _Context.SaveChangesAsync();

            return tipoAnimal;
        }

        public async Task<int> DeleteTipoAnimalAsync(int Id)
        {
            return await _Context.TipoAnimales
                 .Where(model => model.Id == Id).ExecuteDeleteAsync();
        }

        public async Task<List<TipoAnimal>> GetAllTipoAnimalAsync()
        {
            return await _Context.TipoAnimales.ToListAsync();
        }

        public async Task<TipoAnimal> GetTipoAnimalById(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("El ID debe ser un valor positivo.", nameof(Id));
            }

            try
            {
                var tipoAnimal = await _Context.TipoAnimales
                    .AsNoTracking()
                    .FirstOrDefaultAsync(v => v.Id == Id);

                if (tipoAnimal is null)
                {
                    throw new KeyNotFoundException($"No se encontró un tipoAnimal con el ID {Id}.");
                }

                return tipoAnimal;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener EL Tipo Animal con ID {Id}.", ex);
            }
        }

        public async Task<int> UpdateVacunaAsync(int Id, TipoAnimal tipoAnimal)
        {
            return await _Context.TipoAnimales
                .Where(model => model.Id == Id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.NombreTipoAnimal, tipoAnimal.NombreTipoAnimal)
                    .SetProperty(m => m.Descripcion, tipoAnimal.Descripcion)
                );
        }

    }
}
