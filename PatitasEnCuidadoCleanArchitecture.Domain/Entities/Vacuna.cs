using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Domain.Entities
{
    public class Vacuna
    {
        public int Id { get; set; }
        public string NombreVacuna { get; set; }
        public DateTime FechaCaducidad { get; set; }
    }
}
