using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Domain.DbEntities
{
    public class Genero
    {
        public string Nombre { get; private set; }
        public Genero(string nombre)
        {
                Nombre = nombre;
        }
    }
}
