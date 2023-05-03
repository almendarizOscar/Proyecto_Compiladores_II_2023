using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2023
{
	class EstadoLR
	{
		public int id; //Identificador del estado
		public I coleccion; //Coleccion que el estado representa	
		public List<TransicionLR> transicion; //Lista de transiciones

		//Un EstadoLR se puede crear a partir de un identificador y una coleccion I.
		public EstadoLR(int id, I coleccion)
		{
			this.id = id;
			transicion = new List<TransicionLR>();
			this.coleccion = new I(coleccion);
		}


	}
}
