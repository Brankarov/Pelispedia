using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Domain.DbEntities
{
    public class Director
    {
        //public int IdDirector {  get; private set; 
        public string Nombre { get; private set; }
        public Director(string nombreDirector)
        {
            Nombre = nombreDirector;
        }
    }
}
