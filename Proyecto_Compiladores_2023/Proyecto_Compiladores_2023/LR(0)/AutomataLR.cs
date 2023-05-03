using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2023
{
	class AutomataLR
	{
		public List<EstadoLR> estado; //Conjunto de sus estados
		public List<TransicionLR> transiciones;

		public AutomataLR()
		{
			estado = new List<EstadoLR>();
			transiciones = new List<TransicionLR>();
		}

	}
}
