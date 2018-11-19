using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DrawFormPrueba
{
    class BellmanFord
    {
        List<Path> graph = new List<Path>();
        List<string> vertices = new List<string>();
        Dictionary<string, int> memo = new Dictionary<string, int>();
        class Path
        {
            public string From;
            public string To;
            public int Cost;

            public Path(string from, string to, int cost)
            {
                From = from;
                To = to;
                Cost = cost;
            }
        }
        public void CrearGrafo(List<Lineas> lineasGrafo)
        {

            int contador = 0;
            foreach (Lineas l in lineasGrafo)
            {
              


                    if (contador == 0)
                    {
                        vertices.Add(l.getCiudad0());
                        vertices.Add(l.getCiudad1());
                        memo.Add(l.getCiudad0(), 0);
                        memo.Add(l.getCiudad1(), int.MaxValue);
                        graph.Add(new Path(l.getCiudad0(), l.getCiudad1(), l.getCosto2()));

                      
                    }
                    if (contador > 0)
                    {
                        vertices.Add(l.getCiudad0());
                        vertices.Add(l.getCiudad1());
                    //  memo.Add(l.getCiudad0(), int.MaxValue);
                    try { 
                        memo.Add(l.getCiudad1(), int.MaxValue);
                    }catch(Exception e)
                    {
                        //nodo repetido xd
                    }
                        graph.Add(new Path(l.getCiudad0(), l.getCiudad1(), l.getCosto2()));
                    }
                    contador++;
            
            }


           
        }

            public bool Iterate()
            {
                bool doItAgain = false;

                foreach (var fromVertex in vertices)
                {
                    Path[] edges = graph.Where(x => x.From == fromVertex).ToArray();
                    foreach (var edge in edges)
                    {
                        int potentialCost = memo[edge.From] == int.MaxValue ? int.MaxValue : memo[edge.From] + edge.Cost;
                        if (potentialCost < memo[edge.To])
                        {
                            memo[edge.To] = potentialCost;
                            doItAgain = true;
                        }
                    }
                }
                return doItAgain;
            }

            public string getResults()
            {
                for (int i = 0; i < vertices.Count; i++)
                {
                    if (!Iterate())
                        break;
                }
            string megaString = "Bellman Ford: La ruta menos costosa es :" +"\n";

            foreach (var keyValue in memo)
                {
               
                   megaString = megaString + ($"{keyValue.Key}: {keyValue.Value}" + " ") + "\n";
                }

            foreach(Path p in graph)
            {
               // megaString = megaString + "//Rutas//";
              //  megaString = megaString + " " + p.From + " a " + p.To + " : " + p.Cost + "/";
            }
            return megaString;
            }
        }
    }

