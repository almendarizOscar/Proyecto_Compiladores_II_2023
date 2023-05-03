using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Compiladores_2023
{
	static class GeneradorDeColeccionCanonica
	{
		/*
		  Clase que contiene los algoritmos para crear la Colección LR(0) Canónica
		  No es necesario crear un objeto de esta clase.
		  Tiene los siguientes algoritmos:
		 		- void elementos(G’);
		 		- ConjuntoDeElementos CERRADURA( I )
		 		- ConjuntoDeElementos ir_A( I, X )
		 		
		   Y basicamente, para poder crear las colecciones solo se debe de llamar el método: 
			void gerar_automataLR0(ExpresionFormalDeG G);				
		 */
		public static ExpresionFormalDeG G_aumentada; //Expresión formal de la gramatica
		public static AutomataLR automata; //Autómata LR
		public static List<I> C; //Conjunto de colecciones
		public static TextBox informacion; //Control para mostrar información de las colecciones en pantalla
		public static int id_estado;

		//Cuando llama este método crea el automata LR y el conjunto de colecciones C
		public static void generar_automataLR0(ExpresionFormalDeG G)
		{
			id_estado = 0;
			C = new List<I>();
			automata = new AutomataLR();
			gramatica_Aumentada(G); //Primero creamos la gramática aumentada 									
			elementos(G_aumentada); //Y calcular las colecciones 
		}

		#region Algoritmos para Creación de colecciones
		private static void gramatica_Aumentada(ExpresionFormalDeG G)
		{
			//Vamos a agregar una nueva producción: S' -> S
			//Será la primera producción de la lista
			G_aumentada = G;
			G_aumentada.P.Insert(0, new Produccion(G.SimboloInicial + "'", new List<string>() { G.SimboloInicial }));
			G_aumentada.SimboloInicial = G_aumentada.P[0].NoTerminal;

		}
		static void elementos(ExpresionFormalDeG G_Aumentada)
		{
			//Aplicamos la funcion cerradura a la primera producción de la gramatica
			//El contenido de C hasta aquí es el primer estado del automata LR. Este estado se llama I0
			//Esto es igual a: C = {I0}
			//Hay que agregar un nuevo estado al autómata LR que seria I0
			Produccion Nueva_produccion = new Produccion(G_aumentada.P[0].NoTerminal, G_aumentada.P[0].cuerpo);
			//Agregamos el punto a esta producción que es con la que iniciamos
			Nueva_produccion.cuerpo.Insert(0, ".");
			List<Produccion> lista_producciones = new List<Produccion>() { Nueva_produccion };
			I nuevo_I = new I(CERRADURA(lista_producciones));
			nuevo_I.id = id_estado;
			C.Add(nuevo_I);
			//Se lo vamos a poner al estado y al conjunto I
			EstadoLR estado = new EstadoLR(id_estado, nuevo_I);
			//Lo agregamos al autómata
			automata.estado.Add(estado);
			id_estado++;

			int i = 0;
			//Hacer mientras haya conjutnos no marcados en C
			do
			{

				//Para cada conjunto I de elmentos en C
				//Hacer lo siguiente para cada símbolo gramatical:
				//Para los simbolos de los terminales
				foreach (string simbolo in G_aumentada.Terminal)
				{
					ir_A(C[i], simbolo);

				}
				//Para lso símbolos de los No terminales
				foreach (string simbolo in G_aumentada.NoTerminal)
				{
					//mensaje("/t" + simbolo);
					ir_A(C[i], simbolo);
				}
				//Una vez que ya se hizo el recorrido para todos los símbolos gramaticales,
				//continuar con el sigueinte conjunto I(n+1)

				C[i].Marcado = true; //Lo marcamos como ya revisado
				i = conjunto_que_aun_no_esta_marcado();

			} while (i != -1);
			//Una vez que ya no tenemos conjuntos sin marcar, el autómata ya está listo.
		}

		//Este método se encarga de:
		//	- crea nuevos estados del automata LR
		//  - crear nuevas colecciones
		//  - crear las transiciones del automata
		private static void ir_A(I In, string X)
		{
			List<Produccion> conjunto = new List<Produccion>();
			//Recorremos los elementos de In
			foreach (Produccion elemento in In.elemento)
			{
				//Buscamos elementos de la forma [ A → α.Xβ ] en el
				if (hay_este_simbolo_X_despues_del_punto(elemento, X))
				{
					Produccion nuevo_elemento = new Produccion(elemento.NoTerminal, elemento.cuerpo);
					//A cada uno de ellos le recorremos el “.” (punto) una posición a la
					//derecha, quedando de la siguiente forma: [A → αX.β]
					int indice_del_punto = nuevo_elemento.cuerpo.FindIndex(x => x == ".");
					string sig_simbolo = nuevo_elemento.cuerpo[indice_del_punto + 1];
					nuevo_elemento.cuerpo[indice_del_punto + 1] = ".";
					nuevo_elemento.cuerpo[indice_del_punto] = sig_simbolo.ToString();

					conjunto.Add(nuevo_elemento);
				}
				//Si este elemento no tiene a X despues del punto entonces pasa al siguiente elemento
			}
			if (conjunto.Count != 0)
			{
				I nuevo_conjunto_I = new I(CERRADURA(conjunto));
				//Si el conjunto que regresa (nueva I) no está vacío y no está en C, entonces se agrega a C.
				if (nuevo_conjunto_I.elemento.Count != 0)
				{

					int conjunto_existente = existe_este_conjuntoI_en_C(nuevo_conjunto_I);
					//Vamos a buscar el estado que tiene el conjunto In
					EstadoLR estado_actual = automata.estado.Find(x => x.id == In.id);
					if (conjunto_existente == -1)
					{
						nuevo_conjunto_I.id = id_estado;
						C.Add(nuevo_conjunto_I);
						// Agregar el estado y la transición al autómata LR(0)

						EstadoLR estado = new EstadoLR(id_estado, nuevo_conjunto_I);
						TransicionLR transicion = new TransicionLR(estado_actual, X, estado);

						automata.estado.Add(estado);
						automata.transiciones.Add(transicion);
						id_estado += 1;
					}
					else
					{
						EstadoLR estado_existente = automata.estado.Find(x => x.id == conjunto_existente);

						//No se agrega el conjunto pero si la transición
						TransicionLR transicion = new TransicionLR(estado_actual, X, estado_existente);
						automata.transiciones.Add(transicion);
					}
				}
			}
		}


		//Evaluar cada elemento en J que tenga un no terminal después del punto. De la forma:
		//A -> α.Bβ. Regresa un nuevo conjunto de elementos
		private static I CERRADURA(List<Produccion> p)
		{
			//Estamos agregando esta produccion al conjunto final		
			List<Produccion> J = new List<Produccion>();
			J.AddRange(p);
			int cont = 0;
			int numero_de_elementos_en_J = 0;
			do
			{

				//Nos traemos el primer elemento de J que ha sido agregado
				Produccion elemento = new Produccion(J[cont].NoTerminal, J[cont].cuerpo);

				//Ahora, en este elemento, revisamos si hay un No Terminal después del punto
				int B = hay_un_NoTerminal_despues_del_punto(elemento);

				//Si B es diferente -1 quiere decir que si hay
				//B es la posición del No terminal en el cuerpo del elemento
				if (B != -1)
				{
					//Nos traemos todas la producciones de B que esten en P y les vamos agregar punto (.) al inicio
					foreach (Produccion produccion in G_aumentada.P)
					{
						if (elemento.cuerpo[B] == produccion.NoTerminal)
						{


							Produccion nueva_p = new Produccion(produccion.NoTerminal, produccion.cuerpo);
							//A la producción que tomamos de P le agregamos un punto al inicio del cuerpo
							//(Es una produccion con el simbolo epsilon, se lo quitamos).
							if (nueva_p.cuerpo.Count == 1)
							{
								if (nueva_p.cuerpo[0] == "ε")
								{
									nueva_p.cuerpo.Clear();
									nueva_p.cuerpo.Add(".");
								}
								else
									nueva_p.cuerpo.Insert(0, ".");
							}
							else
								nueva_p.cuerpo.Insert(0, ".");
							//Si esta nueva producción no se encuentra en J, la agregamos
							if (!Existe_este_elemento_en_J(J, nueva_p))
								J.Add(nueva_p);

						}
					}
				}
				numero_de_elementos_en_J = J.Count;
				cont += 1;
			} while (cont < numero_de_elementos_en_J);

			//I es la colección que se va a regresar. Pero J tiene todos los elementos de esa colección
			//Entonces solo asignamos
			return new I(J);
		}


		#endregion



		#region Metodos para probar los algoritmos para Colección LR(0) Canónica
		/************************************************************************************************************************************/
		//Prueba para la gramatica aumentada
		public static void pruba_G_aumentada(ExpresionFormalDeG G)
		{
			gramatica_Aumentada(G);
			informacion.Text += "Terminales: ";
			foreach (string simbolo in G_aumentada.Terminal)
				informacion.Text += simbolo + ", ";
			informacion.Text += Environment.NewLine + "No Terminales: ";
			foreach (string simbolo in G_aumentada.NoTerminal)
				informacion.Text += simbolo + ", ";
			informacion.Text += Environment.NewLine + "Simbolo incial: " + G_aumentada.SimboloInicial;
			informacion.Text += Environment.NewLine + "P: ";
			foreach (Produccion p in G_aumentada.P)
			{
				informacion.Text += p.convertir_a_texto();
			}
		}

		/************************************************************************************************************************************/
		//Prueba del algoritmo CERRADURA()
		public static void llenar_C()
		{
			I i0 = new I(new List<Produccion>() {
										new Produccion ("E'", new List<string>() {".","E"}),
										new Produccion ("E", new List<string>() { ".", "E","+","T"}),
										new Produccion ("E", new List<string>() { ".", "T"}),
										new Produccion ("T", new List<string>() { ".", "T","*","F"}),
										new Produccion ("T", new List<string>() { ".", "F"}),
										new Produccion ("F", new List<string>() { ".", "(","E",")"}),
										new Produccion ("F", new List<string>() { ".", "id"})
									});
			I i1 = new I(new List<Produccion>() {
										new Produccion ("F", new List<string>() { "(",".","E",")"}),
										new Produccion ("E", new List<string>() { ".", "E","+","T"}),
										new Produccion ("E", new List<string>() { ".", "T"}),
										new Produccion ("T", new List<string>() { ".", "T","*","F"}),
										new Produccion ("T", new List<string>() { ".", "F"}),
										new Produccion ("F", new List<string>() { ".", "(","E",")"}),
										new Produccion ("F", new List<string>() { ".", "id"})
									});

			I i2 = new I(new List<Produccion>() {
										new Produccion ("F", new List<string>() { "id","."})
									});


			C = new List<I>() { i0 };
		}
		public static void prueba_de_CERRADURA(ExpresionFormalDeG G)
		{

			gramatica_Aumentada(G);
			llenar_C();
			//GeneradorDeColeccionCanonica.G_aumentada.P[0].cuerpo.Insert(0, ".");
			I coleccion = CERRADURA(
				new List<Produccion>() {
									new Produccion("S", new List<string>{"A","+",".","S"})
				}
			);
			informacion.Text += "Numero de elementos creados: " + coleccion.elemento.Count + Environment.NewLine;
			informacion.Text += "I " + coleccion.imprimir_coleccion();

		}
		/************************************************************************************************************************************/
		//Prueba del algoritmo is_A() (Falta probar)
		public static void pruba_ir_A(ExpresionFormalDeG G)
		{

			automata = new AutomataLR(); //Creamos el autómata
			gramatica_Aumentada(G); //Creamos la gramática aumentada
									//Crear la coleccion I0 y guardarla en C
			I i0 = new I(new List<Produccion>() {
										new Produccion ("S'", new List<string>() {".","S"}),
										new Produccion ("S", new List<string>() { ".", "A","+","S"}),
										new Produccion ("A", new List<string>() { ".", "id"}),
										new Produccion ("A", new List<string>() { ".", "(","id",")"})
				});
			I i1 = new I(new List<Produccion>() {
										new Produccion ("F", new List<string>() { "(",".","E",")"}),
										new Produccion ("E", new List<string>() { ".", "E","+","T"}),
										new Produccion ("E", new List<string>() { ".", "T"}),
										new Produccion ("T", new List<string>() { ".", "T","*","F"}),
										new Produccion ("T", new List<string>() { ".", "F"}),
										new Produccion ("F", new List<string>() { ".", "(","E",")"}),
										new Produccion ("F", new List<string>() { ".", "id"})
				});

			I i2 = new I(new List<Produccion>() {
										new Produccion ("F", new List<string>() { "id","."})
				});


			C = new List<I>() { i0 };


			informacion.Text += "Numero de colecciones antes de la funcion ir_A(I, x): " + C.Count + Environment.NewLine;
			informacion.Text += "Ir_A (I0, +) " + Environment.NewLine;
			ir_A(i0, "+");
			informacion.Text += "Numero de colecciones: " + C.Count + Environment.NewLine;
			C[C.Count - 1].imprimir_coleccion();
			informacion.Text += "------------------------------------------------------------------" + Environment.NewLine;

			informacion.Text += "Numero de colecciones antes de la funcion ir_A(I, x): " + C.Count + Environment.NewLine;
			informacion.Text += "Ir_A (I0, id) " + Environment.NewLine;
			ir_A(i0, "id");
			informacion.Text += "Numero de colecciones: " + C.Count + Environment.NewLine;
			informacion.Text += C[C.Count - 1].imprimir_coleccion() + Environment.NewLine;
			informacion.Text += "------------------------------------------------------------------" + Environment.NewLine;

			informacion.Text += "Numero de colecciones antes de la funcion ir_A(I, x): " + C.Count + Environment.NewLine;
			informacion.Text += "Ir_A (I0, () " + Environment.NewLine;
			ir_A(i0, "(");
			informacion.Text += "Numero de colecciones: " + C.Count + Environment.NewLine;
			informacion.Text += C[C.Count - 1].imprimir_coleccion() + Environment.NewLine;
			informacion.Text += "------------------------------------------------------------------" + Environment.NewLine;

			informacion.Text += "Numero de colecciones antes de la funcion ir_A(I, x): " + C.Count + Environment.NewLine;
			informacion.Text += "Ir_A (I0, )) " + Environment.NewLine;
			ir_A(i0, ")");
			informacion.Text += "Numero de colecciones: " + C.Count + Environment.NewLine;
			informacion.Text += C[C.Count - 1].imprimir_coleccion() + Environment.NewLine;
			informacion.Text += "------------------------------------------------------------------" + Environment.NewLine;

			informacion.Text += "Numero de colecciones antes de la funcion ir_A(I, x): " + C.Count + Environment.NewLine;
			informacion.Text += "Ir_A (I0, S) " + Environment.NewLine;
			ir_A(i0, "S");
			informacion.Text += "Numero de colecciones: " + C.Count + Environment.NewLine;
			informacion.Text += C[C.Count - 1].imprimir_coleccion() + Environment.NewLine;
			informacion.Text += "------------------------------------------------------------------" + Environment.NewLine;

			informacion.Text += "Numero de colecciones antes de la funcion ir_A(I, x): " + C.Count + Environment.NewLine;
			informacion.Text += "Ir_A (I0, A) " + Environment.NewLine;
			ir_A(i0, "A");
			informacion.Text += "Numero de colecciones: " + C.Count + Environment.NewLine;
			informacion.Text += C[C.Count - 1].imprimir_coleccion() + Environment.NewLine;
			informacion.Text += "------------------------------------------------------------------" + Environment.NewLine;
		}

		#endregion



		#region Métodos para la manipulación de colecciones y producciones
		//[CORRECTO]
		// Método para saber que coleccion siguiente tomar del conjunto C. Siempre toma la que no esta marcada
		//Si esta función regresa -1, quiere decir que ya todos las colecciones fueron revisados
		private static int conjunto_que_aun_no_esta_marcado()
		{
			for (int i = 0; i < C.Count; i++)
			{

				if (C[i].Marcado == false)
					return i;
			}
			return -1;
		}
		public static void poner_algunas_colecciones_en_C()
		{
			I i0 = new I(new List<Produccion>() { });
			I i1 = new I(new List<Produccion>() { });
			I i2 = new I(new List<Produccion>() { });
			I i3 = new I(new List<Produccion>() { });
			i0.Marcado = i1.Marcado = true;
			C = new List<I>() { i0, i1, i2, i3 };
		}
		public static void PROBAR_poner_algunas_colecciones_en_C()
		{
			poner_algunas_colecciones_en_C();
			informacion.Text += "Próximo conjunto a leer: " + conjunto_que_aun_no_esta_marcado();
		}
		/************************************************************************************************************************************/
		//[CORRECTO]
		//Método para saber si hay un No terminal despues del punto en una producción
		private static int hay_un_NoTerminal_despues_del_punto(Produccion p)
		{
			//Primero encontramos la posición del punto en el cuerpo de la producción
			//Ejemplo: A --> D . A c
			//Posición:      0 1 2 3
			//El metodo regresa 2, porque el punto (.) es el segundo simbolo del cuerpo.
			//y está en la posición 1. Si no hay un punto en el cuerpo, regresa -1.
			int indice_del_punto = p.cuerpo.FindIndex(x => x == ".");

			//Verificamos si el siguiente simbolo es un No Terminal
			//Si no hay un punto regresa -1
			if (indice_del_punto == -1)
				return -1;
			//Si el unico elemento que hay en el cuerpo es un punto regresa, -1.
			else if (p.cuerpo.Count == 1 && indice_del_punto == 0)
				return -1;
			//Si el punto es el último simbolo de la producción regresa -1.
			else if (indice_del_punto == p.cuerpo.Count - 1)
				return -1;
			else
			{
				string sig_simbolo_despues_del_punto = p.cuerpo[indice_del_punto + 1];
				//informacion.Text += "Posicion del punto : " + indice_del_punto + Environment.NewLine;
				//Ver si el simbolo despues del punto es un No terminal
				if (G_aumentada.NoTerminal.FindIndex(x => x == sig_simbolo_despues_del_punto) == -1)
					return -1;
				else
					return indice_del_punto + 1;
			}
		}
		public static void PRUEBA_hay_un_NoTerminal_despues_del_punto(ExpresionFormalDeG G)
		{
			gramatica_Aumentada(G);
			Produccion p = new Produccion("A", new List<string>() { "a", "A", "B", "." });
			int indice_del_noTerminal = hay_un_NoTerminal_despues_del_punto(p);
			informacion.Text += "Posicion del noterminalr : " + indice_del_noTerminal;
		}
		/************************************************************************************************************************************/
		//[CORRECTO]
		//Revisa si existe una producción en un conjunto de producciones
		//Si encuntra una coincidencia regresa true.
		private static bool Existe_este_elemento_en_J(List<Produccion> J, Produccion elemento)
		{
			//Recorre cada una de las producciones del conjunto
			foreach (Produccion elem in J)
			{
				//La primera condicion que se debe de cumplir por default es que la cabecera de laproducción
				//debe ser la misma. Tambien elnumero desímbolos del cuerpo debe ser el mismo
				if ((elem.NoTerminal == elemento.NoTerminal) && ((elem.cuerpo.Count == elemento.cuerpo.Count)))
				{
					//Ahora toca revisar que cada uno de los símbolos del cuerpo sean los mismo
					int i;
					for (i = 0; i < elem.cuerpo.Count; i++)
					{
						//En el caso que un símbolo no coincida, se sale del for automaticamente
						if (elem.cuerpo[i] != elemento.cuerpo[i])
							break;
					}
					//Si todos los símbolos coincidieron entonces i deberia ser igual al numero de símbolos totales
					if (i == elem.cuerpo.Count)
						return true;
				}
			}
			//Si hasta este punto ya se terminaron de comparar todas las producciones, entonces no existe.
			return false;
		}
		public static void PRUEBA_Existe_este_elemento_en_J()
		{
			List<Produccion> J = new List<Produccion>() {
									new Produccion ("A", new List<string>() { "CB"}),
									new Produccion ("C", new List<string>() { "ε", "c"}),
									new Produccion ("B", new List<string>() { "b"})
				};
			bool v = Existe_este_elemento_en_J(J, new Produccion("z", new List<string>() { "ε", "c" }));
			informacion.Text += "Existe la produccion = " + v;
		}
		/************************************************************************************************************************************/
		//[CORREO]
		//Regresa True si dos producciones son iguales
		private static bool son_iguales_estos_elementos(Produccion e1, Produccion e2)
		{
			//Por default, para que sean iguales sus cabeceras debes ser identicas y el número de símbolos debe ser el mismo
			if ((e1.NoTerminal == e2.NoTerminal) && (e1.cuerpo.Count == e2.cuerpo.Count))
			{
				for (int i = 0; i < e1.cuerpo.Count; i++)
				{
					if (e1.cuerpo[i] != e2.cuerpo[i])
						return false;
				}
				return true;
			}
			return false;
		}
		public static void PRUEBA_son_iguales_estos_elementos()
		{
			List<Produccion> J = new List<Produccion>() {
									new Produccion ("D", new List<string>() { "C","B"}),
									new Produccion ("C", new List<string>() { "c", "ε"}),
									new Produccion ("B", new List<string>() { "b"}),
									new Produccion ("A", new List<string>() { "C","B"}),
				};
			bool v = son_iguales_estos_elementos(J[0], J[3]);
			informacion.Text += "Son iguales ? = " + v;
		}
		/************************************************************************************************************************************/
		//[CORRECTO]
		//Método para saber si hay un No terminal despues del punto en una producción
		private static bool hay_este_simbolo_X_despues_del_punto(Produccion p, string X)
		{
			//Primero encontramos la posición del punto en el cuerpo de la producción
			int indice_del_punto = p.cuerpo.FindIndex(x => x == ".");
			//Verificamos si el siguiente simbolo es un No Terminal
			//Evaluar el caso de cunado no existe el punto
			if (indice_del_punto == -1)
				return false;
			//Se debe evaluar el caso cunado el punto es el unico elemento de la produccion
			else if (p.cuerpo.Count == 1 && indice_del_punto == 0)
				return false;
			//Tambien se debe de evaluar el caso para cuando el punto el último simbolo
			else if (indice_del_punto == p.cuerpo.Count - 1)
				return false;
			else
			{
				//Verificar si el simbolo X está despues del punto en este elemento, si es asi, regresa true.
				if (p.cuerpo[indice_del_punto + 1] == X)
					return true;
				else return false;
			}
		}
		public static void PRUEBA_hay_este_simbolo_X_despues_del_punto()
		{

			Produccion p = new Produccion("A", new List<string>() { "CB", ".", "bC", "A", "BC", "." });

			informacion.Text += "¿Hay este símbolo despues del punto? = "
								+ hay_este_simbolo_X_despues_del_punto(p, "bC");
		}
		/************************************************************************************************************************************/
		//[CORRECTO]
		//Evalúa si ya existe I en C
		//Regresa el indice del conjunto que esta en C que ya esta repetido
		private static int existe_este_conjuntoI_en_C(I coleccion_que_queremos_saber_si_ya_exite)
		{
			//Vamos a recorrer cada uno de los conjuntos I que hay en C
			for (int i = 0; i < C.Count; i++)
			{
				//Esta lista nos va a servir para saber si el conjunto ya existe.
				//Si el tamaño de la lista es igual a In, quiere decir que el conjunto ya existe
				List<Produccion> lsita_De_referencia = new List<Produccion>();

				if (C[i].elemento.Count == coleccion_que_queremos_saber_si_ya_exite.elemento.Count) //Si los conjuntos son del mismo tamaño los analisa
				{
					lsita_De_referencia.Clear(); //Borramos el contenido 

					foreach (Produccion elemento_de_C in C[i].elemento)
					{
						foreach (Produccion elemento in coleccion_que_queremos_saber_si_ya_exite.elemento)
						{
							//Si encuentra una coincidencia entre dos elementos, lo guarda en lalista de referencia 
							//Para saber que ya encontró una coincidencia.
							if (son_iguales_estos_elementos(elemento_de_C, elemento))
							{
								lsita_De_referencia.Add(elemento);
								break;
							}
						}
					}
				}
				//Si hay un número de coincidencias igual al tamaño de In, quiere decir que ya existe el conjunto
				if (lsita_De_referencia.Count == coleccion_que_queremos_saber_si_ya_exite.elemento.Count)
					return i;
			}
			return -1;
		}
		public static void PRUEBA_existe_este_conjuntoI_en_C()
		{
			C = new List<I>() {
					new I(new List<Produccion>() {
									new Produccion ("A", new List<string>() { "CB"}),
									new Produccion ("F", new List<string>() { "cA", "b"}),
									new Produccion ("B", new List<string>() { "d"})
					}),
					new I(new List<Produccion>() {
									new Produccion ("A", new List<string>() { "CBabc"}),
									new Produccion ("D", new List<string>() { "c", "ε"}),
									new Produccion ("D", new List<string>() { "b"})
					}),
					new I(new List<Produccion>() {
									new Produccion ("C", new List<string>() { "c"}),
									new Produccion ("C", new List<string>() { "c", "F"}),
									new Produccion ("C", new List<string>() { "CAA"}),
									new Produccion ("C", new List<string>() { "F"})
					})
				};

			I nueva_coleccion = new I(new List<Produccion>() {

									new Produccion ("C", new List<string>() { "CAA"}),
									new Produccion ("C", new List<string>() { "c", "F"}),
									new Produccion ("C", new List<string>() { "F"})
					});

			int i_conjunto_repetido = existe_este_conjuntoI_en_C(nueva_coleccion);
			informacion.Text += "Coleccion repetida = " + i_conjunto_repetido;
		}

		#endregion


		private static void mensaje(string txt)
		{
			informacion.Text += txt + Environment.NewLine;
		}
	}
}
