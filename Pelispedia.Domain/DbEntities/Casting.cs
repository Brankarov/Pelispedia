﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Domain.DbEntities
{
    public class Casting
    {
        public int IdCasting { get; set; }
        public int IdPelicula { get; set; }
        public int IdActor { get; set; }
        
    }
}
