using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2023
{
	//Clase para construir un estado del AFD
	class EstadoAFD
	{
		public string Estado { get; set; }  // El estado del AFD
		public bool visitado { get; set; }  // Si el estado ya esta visitado
		public List<TransicionAFD> transiciones { get; set; } // 

		public List<int> l_estados { get; set; } // La lista de estados
		public List<Conjuntos> t_estados { get; set; } // para la tabla de estados
		public bool Soy_Nodo_de_Aceptacion;


		public EstadoAFD(string estado)
		{
			Soy_Nodo_de_Aceptacion = false;
			Estado = estado; // Para el primer estado
			visitado = false; // Para poderlo visitar posteriormente
			transiciones = new List<TransicionAFD>();
			l_estados = new List<int>();
			t_estados = new List<Conjuntos>(); // Iniciamos la lista vacia
		}

		public void llena_tabla(Automata afn, List<char> simbolos)
		{
			foreach (char simbolo in simbolos)
			{
				t_estados.Add(new Conjuntos(simbolo));
			}

			foreach (Conjuntos estado in t_estados)
			{
				foreach (int edo in l_estados)
				{
					TablaEstados conjunto = afn.tabla_estados.Find(x => x.estado == edo);
					Transiciones ta = conjunto.transiciones.Find(x => x.caracter == estado.simbolo);
					if (ta != null)
					{
						estado.conjuntos.Add(ta.siguiente);
					}
				}
			}
		}
	}

}
