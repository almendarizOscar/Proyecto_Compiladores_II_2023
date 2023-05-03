using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2023
{

	/* Clase para definir la expresión formal de la gramatica
	 * Sintaxis:
	 *			
	 *		G: [ {Conjunto de terminales}, {Conjunto de terminales}, Síimbolo_Inicial, {Conjunto de producciones} ]
	 **/
	class ExpresionFormalDeG
	{
		public List<string> Terminal; //Conjunto de terminales
		public List<string> NoTerminal; //Conjunto de no terminales
		public string SimboloInicial; //Símbolo inicial
		public List<Produccion> P; //Conjunto de producciones

		//En este método se declaran las gramáticas
		public ExpresionFormalDeG()
		{
			//gramatica3();			
			gramatica_TINY();
		}

		private void gramatica3()
		{
			Terminal = new List<string>() { "+", "id", "(", ")" };
			NoTerminal = new List<string>() { "S", "A" };
			SimboloInicial = "S";
			P = new List<Produccion>() {
				new Produccion ("S", new List<string>() { "A","+","S"}),
				new Produccion ("A", new List<string>() { "id"}),
				new Produccion ("A", new List<string>() { "(","id",")"}),

			};
		}
		private void gramatica2()
		{
			Terminal = new List<string>() { "a", "d" };
			NoTerminal = new List<string>() { "S", "D" };
			SimboloInicial = "S";
			P = new List<Produccion>() {
				new Produccion ("S", new List<string>() { "a","D"}),
				new Produccion ("D", new List<string>() { "d"}),
				new Produccion ("D", new List<string>() { "ε"})
			};
		}
		private void gramatica1()
		{
			Terminal = new List<string>() { "c", "b", "a", "d", "e", "f" };
			NoTerminal = new List<string>() { "A", "B", "C", "D", "E", "F" };
			SimboloInicial = "A";
			P = new List<Produccion>() {
				new Produccion ("A", new List<string>() { "C","B"}),
				new Produccion ("C", new List<string>() { "c"}),
				new Produccion ("C", new List<string>() { "ε"}),
				new Produccion ("B", new List<string>() { "b"})
			};
		}

		private void gramatica_TINY()
		{
			Terminal = new List<string>() {
				"if",
				"then",
				"else",
				"end",
				"repeat",
				"until",
				"read",
				"write",
				"+", "-", "*", "/", "=", "<", ">", "(", ")", ";", ":=",
				"numero", "identificador"
				};

			NoTerminal = new List<string>() {
				"programa",
				"secuencia-sent",
				"sentencia",
				"sent-if",
				"sent-repeat",
				"sent-assign",
				"sent-read",
				"sent-write",
				"exp",
				"exp-simple",
				"op-comp",
				"exp-simple",
				"opsuma",
				"term",
				"opmult",
				"factor"
			};

			SimboloInicial = "programa";

			P = new List<Produccion>() {
				//1
				new Produccion ("programa", new List<string>() { "secuencia-sent"}),
				//2
				new Produccion ("secuencia-sent", new List<string>() { "secuencia-sent", ";", "sentencia"}),
				new Produccion ("secuencia-sent", new List<string>() { "sentencia"}),
				//3
				new Produccion ("sentencia", new List<string>() { "sent-if"}),
				new Produccion ("sentencia", new List<string>() { "sent-repeat"}),
				new Produccion ("sentencia", new List<string>() { "sent-assign"}),
				new Produccion ("sentencia", new List<string>() { "sent-read"}),
				new Produccion ("sentencia", new List<string>() { "sent-write"}),
				//4
				new Produccion ("sent-if", new List<string>() { "if","exp","then","secuencia-sent","end"}),
				new Produccion ("sent-if", new List<string>() { "if","exp","then","secuencia-sent","else","secuencia-sent","end"}),
				//5
				new Produccion ("sent-repeat", new List<string>() { "repeat","secuencia-sent","until","exp"}),
				//6
				new Produccion ("sent-assign", new List<string>() { "identificador",":=","exp"}),
				//7
				new Produccion ("sent-read", new List<string>() { "read","identificador"}),
				//8
				new Produccion ("sent-write", new List<string>() { "write","exp"}),
				//9
				new Produccion ("exp", new List<string>() { "exp-simple","op-comp","exp-simple"}),
				new Produccion ("exp", new List<string>() { "exp-simple"}),
				//10
				new Produccion ("op-comp", new List<string>() { "<"}),
				new Produccion ("op-comp", new List<string>() { ">"}),
				new Produccion ("op-comp", new List<string>() { "="}),
				//11
				new Produccion ("exp-simple", new List<string>() { "exp-simple","opsuma","term"}),
				new Produccion ("exp-simple", new List<string>() { "term"}),
				//12
				new Produccion ("opsuma", new List<string>() { "+"}),
				new Produccion ("opsuma", new List<string>() { "-"}),
				//13
				new Produccion ("term", new List<string>() { "term","opmult","factor"}),
				new Produccion ("term", new List<string>() { "factor"}),
				//14
				new Produccion ("opmult", new List<string>() { "*"}),
				new Produccion ("opmult", new List<string>() { "/"}),
				//15
				new Produccion ("factor", new List<string>() { "(","exp",")"}),
				new Produccion ("factor", new List<string>() { "numero"}),
				new Produccion ("factor", new List<string>() { "identificador"})

			};
		}
	}
}
