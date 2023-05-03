using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2023
{
	
	class TransicionLR
	{

		public string simbolo;  // Simbolo que identificara la transicion
		public EstadoLR estado_siguiente; //Estado siguiente al que apunta
		public EstadoLR estado_inicio;
		//Para crear una transición es necesario saber su símbolo y el estado siguiente
		public TransicionLR(EstadoLR estado_inicio, string simbolo, EstadoLR estado_siguiente)
		{
			this.simbolo = simbolo;
			this.estado_siguiente = estado_siguiente;
			this.estado_inicio = estado_inicio;
		}
	}
}
