using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Domain.Entities
{
    public class Adoptante
    {
        public int Id { get; set; }
        public string NombreAdoptante { get; set; }
        public string NumeroDocumento { get; set; }
        public string NumeroContacto { get; set; }
        public string NumeroEmergencia { get; set; }
        public string Imagen { get; set; }
        public string DireccionResidencia { get; set; }
    }
}
