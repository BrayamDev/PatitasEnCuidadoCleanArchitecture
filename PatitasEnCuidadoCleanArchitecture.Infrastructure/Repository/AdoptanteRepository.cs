using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    public class AdoptanteRepository : IAdoptanteRepository
    {
        private readonly PatitasEnCuidadoDbContext _context;
        private readonly string _ubicacionImagen;

        public AdoptanteRepository(PatitasEnCuidadoDbContext context, IConfiguration configuration)
        {
            this._context = context;
            _ubicacionImagen = "/ImagenesAdoptantes";
        }

        public async Task<Adoptante> CreateAdoptanteAsync(Adoptante adoptante, byte[] contenidoImagen)
        {
            try
            {
                // Verificar y crear la carpeta si no existe
                if (!Directory.Exists(_ubicacionImagen))
                {
                    Directory.CreateDirectory(_ubicacionImagen);
                }

                // Generar un nombre único para la imagen
                var nombreImagen = $"{Guid.NewGuid()}_{adoptante.NombreAdoptante}.jpg";
                var rutaCompleta = Path.Combine(_ubicacionImagen, nombreImagen);

                // Guardar la imagen en el sistema de archivos
                await File.WriteAllBytesAsync(rutaCompleta, contenidoImagen);

                // Asignar la ruta de la imagen al objeto Adoptante
                adoptante.Imagen = nombreImagen; // Guarda solo el nombre o una ruta relativa

                // Guardar el objeto Adoptante en la base de datos
                await _context.Adoptantes.AddAsync(adoptante);
                await _context.SaveChangesAsync();

                return adoptante;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al guardar el adoptante o la imagen.", ex);
            }
        }

        public async Task<int> DeleteAdoptanteAsync(int Id)
        {
            var adoptante = await _context.Adoptantes.FindAsync(Id);
            if (adoptante == null)
            {
                throw new Exception("El adoptante no existe.");
            }

            // Eliminar la imagen si existe
            if (!string.IsNullOrEmpty(adoptante.Imagen))
            {
                var rutaImagen = Path.Combine(_ubicacionImagen, adoptante.Imagen);
                if (File.Exists(rutaImagen))
                {
                    File.Delete(rutaImagen);
                }
            }

            _context.Adoptantes.Remove(adoptante);
            return await _context.SaveChangesAsync();
        }

        public async Task<Adoptante> GetAdoptanteByIdAsync(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("El ID debe ser un valor positivo.", nameof(Id));
            }

            try
            {
                var adoptante = await _context.Adoptantes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(v => v.Id == Id);

                if (adoptante is null)
                {
                    throw new KeyNotFoundException($"No se encontró una vacuna con el ID {Id}.");
                }

                return adoptante;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener la vacuna con ID {Id}.", ex);
            }
        }

        public async Task<List<Adoptante>> GetAllAdoptanteAsync()
        {
            return await _context.Adoptantes.ToListAsync();
        }

        public async Task<int> UpdateAdoptanteAsync(int Id, Adoptante adoptante, byte[] contenidoImagen)
        {
            // Buscar el adoptante existente por Id
            var adoptanteExistente = await _context.Adoptantes
                .FirstOrDefaultAsync(a => a.Id == Id);

            // Verificación explícita para asegurar que adoptanteExistente no es null
            if (adoptanteExistente == null)
            {
                throw new KeyNotFoundException("El adoptante no existe.");
            }

            // Actualización de los campos del adoptante
            adoptanteExistente.NombreAdoptante = adoptante.NombreAdoptante;
            adoptanteExistente.NumeroDocumento = adoptante.NumeroDocumento;
            adoptanteExistente.NumeroContacto = adoptante.NumeroContacto;
            adoptanteExistente.NumeroEmergencia = adoptante.NumeroEmergencia;
            adoptanteExistente.DireccionResidencia = adoptante.DireccionResidencia;

            // Manejo de la imagen si se proporciona un nuevo contenido de imagen
            if (contenidoImagen != null)
            {
                var nombreImagen = $"{Guid.NewGuid()}_{adoptante.NombreAdoptante}.jpg";
                var rutaCompleta = Path.Combine(_ubicacionImagen, nombreImagen);

                // Guardar la nueva imagen en el sistema de archivos
                await File.WriteAllBytesAsync(rutaCompleta, contenidoImagen);

                // Eliminar la imagen anterior si existe
                if (!string.IsNullOrEmpty(adoptanteExistente.Imagen))
                {
                    var rutaImagenAntigua = Path.Combine(_ubicacionImagen, adoptanteExistente.Imagen);
                    if (File.Exists(rutaImagenAntigua))
                    {
                        File.Delete(rutaImagenAntigua);
                    }
                }

                // Actualizar la ruta de la imagen en el adoptante existente
                adoptanteExistente.Imagen = nombreImagen;
            }

            // Aplicar la actualización en la base de datos
            _context.Adoptantes.Update(adoptanteExistente);
            await _context.SaveChangesAsync();

            // Retornar el ID del adoptante actualizado
            return adoptanteExistente.Id;
        }

    }
}
