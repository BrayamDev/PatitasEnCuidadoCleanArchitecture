using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Domain.Interface
{
    public interface IVacunaRepository
    {
        Task<List<Vacuna>> GetAllVacunasAsync();
        Task<Vacuna> GetVacunasById(int Id);
        Task<Vacuna> CreateVacunaAsync(Vacuna vacuna);
        Task<int> UpdateVacunaAsync(int Id, Vacuna vacuna);
        Task<int> DeleteVacunaAsync(int Id);
    }
}
