using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proyecto_Compiladores_2023
{
	public partial class Form1 : Form
	{

		//Lista de caracteres que pertenecen al lenguaje (incluyendo ε) y que no se repiten. No incluye operadores
		//Esta lista se utiliza para los nombres de los encabezados de las columnas de la tabla de transiciones
		private List<string> palabras_reservadas = new List<string>() { "if", "then", "else", "end", "repeat", "until", "read", "write" };
		private List<string> simbolos_especiales = new List<string>() { "+", "-", "*", "/", "=", "<", ">", "(", ")", ";", ":=" };
		private List<string> otros_identificadores = new List<string>() { "numero", "identificador" };

		private List<char> alfabeto;
		ManejadorAFN manejador;
		Automata afn;
		AFD afd;

		ExpresionFormalDeG G;

		public Form1()
		{
			InitializeComponent();
			button3.Enabled = false;
			this.StartPosition = FormStartPosition.CenterScreen;

			manejador = new ManejadorAFN();
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			tablaAFD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			tablaAFD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		}
		//Método para limpiar
		private void button2_Click(object sender, EventArgs e)
		{

			TextBox1.Text = TextBox2.Text = textBox4.Text = textBox3.Text = textBox5.Text = txtEdosAFD.Text = textBox6.Text = "";
			label10.Text = "";
			button3.Enabled = button4.Enabled = true;
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			tablaAFD.Rows.Clear();
			tablaAFD.Columns.Clear();
		}
		
		



		#region Metodos para construcción del AFN
		private void button3_Click(object sender, EventArgs e)
		{
			Button1.Enabled = true;
			afn = Construir_AFN(TextBox2.Text);


			//4to: Limpiamos la tabla antes de usarla
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();

			//5to: Ponemos columnas
			poner_columnas();

			//6to: Antes de insertar filas a la tabla de transiciones, le mandamos al manejador el datgreedview
			//para que esta clase sea la encargada de manipular la herramienta
			manejador.tabla_de_transiciones = dataGridView1; //Imprime las filas

			//7mo: Ordenamos la lista de estados del autómata
			afn.estado = afn.estado.OrderBy(x => x.id).ToList(); //Ordenamiento de los estados por su id

			//8vo: Rellenamos la tabla de transicones
			manejador.insetar_fila_en_la_tabla_transiciones(afn, alfabeto);

			//Información del autómata
			textBox4.Text = afn.estado.Count.ToString();
			textBox3.Text = afn.numero_de_transiciones_epsilon().ToString();
			button3.Enabled = false;
		}
		private Automata Construir_AFN(string postfija)
		{
			//1ro: Construimos el AFN
			Automata AFN = manejador.construir_AFN(postfija); //Creamos un AFN a partir de la expresión regular

			//2do: Obtenemos el alfabeto
			alfabeto = manejador.obtener_alfabeto(postfija);

			//3ro: Enumeramos los estados del automata de 0 a n.
			manejador.contador = 0;
			manejador.enumerar_estados(AFN.estado_de_inicio); //Recorrido en profundidad
			manejador.poner_visitados_en_falso(AFN.estado_de_inicio);

			return AFN;
		}
		private void poner_columnas()
		{
			//Insertar las columnas
			dataGridView1.Columns.Add("Estados", "Estados");
			for (int i = 0; i < alfabeto.Count; i++)
			{
				dataGridView1.Columns.Add("Columna" + i, alfabeto[i].ToString());
			}

		}
		#endregion

		#region Métodos para la construcción del AFD
		private void button4_Click(object sender, EventArgs e)
		{
			//Creamos una instancia del AFD
			afd = new AFD(afn, alfabeto);
			//Generamos el AFD
			afd.GeneraAFD(afn.estado_de_inicio);
			//Llenamos la tabla de transiciones del AFD
			afd.llenaTabla(tablaAFD);
			//Mostramos el número de estados del AFD
			txtEdosAFD.Text = afd.Destados.Count.ToString();

			afd.encontrar_nodos_de_aceptacion(afn.estado_aceptacion);
			textBox5.Text = "";
			textBox5.Text = afd.estados_de_aceptacion; //Estados de aceptación
			button4.Enabled = false;
		}
		#endregion

		#region Elaboración de la Posfija 
		//Boton que contiene la secuencia de pasos que se deben aplicar para obtener la expresión posfija de
		//la expresión regular
		private void btnRegularPostija_Click(object sender, EventArgs e)
		{
			//Obtener la cadena de texto que contiene el Textbox donde se ingresa la expresión regular 
			string expresionRegular = this.TextBox1.Text;
			//Ahora, lo que se quese encuentre entre corchetes se va a normalizar. 
			expresionRegular = convertir_rango(expresionRegular);
			//Agregamos & donde sea necesario dentro de la expresión regular
			expresionRegular = agregar_amperson(expresionRegular);
			//Una vez que ya se normalizó la expresión regular la volvemos a mostrar en pantallas
			//En el mismo textbox donde se escribio
			TextBox1.Text = expresionRegular;
			//Aplicamos el algoritmo de conversión a posfija
			TextBox2.Text = postfija(expresionRegular);
			button3.Enabled = true;
		}
		//Algoritmo para convertir la expresión regular en posfija
		private string postfija(string expresion_regular)
		{
			Stack<char> pila = new Stack<char>();
			bool bandera;
			char caracter;
			char ultimoOperador;
			string postfija = "";
			int i = 0;
			int Tamaño_expresión_regular = expresion_regular.Length;
			while (i < Tamaño_expresión_regular)
			{

				caracter = expresion_regular[i];

				if (caracter == '(')
					pila.Push(caracter);
				else if (caracter == ')')
					postfija += POP(pila);
				else if (caracter == '+' || caracter == '*' || caracter == '?' || caracter == '&' || caracter == '|')
				{
					bandera = true;
					while (bandera)
					{
						ultimoOperador = (pila.Count == 0) ? ' ' : pila.ElementAt(0);
						if (pila.Count == 0 ||
							ultimoOperador == '(' ||
							prioridad(ultimoOperador) < prioridad(caracter))
						{
							pila.Push(caracter);
							bandera = false;
						}
						else
							postfija += pila.Pop();
					}
				}
				else
					postfija += caracter;

				i++;
			}

			if (pila.Count > 0)
				postfija += POP(pila);

			return postfija; //Regresamos la expresión postfija
		}

		//Obtener la prioridad del operador que se le envía por parámetro
		private int prioridad(char operador)
		{
			if (operador == '+' || operador == '*' || operador == '?')
				return 3;
			else if (operador == '&')
				return 2;
			else if (operador == '|')
				return 1;
			else
				return 6;
		}

		//POP nos sirve para retirar un elemento de la pila
		private string POP(Stack<char> pila)
		{
			string operadores = "";
			char operador;

			while (true)
			{
				operador = pila.Pop();
				if (operador == '(')
					break;
				else
					operadores += operador;

				if (pila.Count == 0)
					break;
			}
			return operadores;
		}

		private string convertir_rango(string expresion_regular)
		{
			string nueva_expresion = "";
			int i = 0;
			bool estoy_dentro_de_los_corchetes = false;

			while (i < expresion_regular.Length)
			{
				if (estoy_dentro_de_los_corchetes)
				{
					if (expresion_regular[i + 1] == ']')
					{
						nueva_expresion += ')';
						estoy_dentro_de_los_corchetes = false;
						i += 1;

					}
					else
					{
						if (expresion_regular[i + 1] == '-')
						{

							int inicial = ASCII(expresion_regular[i].ToString());
							int final = ASCII(expresion_regular[i + 2].ToString());

							for (int ini = inicial + 1; ini <= final; ini++)
							{
								nueva_expresion += '|';
								nueva_expresion += Char(ini);
							}
							i += 1;
						}
						else
						{
							nueva_expresion += '|';
							nueva_expresion += expresion_regular[i + 1];
						}
					}
				}
				else
				{
					if (expresion_regular[i] == '[')
					{
						nueva_expresion += '(';
						nueva_expresion += expresion_regular[i + 1];
						estoy_dentro_de_los_corchetes = true;

					}
					else
						nueva_expresion += expresion_regular[i];
				}
				i += 1;
			}
			return nueva_expresion;
		}

		private string agregar_amperson(string expresion_regular)
		{
			string nueva_expresion = "" + expresion_regular[0];

			for (int i = 0, j = 1; i < expresion_regular.Length - 1; i++, j++)
			{
				if (expresion_regular[i] != '(' && expresion_regular[j] != ')')
				{
					if (expresion_regular[j] != '*' && expresion_regular[j] != '?' && expresion_regular[j] != '+')
					{
						if (expresion_regular[i] != '|' && expresion_regular[j] != '|')
						{
							nueva_expresion += "&";
						}
					}
				}
				nueva_expresion += expresion_regular[j];
			}
			return nueva_expresion;
		}
		//Método que devuelve el código ASCII de un caracter
		private int ASCII(string caracter)
		{
			Byte[] ASCIIvalues = Encoding.ASCII.GetBytes(caracter);
			string entero = ASCIIvalues[0].ToString();
			return int.Parse(entero);
		}
		//Método que devulve el caracter correspondiente al número ASCII de 'valor'
		private char Char(int valor)
		{
			int val = valor;
			char ch = (char)val;
			return ch;
		}

		#endregion

		//En esta sección está el código necesario para analizar el lexema y validarlo
		#region Analizador del lexema
		//Botón para validar el lexema 
		private void button5_Click(object sender, EventArgs e)
		{
			/*	Dentro de la clase AFD hay un método para hacer la validación del lexema
				Solo hay que pasarle la cadena de texto del lexema */
			if (afd.validar_Lexema(textBox6.Text))
			{
				label10.Text = "El lexema " + textBox6.Text + " es VALIDO.";
				label10.ForeColor = Color.ForestGreen;
			}
			else
			{
				label10.Text = "El lexema " + textBox6.Text + " es INVALIDO.";
				label10.ForeColor = Color.Red;
			}
			textBox6.Text = "";
		}
		#endregion


		#region Métodos para el Léxico
		//Este es método nos devuelve un AFD que nos
		private AFD construir_AFD_de_la_expresión_regular(string txtPostfija)
		{
			//Paso 1: Antes de obtener el AFD, primero debemos de obtener la expresión posfija de la expresión regular.
			//Entonces, convertimos las las expresiones de tipo [] a su forma normal, agregamso & donde sea necesario y
			//obtenemos la expresion posfijaa
			txtPostfija = convertir_rango(txtPostfija);
			txtPostfija = agregar_amperson(txtPostfija);
			txtPostfija = postfija(txtPostfija); //Convierte la expresión regular en postfija

			//Paso 2: Construimos el AFN de la expresión regular
			Automata AFN = Construir_AFN(txtPostfija); //Este método también obtiene el alfabeto a partir de la ER
			AFN.estado = AFN.estado.OrderBy(x => x.id).ToList(); //Ordenamiento de los estados por su id
			manejador.Llena_TablaEstados(AFN, alfabeto);

			//Paso 3: construimos el AFD de la expresión regular
			AFD elAFD = new AFD(AFN, alfabeto);
			elAFD.GeneraAFD(AFN.estado_de_inicio);
			elAFD.encontrar_nodos_de_aceptacion(AFN.estado_aceptacion);

			return elAFD;
		}

		private void btnIdentificarTokens_Click(object sender, EventArgs e)
		{
			//Paso 1: Tenemos que obtener el AFD para el identificador y para el número
			AFD afd_identificador = construir_AFD_de_la_expresión_regular(TextBox_Identificador.Text);
			AFD afd_numero = construir_AFD_de_la_expresión_regular(TextBox_Numero.Text);

			//Paso 2:Limpiamos la tabla antes de usarlo
			DataGredView_Tokens.Rows.Clear();

			//Paso 3: Tratamos el programa
			//Tomamos el código que está en la entrada de texto y elimina los saltos de línea, los retornos y las tabulaciones.
			//No se eliminan los espacios entre palabras.
			string programa = TextBox_Programa.Text.Replace("\n", "").Replace("\r", "").Replace("\t", " ");
			//El método "Split" divide una cadena de texto en subcadenas más pequeñas basándose en un delimitador especificado y devuelve un arreglo de las subcadenas resultantes.
			//En este caso, se utiliza el espacio en blanco como delimitador, para dividir la cadena de texto "programa" en subcadenas más pequeñas en cada lugar donde se encuentre
			//un espacio en blanco.
			string[] tokens = programa.Split(' ');

			//Paso 4: Como útimo paso vamos a clasificar cada uno de los símbolos del programa
			int count = 0;
			foreach (string token in tokens)
			{
				if (token.Length > 0)
				{
					//Agregamos una nueva fila en la tabla
					DataGredView_Tokens.Rows.Add();
					//Esta primera condicional lo que hace es verifica si el símbolo que se analiza es una palabra reservada, es un símbolo especial,
					//o algún otro identificador.					
					if (palabras_reservadas.IndexOf(token) >= 0 || simbolos_especiales.IndexOf(token) >= 0 || otros_identificadores.IndexOf(token) >= 0)
					{
						DataGredView_Tokens.Rows[count].Cells[0].Value = token;
					}					
					//Esta condicional verifica si es un nombre de una variable
					else if (afd_identificador.validar_Lexema(token))
					{
						DataGredView_Tokens.Rows[count].Cells[0].Value = "identificador";
					}
					//Este condicional verifica si es un némero
					else if (afd_numero.validar_Lexema(token))
					{
						DataGredView_Tokens.Rows[count].Cells[0].Value = "número";
					}
					//Si no fue ninguna de las anteriores, enotnces es un error
					else
					{
						DataGredView_Tokens.Rows[count].Cells[0].Value = "Error léxico";
						DataGredView_Tokens.Rows[count].Cells[0].Style.ForeColor = Color.Red;
						DataGredView_Tokens.Rows[count].Cells[1].Style.ForeColor = Color.Red;
					}
					
					DataGredView_Tokens.Rows[count].Cells[1].Value = token;
					//Pasamos al siguiente símbolo
					count++;
				}
			}
		}
		#endregion

		private void button6_Click(object sender, EventArgs e)
		{
			//Usamos el Textbox5 como control para mostrar informacion de los estados
			GeneradorDeColeccionCanonica.informacion = textBox5;
			//G es la Expresión formal de la gramática
			G = new ExpresionFormalDeG(); //Cargamos la gramatica TINY
			//Generamos la gramática aumentada del LR(0)
			GeneradorDeColeccionCanonica.generar_automataLR0(G);
			//Cargamos la tabla de transicones 
			mostrar_tabla_Transiciones();
			//Mostramos las colecciones (Se debe de generar el automata antes de usar este metodo)
			mostrar_colecciones();
			
		}

		private void mostrar_tabla_Transiciones()
		{
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			poner_columnas_Tabla_AutomataLR();
			llenarTablaAutomataLR();
		}

		private void mostrar_colecciones()
		{
			textBox5.Text += "Numero de Colecciones: " + GeneradorDeColeccionCanonica.C.Count + Environment.NewLine;
			for (int i = 0; i < GeneradorDeColeccionCanonica.automata.estado.Count; i++)
			{
				EstadoLR estado = GeneradorDeColeccionCanonica.automata.estado[i];
				I coleccion = estado.coleccion;
				textBox5.Text += "I" + coleccion.id + " = " + coleccion.imprimir_coleccion() + Environment.NewLine + Environment.NewLine;
			}

		}
		private void poner_columnas_Tabla_AutomataLR()
		{
			//Insertar las columnas
			dataGridView2.Columns.Add("Estados", "Estados");
			foreach (string terminal in GeneradorDeColeccionCanonica.G_aumentada.Terminal)
				dataGridView2.Columns.Add(terminal, terminal);
			foreach (string NoTerminal in GeneradorDeColeccionCanonica.G_aumentada.NoTerminal)
				dataGridView2.Columns.Add(NoTerminal, NoTerminal);

		}
		private void llenarTablaAutomataLR()
		{
			//El primer recorrido de manera vertical hacia abajo, revisando estado por estado (Los estados ya estan ordenados)
			for (int i = 0; i < GeneradorDeColeccionCanonica.automata.estado.Count; i++)
			{
				EstadoLR estado = GeneradorDeColeccionCanonica.automata.estado[i];
				dataGridView2.Rows.Add(); //Agregamos una fila
				dataGridView2.Rows[i].Cells[0].Value = estado.id;


				int j;
				//Recorremos primero los simbolos terminales de la gramtica
				for (j = 0; j < GeneradorDeColeccionCanonica.G_aumentada.Terminal.Count; j++)
				{
					foreach (TransicionLR transicion in GeneradorDeColeccionCanonica.automata.transiciones)
					{
						if ((transicion.estado_inicio.id == estado.id) && (transicion.simbolo == GeneradorDeColeccionCanonica.G_aumentada.Terminal[j]))
						{
							dataGridView2.Rows[i].Cells[j + 1].Value = transicion.estado_siguiente.id;
							break;
						}
					}
				}
				//Ahora recorremos por ultimo los simbolos No terminales de la gramtica
				for (int x = 0; x < GeneradorDeColeccionCanonica.G_aumentada.NoTerminal.Count; j++, x++)
				{
					foreach (TransicionLR transicion in GeneradorDeColeccionCanonica.automata.transiciones)
					{
						if ((transicion.estado_inicio.id == estado.id) && (transicion.simbolo == GeneradorDeColeccionCanonica.G_aumentada.NoTerminal[x]))
						{
							dataGridView2.Rows[i].Cells[j + 1].Value = transicion.estado_siguiente.id;
							break;
						}
					}
				}

			}
		}
	}
}

