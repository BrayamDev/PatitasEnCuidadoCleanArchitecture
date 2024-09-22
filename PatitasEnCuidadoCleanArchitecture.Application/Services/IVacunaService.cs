using PatitasEnCuidadoCleanArchitecture.Domain.Entities;

namespace PatitasEnCuidadoCleanArchitecture.Application.Services
{
    public interface IVacunaService
    {
        Task<List<Vacuna>> GetAllVacunasAsync();
        Task<Vacuna> GetVacunasById(int Id);
        Task<Vacuna> CreateVacunaAsync(Vacuna vacuna);
        Task<int> UpdateVacunaAsync(int Id, Vacuna vacuna);
        Task<int> DeleteVacunaAsync(int Id);

    }
}