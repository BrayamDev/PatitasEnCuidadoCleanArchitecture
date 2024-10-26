using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Infrastructure.Interface
{
    public interface IFundacionRepository
    {
        Task<List<Fundacion>> GetAllFundacionAsync();
        Task<Fundacion> GetFundacionByIdAsync(int Id);
        Task<Fundacion> CreateFundacionAsync(Fundacion fundacion);
        Task<int> UpdateFundacionAsync(int Id, Fundacion fundacion);
        Task<int> DeleteFundacionAsync(int Id);
    }
}
