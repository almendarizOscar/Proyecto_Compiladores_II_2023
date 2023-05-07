using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Compiladores_2023.Analisis_Sintactico
{
    internal class Analisis
    {
        public List<Siguientes> List_Siguientes; //aqui se cargan los siguintes
        public AutomataLR automata;
        public List<I> C;//conjunto de colecciones (estado = {[colecion],[coleccion]}
        public ExpresionFormalDeG Gramatica;
        private DataGridView t_Accion, t_Ir_A;
        public Analisis(ExpresionFormalDeG G, DataGridView t_Accion, DataGridView t_Ir_A)
        {
            Cargar_Prim_SIg Estructura = new Cargar_Prim_SIg();
            List_Siguientes = Estructura.List_Siguientes;
            automata = GeneradorDeColeccionCanonica.automata;
            C = GeneradorDeColeccionCanonica.C;
            Gramatica = G;
            this.t_Accion = t_Accion;
            this.t_Ir_A = t_Ir_A;
            Recorrer_EstadosI();
            Tabla_Ir_A();
        }


        //Este metodo se encarga de llenar la tabla de ACCION
        private void Recorrer_EstadosI()
        {
            foreach (I estado in C)//bucle para recorres los estdos de C
            {
                List<Produccion> l = estado.elemento;
                foreach (Produccion p in l)//blucle para recorrer los elementos del estado
                {
                    int x = Hay_un_Terminal_despues_del_punto_o_el_punto_es_el_ultimo(p);
                    //1.-(A->α.aβ)Buscar un Terminal
                    if (x > -1)
                    {
                        Ir_A(estado.id, p.cuerpo[x],0);
                    }

                    //2.-(A->α.) Buscar que el punto este al final y que no sea la aumentada
                    if (x == -2 && p.NoTerminal.Equals(GeneradorDeColeccionCanonica.G_aumentada.SimboloInicial) == false)
                    {
                        //Busca los siguientes de A
                        List<string> sig = Buscar_Siguientes(p.NoTerminal);
                        int n = Numero_Produccion(p);

                        foreach (string s in sig)
                        {
                            Accion(estado.id, s, n);
                        }
                    }

                    //3.-(S'->S.) Buscar el conjunto de la grmatica aumentada con punto al final
                    if (x == -2 && p.NoTerminal.Equals(GeneradorDeColeccionCanonica.G_aumentada.SimboloInicial) == true)
                    {
                        t_Accion.Rows[estado.id].Cells[t_Accion.ColumnCount - 1].Value = "AC";
                    }
                }
            }
        }

        //Este metodo se encarga de relizar las reducciones de los siguientes
        private void Accion(int id, string s, int num_prod)
        {
            if(s.Equals("$") == true)
            {
                t_Accion.Rows[id].Cells[t_Accion.ColumnCount - 1].Value = "r" + num_prod;
            }
            else
            {
                int pos = PosicionTermino(s, 0);
                t_Accion.Rows[id].Cells[pos + 1].Value = "r" + num_prod;
            }            
        }

        private int Numero_Produccion(Produccion p)
        {
            //si el cuerpo tiene solo . se le coloca ε
            if (p.cuerpo[0].Equals(".") == true && p.cuerpo.Count == 1)
            {
                p.cuerpo[0] = "ε";
            }
            else //sino se le borrara el punto que esta al final
            {
                p.cuerpo.RemoveAt(p.cuerpo.Count- 1);
            }

            for (int i = 0; i < Gramatica.P.Count; i++)//recorre la gramatica
            {
                //verifica que el no terminal pertenesca al que buscamos y que tenga
                //la misma cantidad de elementos en el curepo
                if (Gramatica.P[i].NoTerminal.Equals(p.NoTerminal) == true && Gramatica.P[i].cuerpo.Count == p.cuerpo.Count)
                {
                    //recorre el cuerpo verificando que sea los mismos
                    int j;
                    for(j = 0; j < p.cuerpo.Count; j++)
                    {
                        if (p.cuerpo[j].Equals(Gramatica.P[i].cuerpo[j]) == false)
                            break;
                    }

                    if (j == p.cuerpo.Count)
                        return i; //regresa el numero de la gramatica
                }
            }
            return -1;
        }

        private List<string> Buscar_Siguientes(string NoTerminal)
        {
            List<string> lis = new List<string>();
            foreach (Siguientes s in List_Siguientes)
            {
                if(NoTerminal.Equals(s.identificador) == true)
                {
                    return lis = s.conjunto;
                }
            }
            return lis;
        }

        //Método para saber si hay un terminal despues del punto en una producción
        private int Hay_un_Terminal_despues_del_punto_o_el_punto_es_el_ultimo(Produccion p)
        {
            int indice_del_punto = p.cuerpo.FindIndex(x => x == ".");

            //Verificamos si el siguiente simbolo es un No Terminal
            //Si no hay un punto regresa -1
            if (indice_del_punto == -1)
                return -1;
            //Si el unico elemento que hay en el cuerpo es un punto regresa, -2.
            else if (p.cuerpo.Count == 1 && indice_del_punto == 0)
                return -2;
            //Si el punto es el último simbolo de la producción regresa -2.
            else if (indice_del_punto == p.cuerpo.Count - 1)
                return -2;
            else
            {
                string sig_simbolo_despues_del_punto = p.cuerpo[indice_del_punto + 1];
                //informacion.Text += "Posicion del punto : " + indice_del_punto + Environment.NewLine;
                //Ver si el simbolo despues del punto es un No terminal
                if (GeneradorDeColeccionCanonica.G_aumentada.Terminal.FindIndex(x => x == sig_simbolo_despues_del_punto) == -1)
                    return -1;
                else
                    return indice_del_punto + 1;
            }
        }


        //Ir_A para terminales 0, para no terminales 1
        private void Ir_A(int id, string Terminal, int x)
        {
            //Este metodo recorre el automata buscando el estado actual y busca el estado
            //al que se digije con la transicion asignada
            foreach (TransicionLR transicion in GeneradorDeColeccionCanonica.automata.transiciones)
            {
                if ((transicion.estado_inicio.id == id) && (Terminal.CompareTo(transicion.simbolo)) == 0)
                {
                    //se coloca el resultado en la tabla
                    int pos = PosicionTermino(Terminal, 0);
                    t_Accion.Rows[id].Cells[pos + 1].Value = "d" + transicion.estado_siguiente.id;
                }
            }
        }

        //Para terminales 0, para no terminales 1
        private int PosicionTermino(string Terminal, int y)
        {
            //Este metodo se encarga de recorrer la lista de la gramatica
            //para ubicar la posicion del simbolo que se le asigno en la tabla
            if(y == 0)
            {
                for (int i = 0; i < GeneradorDeColeccionCanonica.G_aumentada.Terminal.Count; i++)
                {
                    string t = GeneradorDeColeccionCanonica.G_aumentada.Terminal[i];
                    if (t.CompareTo(Terminal) == 0)
                    {
                        return i;
                    }
                }
            }
            else if (y == 1)
            {
                for (int i = 0; i < GeneradorDeColeccionCanonica.G_aumentada.NoTerminal.Count; i++)
                {
                    string t = GeneradorDeColeccionCanonica.G_aumentada.NoTerminal[i];
                    if (t.CompareTo(Terminal) == 0)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private void Tabla_Ir_A()
        {
            ExpresionFormalDeG exp = new ExpresionFormalDeG();

            foreach (TransicionLR transicion in GeneradorDeColeccionCanonica.automata.transiciones)
            {
                for(int i = 0; i < exp.NoTerminal.Count; i++)
                {
                    if (exp.NoTerminal[i].Equals(transicion.simbolo))
                    {
                        int pos = PosicionTermino(transicion.simbolo, 1);
                        t_Ir_A.Rows[transicion.estado_inicio.id].Cells[pos + 1].Value = transicion.estado_siguiente.id;
                    }
                }
            }
        }
    }
}
