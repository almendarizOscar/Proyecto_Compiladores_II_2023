using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2023
{
	//Clase para definir una producucción de la gramáica
	//Estructura: No terminal --> {Simbolo1 Símbolo2 ... Símbolon}
	class Produccion
	{
		public string NoTerminal; //Cabecera de la producción
		public List<string> cuerpo; //Cuerpo de laproducción (Conjunto de símbolos)

		//Podemos crear una producción con el Simbolo No terminal y su lista de símbolos
		public Produccion(string NoTerminal, List<string> c)
		{
			this.NoTerminal = NoTerminal;
			this.cuerpo = new List<string>();
			foreach (string simbolo in c)
				this.cuerpo.Add(simbolo);
		}
		//Este metodo nos sirve para convertir a texto una producción
		public string convertir_a_texto()
		{
			string txt = "[" + NoTerminal + " -> ";
			for (int i = 0; i < cuerpo.Count; i++)
			{

				txt += cuerpo[i] + " ";
				if (i == cuerpo.Count - 1)
					txt += "]";
				else
					txt += " ";
			}
			return txt;
		}

	}
}
