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
		public Form1()
		{
			InitializeComponent();
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

<<<<<<< HEAD
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
			string nueva_expresion = "" + expresion_regular[0]; //La nueva expresión regular tiene el primer caracter

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
				nueva_expresion += expresion_regular[j]; //Agregamos el operador de la derecha
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
			TextBox1.Text = TextBox2.Text = "";
=======
        //[Ivan]
        private string convertir_rango(string expresion_regular)
        {
            string nueva_expresion = ""; //La nueva expresion regular inicia vacia
            int i = 0;
            bool corchetes = false;

            while (i < expresion_regular.Length)
            {
                if (corchetes) //Si estas trabajando adentro de los corchetes 
                {
                    if (expresion_regular[i + 1] == ']')
                    { //El siguiente caracter es un corchete ']'
                        nueva_expresion += ')'; //Lo cambia por un parentesis derecho
                        corchetes = false;
                        i += 1;
                    }
                    else
                    {
                        if (expresion_regular[i + 1] == '-')
                        {
                            //Agregas las letras que dice el intervalos
                            int inicial = toASCII(expresion_regular[i].ToString());
                            int final = toASCII(expresion_regular[i + 2].ToString()); for (int ini = inicial + 1; ini <= final; ini++)
                            {
                                nueva_expresion += '|';
                                nueva_expresion += toChar(ini);
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
                    if (expresion_regular[i] == '[') //Si se topa con un corchete
                    {
                        nueva_expresion += '('; //Lo cambia por un parentesis izquierdo
                        nueva_expresion += expresion_regular[i + 1]; //Agregamos el primer caracter del intervalo
                        corchetes = true;
                    }
                    else//sino, solo agrega el siguiente caracter a la expresion regular
                        nueva_expresion += expresion_regular[i];
                }
                i += 1;
            }
            return nueva_expresion;
        }

        private int toASCII(string caracter) //agrega ek rango de letras dentro del corchete
        {
            Byte[] ASCIIvalues = Encoding.ASCII.GetBytes(caracter);
            string entero = ASCIIvalues[0].ToString();
            return int.Parse(entero);
        }

        //[Ivan]
        private string agregar_amperson(string expresion_regular)//Funcion que realiza la concatenacion
        {
            string nueva_expresion = "" + expresion_regular[0]; //La nueva expresión regular tiene el primer caracter            

            for (int i = 0, j = 1; i < expresion_regular.Length - 1; i++, j++)
            {
                if (expresion_regular[i] != '(' && expresion_regular[j] != ')')//Evaluar que no sean parentesis
                {
                    if (expresion_regular[j] != '*' && expresion_regular[j] != '?' && expresion_regular[j] != '+') //Evaluar que no sean operadores unarios
                    {
                        if (expresion_regular[i] != '|' && expresion_regular[j] != '|') //Evaluar que no sean un operador de seleccion de alternativas
                        {
                            nueva_expresion += "&";
                        }
                    }
                }
                nueva_expresion += expresion_regular[j]; //Agregamos el operador de la derecha
            }
            return nueva_expresion;
        }

        //[Oscar Almendariz]
        private void limpiar_interfaz()
		{
			BotonConvertirPosfija.Enabled = false;
		}

		private void label5_Click(object sender, EventArgs e)
		{

>>>>>>> 4344ef2250e4d18879f55de9849def3674594b11
		}
	}
}
