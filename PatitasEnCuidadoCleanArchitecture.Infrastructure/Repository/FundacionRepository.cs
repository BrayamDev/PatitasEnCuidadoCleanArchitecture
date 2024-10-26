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
    public class FundacionRepository : IFundacionRepository
    {
        private readonly PatitasEnCuidadoDbContext _Context;

        public FundacionRepository(PatitasEnCuidadoDbContext Context)
        {
            this._Context = Context;
        }

        public async Task<Fundacion> CreateFundacionAsync(Fundacion fundacion)
        {
            await _Context.Fundaciones.AddAsync(fundacion);
            await _Context.SaveChangesAsync();

            return fundacion;
        }

        public async Task<int> DeleteFundacionAsync(int Id)
        {
            return await _Context.Fundaciones
                 .Where(model => model.Id == Id).ExecuteDeleteAsync();
        }

        public async Task<List<Fundacion>> GetAllFundacionAsync()
        {
            return await _Context.Fundaciones.ToListAsync();
        }

        public async Task<Fundacion> GetFundacionByIdAsync(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("El ID debe ser un valor positivo.", nameof(Id));
            }

            try
            {
                var fundacion = await _Context.Fundaciones
                    .AsNoTracking()
                    .FirstOrDefaultAsync(v => v.Id == Id);

                if (fundacion is null)
                {
                    throw new KeyNotFoundException($"No se encontró una fundacion con el ID {Id}.");
                }

                return fundacion;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener la fundacion con ID {Id}.", ex);
            }
        }

        public async Task<int> UpdateFundacionAsync(int Id, Fundacion fundacion)
        {
            return await _Context.Fundaciones
                .Where(model => model.Id == Id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.NombreFundacion, fundacion.NombreFundacion)
                    .SetProperty(m => m.Estado, fundacion.Estado)
                    .SetProperty(m => m.Nit, fundacion.Nit)
                    .SetProperty(m => m.Descripcion, fundacion.Descripcion)
                );
        }

    }
}
