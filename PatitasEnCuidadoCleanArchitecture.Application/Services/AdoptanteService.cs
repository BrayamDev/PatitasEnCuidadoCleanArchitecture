using PatitasEnCuidadoCleanArchitecture.Application.Interface;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Application.Services
{
    public class AdoptanteService : IAdoptanteService
    {
        private readonly IAdoptanteRepository _adoptanteRepository;

        public AdoptanteService(IAdoptanteRepository adoptanteRepository)
        {
            _adoptanteRepository = adoptanteRepository;
        }

        public async Task<Adoptante> CreateAdoptanteAsync(Adoptante adoptante, byte[] contenidoImagen)
        {
            return await _adoptanteRepository.CreateAdoptanteAsync(adoptante, contenidoImagen);
        }

        public async Task<int> DeleteAdoptanteAsync(int Id)
        {
            return await _adoptanteRepository.DeleteAdoptanteAsync(Id);
        }

        public async Task<Adoptante> GetAdoptanteByIdAsync(int Id)
        {
            return await _adoptanteRepository.GetAdoptanteByIdAsync(Id);
        }

        public async Task<List<Adoptante>> GetAllAdoptanteAsync()
        {
            return await _adoptanteRepository.GetAllAdoptanteAsync();
        }

        public async Task<int> UpdateAdoptanteAsync(int Id, Adoptante adoptante, byte[]? contenidoImagen = null)
        {
            return await _adoptanteRepository.UpdateAdoptanteAsync(Id, adoptante, contenidoImagen);
        }
    }
}
