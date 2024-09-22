﻿using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using PatitasEnCuidadoCleanArchitecture.Domain.Interface;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Application.Services
{
    public class VacunaService : IVacunaService
    {

        private readonly IVacunaRepository _vacunaRepository;

        public VacunaService(IVacunaRepository vacunaRepository)
        {
            this._vacunaRepository = vacunaRepository;
        }

        public async Task<Vacuna> CreateVacunaAsync(Vacuna vacuna)
        {
            return await _vacunaRepository.CreateVacunaAsync(vacuna);
        }

        public async Task<int> DeleteVacunaAsync(int Id)
        {
            return await _vacunaRepository.DeleteVacunaAsync(Id);
        }

        public async Task<List<Vacuna>> GetAllVacunasAsync()
        {
            return await _vacunaRepository.GetAllVacunasAsync();
        }

        public async Task<Vacuna> GetVacunasById(int Id)
        {
            return await _vacunaRepository.GetVacunasById(Id);
        }

        public async Task<int> UpdateVacunaAsync(int Id, Vacuna vacuna)
        {
            return await _vacunaRepository.UpdateVacunaAsync(Id, vacuna);
        }
    }
}