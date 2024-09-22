using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Domain.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string NombreAnimal { get; set; }
        public string UrlImagen { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string EstadoSalud { get; set; }
        public string Observaciones { get; set; }
        public string Procedencia { get; set; }
        public int Edad { get; set; }
        public string Raza { get; set; }

        /*Claves Foraneas*/
        public int IdAdoptante { get; set; }
        public int IdVacunasId { get; set; }
        public int IdTipoAnimal{ get; set; }
        public int IdFundacion { get; set; }

    }
}
