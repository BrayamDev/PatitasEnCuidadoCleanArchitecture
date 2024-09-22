using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Domain.Entities
{
    public class Fundacion
    {
        public int Id { get; set; }
        public string NombreFundacion { get; set; }
        public bool Estado { get; set; }
        public string Nit { get; set; }
        public string Descripcion { get; set; }
    }
}
