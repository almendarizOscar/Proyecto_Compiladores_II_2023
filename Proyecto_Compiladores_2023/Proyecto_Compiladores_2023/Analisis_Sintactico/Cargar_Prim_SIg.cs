using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2023.Analisis_Sintactico
{
    internal class Cargar_Prim_SIg
    {
        public List<Primeros> List_Primeros;
        public List<Siguientes> List_Siguientes;

        public Cargar_Prim_SIg() 
        {
            Primero();
            Siguiente();
            //Siguiente2();
            //Siguiente3();//funciona tambien con el ejemplo del arbol
        }

        private void Primero()
        {
            List_Primeros = new List<Primeros>()
            {
                //Primeros de los Terminales
                new Primeros("if",new List<string>() { "if"}),
                new Primeros("then",new List<string>() { "then"}),
                new Primeros("else",new List<string>() { "else"}),
                new Primeros("end",new List<string>() { "end"}),
                new Primeros("repeat",new List<string>() { "repeat"}),
                new Primeros("until",new List<string>() { "until"}),
                new Primeros("read",new List<string>() { "read"}),
                new Primeros("write",new List<string>() { "write"}),
                new Primeros("+",new List<string>() { "+"}),
                new Primeros("-",new List<string>() { "-"}),
                new Primeros("*",new List<string>() { "*"}),
                new Primeros("/",new List<string>() { "/"}),
                new Primeros("=",new List<string>() { "="}),
                new Primeros("<",new List<string>() { "<"}),
                new Primeros(">",new List<string>() { ">"}),
                new Primeros("(",new List<string>() { "("}),
                new Primeros(")",new List<string>() { ")"}),
                new Primeros(";",new List<string>() { ";"}),
                new Primeros(":=",new List<string>() { ":="}),
                new Primeros("numero",new List<string>() { "numero"}),
                new Primeros("identificador",new List<string>() { "identificador"}),
                //Primeros de los No Terminales
                new Primeros("programa",new List<string>() { "if", "repeat", "identificador", "read", "write"}),
                new Primeros("secuencia-sent",new List<string>() { "if", "repeat", "identificador", "read", "write"}),
                new Primeros("sentencia",new List<string>() { "if", "repeat", "identificador", "read", "write"}),
                new Primeros("sent-if",new List<string>() { "if"}),
                new Primeros("sent-repeat",new List<string>() { "repeat"}),
                new Primeros("sent-assign",new List<string>() { "identificador"}),
                new Primeros("sent-read",new List<string>() { "read"}),
                new Primeros("sent-write",new List<string>() { "write"}),
                new Primeros("exp",new List<string>() { "(", "numero", "identificador"}),
                new Primeros("exp-simple",new List<string>() { "(", "numero", "identificador"}),
                new Primeros("op-comp",new List<string>() { "<", ">", "="}),
                new Primeros("opsuma",new List<string>() { "+", "-"}),
                new Primeros("term",new List<string>() { "(", "numero", "identificador"}),
                new Primeros("opmult",new List<string>() { "*", "/"}),
                new Primeros("factor",new List<string>() { "(", "numero", "identificador"}),
            };
        }

        private void Siguiente()
        {
            List_Siguientes = new List<Siguientes>()
            {
                new Siguientes("programa",new List<string>() { "$"}),
                new Siguientes("secuencia-sent",new List<string>() { ";", "end", "else", "until", "$"}),
                new Siguientes("sentencia",new List<string>() { ";", "end", "else", "until", "$"}),
                new Siguientes("sent-if",new List<string>() { ";", "end", "else", "until", "$"}),
                new Siguientes("sent-repeat",new List<string>() { ";", "end", "else", "until", "$"}),
                new Siguientes("sent-assign",new List<string>() { ";", "end", "else", "until", "$"}),
                new Siguientes("sent-read",new List<string>() { ";", "end", "else", "until", "$"}),
                new Siguientes("sent-write",new List<string>() { ";", "end", "else", "until", "$"}),
                new Siguientes("exp",new List<string>() { ";", "end", "else", "until", "$", "then", ")"}),
                new Siguientes("exp-simple",new List<string>() { ";", "end", "else", "until", "$", "then", ")", "<", ">", "=", "+", "-"}),
                new Siguientes("op-comp",new List<string>() { "(", "numero", "identificador"}),
                new Siguientes("opsuma",new List<string>() { "(", "numero", "identificador"}),
                new Siguientes("term",new List<string>() { ";", "end", "else", "until", "$", "then", ")", "<", ">", "=", "+", "-", "*", "/"}),
                new Siguientes("opmult",new List<string>() { "(", "numero", "identificador"}),
                new Siguientes("factor",new List<string>() { ";", "end", "else", "until", "$", "then", ")", "<", ">", "=", "+", "-", "*", "/"}),
            };
        }

        private void Siguiente2()
        {
            List_Siguientes = new List<Siguientes>()
            {
                new Siguientes("S",new List<string>() {"$"}),
                new Siguientes("B",new List<string>() { "$"}),
                new Siguientes("D",new List<string>() { "$"}),
            };
        }

        private void Siguiente3()
        {
            List_Siguientes = new List<Siguientes>()
            {
                new Siguientes("A",new List<string>() {"$", "b", "c"}),
                new Siguientes("D",new List<string>() { "$", "b", "c"}),
            };
        }
    }
}