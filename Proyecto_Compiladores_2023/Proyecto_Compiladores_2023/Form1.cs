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
		private List<char> alfabeto;
		ManejadorAFN manejador;
		Automata afn;
		AFD afd;

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

		private void button2_Click(object sender, EventArgs e)
		{

			TextBox1.Text = TextBox2.Text = textBox4.Text = textBox3.Text = textBox5.Text = txtEdosAFD.Text = "";
			button3.Enabled = button4.Enabled = true;
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			tablaAFD.Rows.Clear();
			tablaAFD.Columns.Clear();
		}

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
	}
}
