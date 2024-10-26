using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Infrastructure.Interface
{
    public interface IAdoptanteRepository
    {
        Task<List<Adoptante>> GetAllAdoptanteAsync();
        Task<Adoptante> GetAdoptanteByIdAsync(int Id);
        Task<Adoptante> CreateAdoptanteAsync(Adoptante adoptante, byte[] contenidoImagen);
        Task<int> UpdateAdoptanteAsync(int Id, Adoptante adoptante, byte[] contenidoImagen = null);
        Task<int> DeleteAdoptanteAsync(int Id);
    }
}
