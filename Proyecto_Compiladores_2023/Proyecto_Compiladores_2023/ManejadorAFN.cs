using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Compiladores_2023
{
	//Esta clase estática es la encargada de manejar el autómata y llenar la tabla de transiciones
	class ManejadorAFN
	{
		public DataGridView tabla_de_transiciones;
		public int contador;
		//Algoritmo para la construcción de un AFN
		//La expresión regular ya está en formato postfija
		public Automata construir_AFN(string expresíon_regular)
		{
			Stack<Automata> pila = new Stack<Automata>(); //Pila de autómatas
			string postfija = expresíon_regular;
			char caracter;

			//Recorremos la expresión regular caracter por caracter

			for (int i = 0; i < postfija.Length; i++)
			{
				Automata automata1, automata2;
				caracter = postfija[i];
				switch (caracter)
				{
					//Si el caracter es cualquiera de los operadores siguientes
					case '*':
						automata1 = pila.Pop();
						pila.Push(new Automata('*', automata1)); //Creamos un nuevo autómata
						break;
					case '+':
						automata1 = pila.Pop();
						pila.Push(new Automata('+', automata1)); //Creamos un nuevo autómata
						break;
					case '?':
						automata1 = pila.Pop();
						pila.Push(new Automata('?', automata1)); //Creamos un nuevo autómata
						break;
					case '&':
						//Se extraen dos autómatas de la pila.
						automata2 = pila.Pop();
						automata1 = pila.Pop();
						pila.Push(new Automata('&', automata1, automata2)); //Creamos un nuevo autómata
						break;
					case '|':
						//Se extraen dos autómatas de la pila.
						automata2 = pila.Pop();
						automata1 = pila.Pop();
						pila.Push(new Automata('|', automata1, automata2)); //Creamos un nuevo autómata
						break;

					default: //Caso para cuando es un OPERANDO
						Automata automata = new Automata(caracter);//Creamos el automata de este operando
						pila.Push(automata); //Insertamos el autómata en la pila
						break;
				}
			}
			return pila.Pop(); //Regresamos el último autómata que queda en la pila
		}

		//Método para volver a poner los estados como no visitados. Se realiza un recorrido en profundidad
		public void poner_visitados_en_falso(Estado estado)
		{
			estado.visitado = false; //Se marca de nuevo como no visitado
			foreach (Transicion transicion in estado.transicion) //Se recorren todas las transiciones
			{
				if (transicion.estado_siguiente.visitado == true)
					poner_visitados_en_falso(transicion.estado_siguiente);
			}
		}

		//Antes de usar este metodo, la variable 'contador' se debe de inicializar en 0.
		//El recorrido es en profundidad
		public void enumerar_estados(Estado estado)
		{
			estado.visitado = true; //Primero el estado se marca como visitado
			estado.id = contador;
			contador += 1;

			foreach (Transicion transicion in estado.transicion)
			{

				if (transicion.estado_siguiente.visitado == false)
				{
					enumerar_estados(transicion.estado_siguiente);
				}
			}
		}

		//El método evalua que exista una transición en el estado con este símbolo
		//Se devuelve el ID del estado al que apunta
		private List<int> existe_esta_transicion(char simbolo, List<Transicion> trans)
		{
			List<int> estados = new List<int>();
			foreach (Transicion t in trans) //Se recorren las transiciones
			{
				if (t.simbolo == simbolo)
					estados.Add(t.estado_siguiente.id);
			}
			estados.Sort();
			return estados; //indica que no hay transiciones con ese símbolo
		}
		private string convertir_a_conjunto(List<int> estados)
		{
			string cadena = "{";
			for (int i = 0; i < estados.Count; i++)
			{
				cadena += estados[i];
				if (i < estados.Count - 1)
					cadena += ", ";
			}
			cadena += "}";
			return cadena;

		}
		//Método para llenar la tabal de transiciones
		//Se necesita el automata y el lenguaje que admite
		public void insetar_fila_en_la_tabla_transiciones(Automata automata, List<char> lenguaje)
		{
			//El primer recorrido de manera vertical hacia abajo, revisando estado por estado (Los estados ya estan ordenados)
			for (int i = 0; i < automata.estado.Count; i++)
			{
				//Agregamos primero la fila
				TablaEstados tabla_edo = new TablaEstados(i);
				tabla_de_transiciones.Rows.Add();
				tabla_de_transiciones.Rows[i].Cells[0].Value = automata.estado[i].id;
				//El segundo recorrido será de manera horizontal hacia la derecha. 
				//Nos moveremos segun la cantidad de síimbolo que haya en el alfabeto
				int j = 1;
				foreach (char simbolo in lenguaje)
				{
					//Ahora revisamos todas las transiciones para ver cual tiene ese caracter
					List<int> transicion_con_el_simbolos = existe_esta_transicion(simbolo, automata.estado[i].transicion);
					if (transicion_con_el_simbolos.Count == 0)
						tabla_de_transiciones.Rows[i].Cells[j].Value = 'Ø';
					else
					{
						string conjunto = convertir_a_conjunto(transicion_con_el_simbolos);
						tabla_de_transiciones.Rows[i].Cells[j].Value = conjunto;
						tabla_edo.agrega_destino(simbolo, conjunto);  // Se pude colocar el condicional para omitir los ε, ya que esto solo se usara para consultar los estados del AFD
					}
					j += 1;
				}
				automata.tabla_estados.Add(tabla_edo);
			}
		}

		public void Llena_TablaEstados(Automata automata, List<char> lenguaje)
		{
			//El primer recorrido de manera vertical hacia abajo, revisando estado por estado (Los estados ya estan ordenados)
			for (int i = 0; i < automata.estado.Count; i++)
			{
				//Agregamos primero la fila
				TablaEstados tabla_edo = new TablaEstados(i);
				//El segundo recorrido será de manera horizontal hacia la derecha. 
				//Nos moveremos segun la cantidad de síimbolo que haya en el alfabeto
				int j = 1;
				foreach (char simbolo in lenguaje)
				{
					//Ahora revisamos todas las transiciones para ver cual tiene ese caracter
					List<int> transicion_con_el_simbolos = existe_esta_transicion(simbolo, automata.estado[i].transicion);
					if (transicion_con_el_simbolos.Count == 0)
					{

					}
					else
					{
						string conjunto = convertir_a_conjunto(transicion_con_el_simbolos);
						tabla_edo.agrega_destino(simbolo, conjunto);  // Se pude colocar el condicional para omitir los ε, ya que esto solo se usara para consultar los estados del AFD
					}
					j += 1;
				}
				automata.tabla_estados.Add(tabla_edo);
			}
		}

		//Este metodo regresa verdadero si el caracter que le pasamos como parámetro se encuentra en el alfabeto
		public bool caracter_esta_en_el_alfabeto(char caracter, List<char> alfabeto)
		{
			foreach (char c in alfabeto)
			{
				if (caracter == c) return true;
			}
			return false;
		}

		public List<char> obtener_alfabeto(string postfija)
		{
			List<char> alfabeto = new List<char>();
			char caracter;
			//Extraer de postfija solo los caracteres que no se repiten
			for (int i = 0; i < postfija.Length; i++)
			{
				caracter = postfija[i];
				if (!caracter_esta_en_el_alfabeto(caracter, alfabeto)
					&& caracter != '*' && caracter != '?' && caracter != '+'
					&& caracter != '&' && caracter != '|')
				{
					alfabeto.Add(caracter); //Añadimos el caracter al alfabeto
				}
			}
			alfabeto.Add('ε');
			return alfabeto;
		}
	}

	class TablaEstados
	{
		public int estado { get; set; }
		public List<Transiciones> transiciones { get; set; }

		public TablaEstados(int edo)
		{
			estado = edo;
			transiciones = new List<Transiciones>();
		}

		public void agrega_destino(char caracter, string destino)
		{
			transiciones.Add(new Transiciones(caracter, destino));
		}
	}

	class Transiciones
	{
		public char caracter { get; set; }
		public string siguiente { get; set; }

		public Transiciones(char simbolo, string destino)
		{
			caracter = simbolo;
			siguiente = destino;
		}
	}

}
