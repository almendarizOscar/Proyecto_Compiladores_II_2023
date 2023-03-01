using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2023
{
	class Transicion
	{
		public char simbolo; //Simbolo que identifica la transición
		public Estado estado_siguiente; //Estado siguiente al que apunta


		//Para crear una transición se necesita saber el simbolo que describe esta transición
		//y el estado siguiente al que apunta
		public Transicion(char simbolo, Estado estado_siguiente)
		{
			this.simbolo = simbolo;
			this.estado_siguiente = estado_siguiente;
		}
	}
}
