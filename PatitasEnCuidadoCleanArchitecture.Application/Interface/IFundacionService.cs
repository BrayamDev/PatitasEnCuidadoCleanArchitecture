using PatitasEnCuidadoCleanArchitecture.Domain.Entities;

namespace PatitasEnCuidadoCleanArchitecture.Application.Interface
{
    public interface IFundacionService
    {
        Task<List<Fundacion>> GetAllFundacionAsync();
        Task<Fundacion> GetFundacionByIdAsync(int Id);
        Task<Fundacion> CreateFundacionAsync(Fundacion fundacion);
        Task<int> UpdateFundacionAsync(int Id, Fundacion fundacion);
        Task<int> DeleteFundacionAsync(int Id);

    }
}
