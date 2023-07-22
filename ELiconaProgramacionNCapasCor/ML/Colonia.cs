﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Colonia
    {
        public int IdColonia { get; set; }
        public string NombreColonia { get; set; }
        public string CodigoPostal { get; set; }
        public int IdMunicipio { get; set; }

        public ML.Municipio Municipio { get; set; }
        public ML.Colonia Colo { get; set; }

        public List<object> Colonias { get; set; }
    }
}