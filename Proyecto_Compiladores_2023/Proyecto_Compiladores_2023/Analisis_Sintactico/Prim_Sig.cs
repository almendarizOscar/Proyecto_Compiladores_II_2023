using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2023.Analisis_Sintactico
{
    internal class Primeros
    {
        public string identificador; 
        public List<string> conjunto;

        public Primeros(string identificador, List<string> conjunto)
        {
            this.identificador = identificador;
            this.conjunto = conjunto;
        }
    }

    internal class Siguientes
    {
        public string identificador;
        public List<string> conjunto;

        public Siguientes(string identificador, List<string> conjunto)
        {
            this.identificador = identificador;
            this.conjunto = conjunto;
        }
    }
}
