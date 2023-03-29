using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Compiladores_2023
{
	//Autómata Finito Determinista
	class AFD
	{
		bool totalmenteVisitado = false;
		List<char> alfabeto; //Alfabeto
		public List<EstadoAFD> Destados; //Lista de estados del AFD

		Automata AFN; //Autómata Finito No Determinista
					  //Lista de nombreas para los estados del AFD
		String[] Estados = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J","K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
							 "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ","AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ"};

		public string estados_de_aceptacion;
		public string lexema;
		public int i_Lexema;

		public AFD(Automata afn, List<char> simbolos)
		{
			this.Destados = new List<EstadoAFD>();
			this.alfabeto = new List<char>();
			this.AFN = afn;
			//Obtener el alfabeto sin el símbolo de ε
			foreach (char simbolo in simbolos)
			{
				if (simbolo != 'ε')
					alfabeto.Add(simbolo);
			}
		}

		//Generar el AFD a partir del estado inicial del AFN
		public void GeneraAFD(Estado inicial)
		{
			EstadoAFD T;
			EstadoAFD inicio = new EstadoAFD("A");
			List<int> edos_mover;
			EstadoAFD similar;

			inicio.l_estados = estados_epsilon(inicial);
			inicio.l_estados.Add(inicial.id);
			inicio.l_estados.Sort();

			Destados.Add(inicio);

			T = obtenEstadoSinVisitar();
			while (!totalmenteVisitado)
			{

				if (T != null)
				{
					T.visitado = true;
					T.llena_tabla(AFN, alfabeto);

					foreach (char a in alfabeto)
					{
						edos_mover = mover(T, a); // Obtengo la lista de estados de la accion mover
						similar = buscaEstadoSimilar(edos_mover); // Busco si la lista de estados es igual a uno ya creado
						if (similar == null && edos_mover.Count > 0) // Generar nuevo estadoo
						{
							EstadoAFD nuevo = new EstadoAFD(Estados[Destados.Count]);
							nuevo.l_estados = edos_mover;
							T.transiciones.Add(new TransicionAFD(a, nuevo));
							Destados.Add(nuevo);
						}
						else if (similar != null && edos_mover.Count > 0) // Encontre un estado similar solo le agrego la transicion
						{
							T.transiciones.Add(new TransicionAFD(a, similar));
						}
					}
				}

				T = obtenEstadoSinVisitar();
				totalmenteVisitado = T == null;
			}
		}

		private EstadoAFD buscaEstadoSimilar(List<int> edos)
		{
			bool similar;
			foreach (EstadoAFD estado_afd in Destados)
			{
				if (estado_afd.l_estados.Count == edos.Count)
				{
					similar = true;
					for (int i = 0; i < edos.Count; i++)
					{
						if (estado_afd.l_estados[i] != edos[i])
						{
							similar = false;
						}
					}
					if (similar == true)
					{
						return estado_afd;
					}
				}

			}
			return null;
		}

		public void llenaTabla(DataGridView tablaAFD)
		{
			// 1.- Limpiamos la tabla donde se mostraran los estados del AFD
			tablaAFD.Rows.Clear();
			tablaAFD.Columns.Clear();

			// 2.- Colocar las columnas en la tabla
			poner_columnas_afd(tablaAFD);

			// 3.- Agregar estados del AFD
			agregar_estados_tabla(tablaAFD);
		}

		//Método que pone los encabezados a las columnas en la tabla de transiciones
		private void poner_columnas_afd(DataGridView tablaAFD)
		{
			//Insertar las columnas
			tablaAFD.Columns.Add("Estados", "Estados");
			for (int i = 0; i < alfabeto.Count; i++)
			{
				tablaAFD.Columns.Add("Columna" + i, alfabeto[i].ToString());
			}

		}

		private void agregar_estados_tabla(DataGridView tablaAFD)
		{
			int i = 0;
			foreach (EstadoAFD estado in Destados)
			{
				int j = 0;
				tablaAFD.Rows.Add();
				tablaAFD.Rows[i].Cells[j].Value = estado.Estado;

				foreach (char caracter in alfabeto)
				{
					j++;
					TransicionAFD tr_sig = estado.transiciones.Find(x => x.simbolo == caracter);
					if (tr_sig != null)
					{
						tablaAFD.Rows[i].Cells[j].Value = tr_sig.estado_siguiente.Estado;
					}
				}
				i++;
			}
		}

		private EstadoAFD obtenEstadoSinVisitar()
		{
			foreach (EstadoAFD estado in Destados)
			{
				if (!estado.visitado)
					return estado;
			}
			return null;
		}

		public List<int> mover(EstadoAFD T, char a)
		{
			int estado;
			Estado edo;
			List<int> estados = new List<int>();
			List<string> conjuntos = T.t_estados.Find(x => x.simbolo == a).conjuntos;

			foreach (string conjunto in conjuntos)
			{
				estado = eliminaLlaves(conjunto);
				edo = AFN.estado.Find(x => x.id == estado);
				estados.Add(estado);
				List<int> nuevos_estados = estados_epsilon(edo);
				mezcla_nuevos_estados(estados, nuevos_estados);
				estados.Sort();
			}

			return estados;
		}

		private void mezcla_nuevos_estados(List<int> estados, List<int> nuevos_estados)
		{
			foreach (var estado in nuevos_estados)
			{
				if (estados.FindIndex(x => x == estado) < 0)
				{
					estados.Add(estado);
				}
			}
		}

		private int eliminaLlaves(string conjunto)
		{
			return int.Parse(conjunto.Replace("{", "").Replace("}", ""));
		}

		public List<int> estados_epsilon(Estado nodo)
		{
			List<int> estados = new List<int>();

			foreach (Transicion transicion in nodo.transicion)
			{
				if (transicion.simbolo == 'ε')
				{
					if (estados.FindIndex(x => x == transicion.estado_siguiente.id) < 0)
					{
						estados.Add(transicion.estado_siguiente.id);
						estados.AddRange(estados_epsilon(transicion.estado_siguiente));
					}
				}
			}

			return estados;
		}

		public void encontrar_nodos_de_aceptacion(Estado estado_Aceptacion_afn)
		{
			estados_de_aceptacion = "";
			foreach (EstadoAFD e in Destados)
			{
				foreach (int e_afn in e.l_estados)
				{
					if (e_afn == estado_Aceptacion_afn.id)
					{
						e.Soy_Nodo_de_Aceptacion = true;
						estados_de_aceptacion += e.Estado;
						break;
					}
				}
			}
		}

		

		
		//En esta sección está el procedimiento para validar un lexema con el AFD
		#region Analizador de lexema
		public bool validar_Lexema(string lexema)
		{
			//lexema es una variable global
			this.lexema = lexema;
			//i_lexema es la variable que guarda el índice cuando se recorre el lexema en el algoritmo bpf
			i_Lexema = 0;
			//Primero marcar los nodos del AFD como no visitados
			poner_visitados_falso();
			return bpf(Destados[0], Destados[0]);
		}
		//Función para poner todos los estados del grafo en falso antes de hacer cualquier recorrido
		public void poner_visitados_falso()
		{
			foreach (EstadoAFD e in Destados)
				e.visitado = false;
		}

		/*
		  Algoritmo de busqueda en profundidad 
		  Este algoritmo es recursivo, y hay que pasarle como parametro un estado anterior y un estado siguiente.

		  El método utiliza el lexema, que es una variable global para esta clase.
		*/
		public bool bpf(EstadoAFD anterior, EstadoAFD estado)
		{
			//Caso base
			//Si i_lexema es igual al tamaño del lexema quiere decir que ya llego al final del recorrido del lexema
			//Si se llego al final del lexema verificamos si el estado en donde estamos es un estado de aceptación.
			//De ser esto cierto quiere decir que el lexema es correcto.
			if ((i_Lexema == lexema.Length) &&
				(estado.Soy_Nodo_de_Aceptacion))
				return true;
			//Caso recursivo
			//Si el indice del lexema es menor que el tamaño del lexema quiere decir que aun no llegamos al final
			if (i_Lexema < lexema.Length)
			{
				//Hacemos un recorrido de cada una de las transiciones del estado en donde estamos
				foreach (TransicionAFD t in estado.transiciones)
				{
					//Si el simbolo de la transición es igual al simbolo del lexema en donde vamos, entonces usamos 
					//esa transición para llegar al otro estado
					if (t.simbolo == lexema[i_Lexema])
					{
						//Incrementamos el índice que apunta al siguiente caracter del lexema
						i_Lexema += 1;
						//Ahora, el estado anterior es el estado en donde estamos ahora, y el estado siguiente es el
						//estado al que apunta la transición que elejimos con ese símbolo
						return bpf(estado, t.estado_siguiente);
					}
				}
			}
			return false;
		}
		#endregion

	}
}
