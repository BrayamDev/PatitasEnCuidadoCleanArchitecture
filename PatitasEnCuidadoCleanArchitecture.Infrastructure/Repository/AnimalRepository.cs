using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using PatitasEnCuidadoCleanArchitecture.Domain.Interface;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Infrastructure.Repository
{
    public class AnimalRepository : IAnimalRepository
    {

        private readonly PatitasEnCuidadoDbContext _context;
        private readonly string _ubicacionImagen;

        public AnimalRepository(PatitasEnCuidadoDbContext context, IConfiguration configuration)
        {
            this._context = context;
            _ubicacionImagen = "/ImagenesAnimal";
        }

        public async Task<Animal> CreateAnimalAsync(Animal animal, byte[] contenidoImagen = null)
        {
            try
            {
                // Verificar y crear la carpeta si no existe
                if (!Directory.Exists(_ubicacionImagen))
                {
                    Directory.CreateDirectory(_ubicacionImagen);
                }

                // Generar un nombre único para la imagen
                var nombreImagen = $"{Guid.NewGuid()}_{animal.NombreAnimal}.jpg";
                var rutaCompleta = Path.Combine(_ubicacionImagen, nombreImagen);

                // Guardar la imagen en el sistema de archivos
                await File.WriteAllBytesAsync(rutaCompleta, contenidoImagen);

                // Asignar la ruta de la imagen al objeto Adoptante
                animal.UrlImagen = nombreImagen; // Guarda solo el nombre o una ruta relativa

                // Guardar el objeto Adoptante en la base de datos
                await _context.Animales.AddAsync(animal);
                await _context.SaveChangesAsync();

                return animal;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al guardar el adoptante o la imagen.", ex);
            }
        }

        public async Task<int> DeleteAnimalAsync(int Id)
        {
            var animal = await _context.Animales.FindAsync(Id);
            if (animal == null)
            {
                throw new Exception("El animal no existe.");
            }

            // Eliminar la imagen si existe
            if (!string.IsNullOrEmpty(animal.UrlImagen))
            {
                var rutaImagen = Path.Combine(_ubicacionImagen, animal.UrlImagen);
                if (File.Exists(rutaImagen))
                {
                    File.Delete(rutaImagen);
                }
            }

            _context.Animales.Remove(animal);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Animal>> GetAllAnimalAsync()
        {
            return await _context.Animales.ToListAsync();
        }

        public async Task<Animal> GetAnimalByIdAsync(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("El ID debe ser un valor positivo.", nameof(Id));
            }

            try
            {
                var animal = await _context.Animales
                    .AsNoTracking()
                    .FirstOrDefaultAsync(v => v.Id == Id);

                if (animal is null)
                {
                    throw new KeyNotFoundException($"No se encontró una vacuna con el ID {Id}.");
                }

                return animal;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener la vacuna con ID {Id}.", ex);
            }
        }

        public async Task<int> UpdateAnimalAsync(int Id, Animal animal, byte[]? contenidoImagen = null)
        {
            // Buscar el adoptante existente por Id
            var animalExistente = await _context.Animales
                .FirstOrDefaultAsync(a => a.Id == Id);

            // Verificación explícita para asegurar que adoptanteExistente no es null
            if (animalExistente == null)
            {
                throw new KeyNotFoundException("El adoptante no existe.");
            }

            // Actualización de los campos del adoptante
            animalExistente.NombreAnimal = animal.NombreAnimal;
            animalExistente.FechaIngreso = animal.FechaIngreso;
            animalExistente.EstadoSalud = animal.EstadoSalud;
            animalExistente.Observaciones = animal.Observaciones;
            animalExistente.Procedencia = animal.Procedencia;
            animalExistente.Edad = animal.Edad;
            animalExistente.Raza = animal.Raza;
            animalExistente.IdAdoptante = animal.IdAdoptante;
            animalExistente.IdVacunasId = animal.IdVacunasId;
            animalExistente.IdTipoAnimal = animal.IdTipoAnimal;
            animalExistente.IdFundacion = animal.IdFundacion;

            // Manejo de la imagen si se proporciona un nuevo contenido de imagen
            if (contenidoImagen != null)
            {
                var nombreImagen = $"{Guid.NewGuid()}_{animal.NombreAnimal}.jpg";
                var rutaCompleta = Path.Combine(_ubicacionImagen, nombreImagen);

                // Guardar la nueva imagen en el sistema de archivos
                await File.WriteAllBytesAsync(rutaCompleta, contenidoImagen);

                // Eliminar la imagen anterior si existe
                if (!string.IsNullOrEmpty(animalExistente.UrlImagen))
                {
                    var rutaImagenAntigua = Path.Combine(_ubicacionImagen, animalExistente.UrlImagen);
                    if (File.Exists(rutaImagenAntigua))
                    {
                        File.Delete(rutaImagenAntigua);
                    }
                }

                // Actualizar la ruta de la imagen en el adoptante existente
                animalExistente.UrlImagen = nombreImagen;
            }

            // Aplicar la actualización en la base de datos
            _context.Animales.Update(animalExistente);
            await _context.SaveChangesAsync();

            // Retornar el ID del adoptante actualizado
            return animalExistente.Id;
        }
    }
}
