using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Domain.DbEntities
{
    public class Actor
    {
        public string Nombre { get; private set; }
        public string Raza { get; private set; }
        public string Sexo { get; private set; }

        public Actor(string nombre, string raza, string sexo)
        {
            this.Nombre = nombre;
            this.Raza = raza;
            this.Sexo = sexo;
        }
    }
}
