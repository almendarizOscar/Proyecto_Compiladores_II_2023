using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2023
{
	class Conjuntos
	{
		//Estructura de un conjunto
		public char simbolo { get; set; } //Símbolo de un conjunto
		public List<int> l_estados { get; set; } //Lista de enteros 
		public List<string> conjuntos { get; set; } //Lista de cadenas

		public Conjuntos()
		{
			this.simbolo = ' ';
			this.conjuntos = new List<string>();
			this.l_estados = new List<int>();
		}

		public Conjuntos(char sim)
		{
			this.simbolo = sim;
			this.conjuntos = new List<string>();
			this.l_estados = new List<int>();
		}

	}
}
