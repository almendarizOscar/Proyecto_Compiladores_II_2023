using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2023
{
	class TransicionAFD
	{
		//Clase para las transiciones de un AFD
		public char simbolo;  // Simbolo que identificara la transicion
		public EstadoAFD estado_siguiente; //Estado siguiente al que apunta

		//Para crear una transición es necesario saber su símbolo y el estado siguiente
		public TransicionAFD(char simbolo, EstadoAFD siguiente)
		{
			this.simbolo = simbolo;
			this.estado_siguiente = siguiente;
		}
	}
}
