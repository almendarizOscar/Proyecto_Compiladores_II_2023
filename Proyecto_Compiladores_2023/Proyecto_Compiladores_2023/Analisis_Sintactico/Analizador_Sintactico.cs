using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Proyecto_Compiladores_2023.Analisis_Sintactico
{
    internal class Analizador_Sintactico
    {
        private List<string> w; //Lista de la cadena de elementos de la cadena W
        private Stack<EstadoLR> pila = new Stack<EstadoLR>(); //pila de estados
        private DataGridView T_Accion;
        private DataGridView T_ir_A;
        private int a = 0;
        private System.Windows.Forms.TreeView arbol;
        public string Error = "s/n";

        public Analizador_Sintactico(List<string> w, DataGridView accion, DataGridView ir, System.Windows.Forms.TreeView a)
        {
            this.w = w;
            T_Accion = accion;
            T_ir_A = ir;
            arbol= a;   
            Analizar();
        }

        private void Analizar() 
        {
            List<EstadoLR> estado = GeneradorDeColeccionCanonica.automata.estado;
            pila.Push(estado[0]);//apunta al tope de la pila sin eliminarlo de ella
            EstadoLR s;
            ExpresionFormalDeG G = GeneradorDeColeccionCanonica.G_aumentada;
            List<TreeNode> auxiliarArbol;
            int apuntadorParaArbol = -1;//El apuntdaor apunta una posicion antes de la cadena
            List<TreeNode> listaArbolAnalisis = new List<TreeNode>();

            foreach(string w_aux in w)
            {
                if(w_aux != "$")
                {
                    listaArbolAnalisis.Add(new TreeNode(w_aux));
                }
            }

            while (true)
            {
                s = pila.Peek();
                string aux = "";
                aux = Accion(s.id, w[a]);
                if (aux[0].Equals('d') == true)//Inciso de desplazar
                {
                    string aux1 = "";
                    for(int i = 1; i<aux.Length; i++)
                    {
                        aux1 += aux[i];
                    }
                    int t = int.Parse(aux1.ToString());
                    pila.Push(estado[t]);
                    apuntadorParaArbol++;//se dezplaza el apuntador del arbol
                    a++;
                }
                else if(aux[0].Equals('r') == true)//Inciso de reduccion
                {
                    string aux2 = "";
                    for (int i = 1; i < aux.Length; i++)
                    {
                        aux2 += aux[i];
                    }
                    int r = int.Parse(aux2.ToString());
                    int longitud = G.P[r].cuerpo.Count();

                    if (pila.Count() > longitud)//verifica que la pila no este vacia y si esta marca error
                    {
                        for (int i = 0; i < longitud; i++)//sacamos la cantidad de beta simbolos
                        {
                            pila.Pop();
                        }

                        EstadoLR t = pila.Peek();
                        int estado_num = ir_A(t.id, G.P[r].NoTerminal);
                        if(estado_num != -1)
                        {
                            pila.Push(estado[estado_num]);
                        }
                        else
                        {
                            Error = w[a];
                            break;
                        }
                        
                    }
                    else
                    {
                        Error = w[a];
                        break;
                    }
                    
                    apuntadorParaArbol = apuntadorParaArbol - longitud + 1 ;  //parte para saber el numero de lineas que va a tener de salida la produccion
                    auxiliarArbol = listaArbolAnalisis.GetRange(apuntadorParaArbol, longitud);  //copiamos los elementos desde donde esta apuntando el arbol hasta el numero de beta simbolos en un auxiliar 
                    listaArbolAnalisis.RemoveRange(apuntadorParaArbol, longitud);  //quitamos los elementos 
                    listaArbolAnalisis.Insert(apuntadorParaArbol, new TreeNode(G.P[r].NoTerminal, auxiliarArbol.ToArray()));  //los insertamos al nuevo arbol final 
                }
                else if(aux[0].Equals('A') == true)//Inciso de aceptar
                {
                    arbol.Nodes.Clear();
                    arbol.BeginUpdate();
                    arbol.Nodes.AddRange(listaArbolAnalisis.ToArray());
                    arbol.EndUpdate();
                    arbol.ExpandAll();
                    break;
                }
                else
                {
                    Error = w[a];
                    break;
                }
            }


        }


        private string Accion(int s, string a)
        {
            int pos = -1;
            if (a.Equals("$") == true)
            {
                pos = T_Accion.ColumnCount-1;
            }
            else
            {
               pos = GeneradorDeColeccionCanonica.G_aumentada.Terminal.IndexOf(a) + 1;
                
            }

            if (T_Accion?.Rows[s]?.Cells[pos]?.Value?.ToString() == null)
            {
                return " ";//Devuelvel el error 
            }
            else
                return T_Accion.Rows[s].Cells[pos].Value.ToString();//devuelve si es desplazar, resucir o aceptar
        }

        private int ir_A(int t, string A)
        {
            int pos = GeneradorDeColeccionCanonica.G_aumentada.NoTerminal.IndexOf(A) +1;
           if(T_ir_A.Rows[t]?.Cells[pos]?.Value?.ToString() == null)
           {
                return -1;
           }
           else
           {
                return int.Parse(T_ir_A.Rows[t].Cells[pos].Value.ToString());
            }
              
        }
    }//internal
}//namespace
