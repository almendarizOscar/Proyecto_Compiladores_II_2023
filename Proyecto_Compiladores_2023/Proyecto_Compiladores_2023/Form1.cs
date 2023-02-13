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
			return "";
		}
		//[Ivan]
		private string agregar_amperson(string expresion_regular)
		{
			return "";
		}

		//[Oscar Almendariz]
		private void limpiar_interfaz()
		{
			BotonConvertirPosfija.Enabled = false;
		}
	}
}
