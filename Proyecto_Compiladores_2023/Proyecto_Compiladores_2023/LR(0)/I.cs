using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2023
{
	//Conjunto de elementos I. Guarda un conjunto de producciones que son llamadas elementos
	//In : { [Producción0], [Producción1],..., [ProducciónN] }
	class I
	{
		public int id;
		public List<Produccion> elemento;
		public bool Marcado; //Si esta variable es True, ya se revisaron sus elementos

		public I(List<Produccion> ele)
		{
			this.id = -1;
			Marcado = false;
			elemento = new List<Produccion>();
			copiar_coleccions(ele);
		}

		public I(I coleccion)
		{
			this.id = coleccion.id;
			Marcado = false;
			elemento = new List<Produccion>();
			copiar_coleccions(coleccion.elemento);
		}

		public void copiar_coleccions(List<Produccion> ele)
		{
			foreach (Produccion p in ele)
				elemento.Add(new Produccion(p.NoTerminal, p.cuerpo));
		}

		public string imprimir_coleccion()
		{
			string txt = "{";

			for (int i = 0; i < elemento.Count; i++)
			{
				txt += elemento[i].convertir_a_texto();
				if (i == elemento.Count - 1)
					txt += "}";
				else
					txt += ", ";
			}

			return txt;
		}



	}
}
