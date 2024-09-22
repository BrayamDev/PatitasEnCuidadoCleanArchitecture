using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasEnCuidadoCleanArchitecture.Domain.Entities
{
    public class AnimalAdoptante
    {
        public int Id { get; set; }
        public int IdAdoptante { get; set; }
        public int IdAnimal { get; set; }
        public int AnimalesAdoptados { get; set; }
    }
}
