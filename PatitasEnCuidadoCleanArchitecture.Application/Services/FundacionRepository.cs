using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using PatitasEnCuidadoCleanArchitecture.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Application.Services
{
    public class FundacionRepository : IFundacionRepository
    {

        private readonly IFundacionRepository _fundacionRepository;

        public FundacionRepository(IFundacionRepository fundacionRepository)
        {
            this._fundacionRepository = fundacionRepository;
        }

        public async Task<Fundacion> CreateFundacionAsync(Fundacion fundacion)
        {
            return await _fundacionRepository.CreateFundacionAsync(fundacion);
        }

        public async Task<int> DeleteFundacionAsync(int Id)
        {
            return await _fundacionRepository.DeleteFundacionAsync(Id);
        }

        public async Task<List<Fundacion>> GetAllFundacionAsync()
        {
            return await _fundacionRepository.GetAllFundacionAsync();
        }

        public async Task<Fundacion> GetFundacionByIdAsync(int Id)
        {
            return await _fundacionRepository.GetFundacionByIdAsync(Id);
        }

        public async Task<int> UpdateFundacionAsync(int Id, Fundacion fundacion)
        {
            return await _fundacionRepository.UpdateFundacionAsync(Id, fundacion);
        }

    }
}
