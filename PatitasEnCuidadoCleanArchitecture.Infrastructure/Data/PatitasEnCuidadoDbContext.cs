using Microsoft.EntityFrameworkCore;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Infrastructure.Data
{
    public class PatitasEnCuidadoDbContext : DbContext
    {
        public PatitasEnCuidadoDbContext(DbContextOptions<PatitasEnCuidadoDbContext> options) : base(options)
        {
        }

        public DbSet<Vacuna> Vacunas { get; set; }
        public DbSet<Adoptante> Adoptantes { get; set; }
        public DbSet<Animal> Animales { get; set; }
        public DbSet<AnimalAdoptante> AnimalAdoptantes { get; set; }
        public DbSet<AnimalFundacion> AnimalFundaciones { get; set; }
        public DbSet<Fundacion> Fundaciones { get; set; }
        public DbSet<TipoAnimal> TipoAnimales { get; set; }
    }
}
