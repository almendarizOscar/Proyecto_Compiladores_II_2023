using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2023
{
	class Estado
	{
		public int id; //Número que identifica al estado
		public List<Transicion> transicion; //Lista de transiciones hacia otros estados
		public bool visitado; //Indica si el nodo ya ha sido visitado anteriormente

		public Estado()
		{
			id = -1; //Al inicio, el ID del estado es -1
			visitado = false;
			transicion = new List<Transicion>(); //La lista de transiciones está vacía
		}

		//Con este método podemos crear transiciones que apunten hacia otro estado
		//Solo es necesario conocer el símbolo de la transición y el estado al que apunta.
		public void crearTransicionHacia(char simbolo, Estado estado_destino)
		{
			Transicion nueva_transicion = new Transicion(simbolo, estado_destino);
			transicion.Add(nueva_transicion); //Se guarda la transición
		}
	}
}
