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
		//[Oscar Almendariz R]
		//Boton que contiene la secuencia de pasos que se deben aplicar para obtener la expresión posfija de
		//la expresión regular
		private void btnRegularPostija_Click(object sender, EventArgs e)
		{			
			string expresionRegular = this.ExpresionRegular.Text; //Obtenemos la expresión regular
			expresionRegular = convertir_rango(expresionRegular);
			expresionRegular = agregar_amperson(expresionRegular);
			ExpresionRegular.Text = expresionRegular; //Muestra la expresion regular con & y los rangos extendidos			
			txtPostfija.Text = postfija(expresionRegular); //Convierte la expresión regular en postfija
		}
		//[Oscar]
		private string postfija(string expresion_regular)
		{
			return "";
		}

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

		}
	}
}
