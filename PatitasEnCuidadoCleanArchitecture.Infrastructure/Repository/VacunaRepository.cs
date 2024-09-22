using Microsoft.EntityFrameworkCore;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using PatitasEnCuidadoCleanArchitecture.Domain.Interface;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Infrastructure.Repository
{
    public class VacunaRepository : IVacunaRepository
    {
        private readonly PatitasEnCuidadoDbContext _Context;

        public VacunaRepository(PatitasEnCuidadoDbContext Context)
        {
            this._Context = Context;
        }

        public async Task<Vacuna> CreateVacunaAsync(Vacuna vacuna)
        {
            await _Context.Vacunas.AddAsync(vacuna);
            await _Context.SaveChangesAsync();

            return vacuna;
        }

        public async Task<int> DeleteVacunaAsync(int Id)
        {
           return await _Context.Vacunas
                .Where(model => model.Id == Id).ExecuteDeleteAsync();
        }

        public async Task<List<Vacuna>> GetAllVacunasAsync()
        {
           return await _Context.Vacunas.ToListAsync();
        }


        public async Task<Vacuna> GetVacunasById(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("El ID debe ser un valor positivo.", nameof(Id));
            }

            try
            {
                var vacuna = await _Context.Vacunas
                    .AsNoTracking()
                    .FirstOrDefaultAsync(v => v.Id == Id);

                if (vacuna is null)
                {
                    throw new KeyNotFoundException($"No se encontró una vacuna con el ID {Id}.");
                }

                return vacuna;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener la vacuna con ID {Id}.", ex);
            }
        }

        public async Task<int> UpdateVacunaAsync(int Id, Vacuna vacuna)
        {
            return await _Context.Vacunas
                .Where(model => model.Id == Id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.NombreVacuna, vacuna.NombreVacuna)
                    .SetProperty(m => m.FechaCaducidad, vacuna.FechaCaducidad)
                );
        }
    }
}
