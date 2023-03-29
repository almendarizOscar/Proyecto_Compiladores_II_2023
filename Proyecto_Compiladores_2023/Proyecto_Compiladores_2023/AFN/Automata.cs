using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2023
{
	class Automata
	{
		public Estado estado_de_inicio; //Estado de inicio
		public Estado estado_aceptacion; //Estado final
		public List<Estado> estado; //Lista de estados que componene el automata
		public List<TablaEstados> tabla_estados { get; set; } = new List<TablaEstados>(); // Aqui se guardan la tabla de estados del AFN

		//Autómata base para un solo símbolo
		public Automata(char simbolo)
		{
			//Creamos el estado inicial y final
			estado_de_inicio = new Estado();
			estado_aceptacion = new Estado();

			//Creamos la transición base
			estado_de_inicio.crearTransicionHacia(simbolo, estado_aceptacion);
			estado = new List<Estado>(); //Se crea la lista de estados y se añaden estos dos estados nuevos
			estado.Add(estado_de_inicio);
			estado.Add(estado_aceptacion);
			//  (inicio) ----- simbolos -----> (aceptación)
		}

		//Crear un automata para un operadore unitario
		public Automata(char operador, Automata a)
		{
			//Creamos el estado inicial y final
			estado_de_inicio = new Estado();
			estado_aceptacion = new Estado();

			switch (operador) //Evaluamos el operador
			{
				case '*': //Cerradura de kleene
					estado_de_inicio.crearTransicionHacia('ε', a.estado_de_inicio);
					a.estado_aceptacion.crearTransicionHacia('ε', estado_aceptacion);
					a.estado_aceptacion.crearTransicionHacia('ε', a.estado_de_inicio);
					estado_de_inicio.crearTransicionHacia('ε', estado_aceptacion);
					break;

				case '?': //Cero o una instancia}
					estado_de_inicio.crearTransicionHacia('ε', a.estado_de_inicio);
					a.estado_aceptacion.crearTransicionHacia('ε', estado_aceptacion);
					estado_de_inicio.crearTransicionHacia('ε', estado_aceptacion);
					break;

				case '+': //Cerradura positiva
					estado_de_inicio.crearTransicionHacia('ε', a.estado_de_inicio);
					a.estado_aceptacion.crearTransicionHacia('ε', estado_aceptacion);
					a.estado_aceptacion.crearTransicionHacia('ε', a.estado_de_inicio);
					break;
			}

			estado = a.estado; //La lista del automata que se acopló ahora es parte de la lista
			estado.Add(estado_de_inicio);
			estado.Add(estado_aceptacion);
		}
		//Acoplar el automata a1 --> a2
		private void acoplar(Automata a1, Automata a2)
		{
			foreach (Estado nodo in a1.estado)
			{
				foreach (Transicion transicion in nodo.transicion)
				{
					if (transicion.estado_siguiente == a1.estado_aceptacion)
					{
						transicion.estado_siguiente = a2.estado_de_inicio;

					}
				}
			}
			a1.estado.Remove(a1.estado_aceptacion);
		}
		//Crear un automata para operadores binarios
		public Automata(char operador, Automata a1, Automata a2)
		{
			estado = new List<Estado>();
			switch (operador) //Evaluamos el operador binario
			{
				case '&': //Concatenación

					acoplar(a1, a2);
					a1.estado_aceptacion = a2.estado_de_inicio; //El estado de aceptacion del primer autómata, ahora es el estado inicial del segundo

					estado = a1.estado;
					estado.AddRange(a2.estado);


					estado_de_inicio = a1.estado_de_inicio;
					estado_aceptacion = a2.estado_aceptacion;

					break;

				case '|': //Selección de alternativas
					estado_de_inicio = new Estado();
					estado_aceptacion = new Estado();

					estado_de_inicio.crearTransicionHacia('ε', a1.estado_de_inicio);
					estado_de_inicio.crearTransicionHacia('ε', a2.estado_de_inicio);

					a1.estado_aceptacion.crearTransicionHacia('ε', estado_aceptacion);
					a2.estado_aceptacion.crearTransicionHacia('ε', estado_aceptacion);

					//Sumamos los estados que se acoplarán 
					estado.AddRange(a1.estado);
					estado.AddRange(a2.estado);
					//Agregamos los estados nuevos
					estado.Add(estado_de_inicio);
					estado.Add(estado_aceptacion);
					break;
			}

		}

		public int numero_de_transiciones_epsilon()
		{
			int contador = 0;
			foreach (Estado nodo in estado) //Recorremos los estados
			{
				foreach (Transicion transicion in nodo.transicion)
				{
					if (transicion.simbolo == 'ε')
						contador += 1;
				}
			}
			return contador;
		}
	}
}
