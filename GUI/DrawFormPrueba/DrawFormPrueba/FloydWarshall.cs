using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DrawFormPrueba
{
    class FloydWarshall
    {

        List<Lineas> lineas = new List<Lineas>();
            public const int cst = 9999;

        

            public static void Print(int[,] distance, int verticesCount)
            {
           
            string MegaString = "Floyd Warshall: Distancia mas corta entre cada par de vertices";

                for (int i = 0; i < verticesCount; ++i)
                {
                    for (int j = 0; j < verticesCount; ++j)
                    {
                    if (distance[i, j] == cst)
                    {
                        
                        MegaString = MegaString + ("cst".PadLeft(7));
                       
                    }
                    else
                    {
                        MegaString = MegaString + (distance[i, j].ToString().PadLeft(7));
                      
                    }
                    }

              
                }
            MessageBox.Show(MegaString);
        }

            public static void FloydWarshallMain(int[,] graph, int verticesCount)
            {
                int[,] distance = new int[verticesCount, verticesCount];

                for (int i = 0; i < verticesCount; ++i)
                    for (int j = 0; j < verticesCount; ++j)
                        distance[i, j] = graph[i, j];

                for (int k = 0; k < verticesCount; ++k)
                {
                    for (int i = 0; i < verticesCount; ++i)
                    {
                        for (int j = 0; j < verticesCount; ++j)
                        {
                            if (distance[i, k] + distance[k, j] < distance[i, j])
                                distance[i, j] = distance[i, k] + distance[k, j];
                        }
                    }
                }

                Print(distance, verticesCount);
            }
            public void Mains(List<Lineas> lineasR)
            {
           lineas= lineasR;
          
            //obteniendo tamano de matris
            List<string> ciudades = new List<string>();

           
            foreach (Lineas p in lineas)
            {
                var city1 = true;
                var city2 = true;
                foreach (string s in ciudades)
                {
                    
                        if (s == p.getCiudad0())
                        {
                            city1 = false;
                        }
                        if (s == p.getCiudad1())
                        {
                            city2 = false;
                        }
                }

                if (city1 == true)
                    ciudades.Add(p.getCiudad0());

                if (city2 == true)
                    ciudades.Add(p.getCiudad1());
            }

            int tamanoMatrix = ciudades.Count;

            int contador = 0;

            
          
            //Asignar ID's
            foreach (string s in ciudades)
            {

                foreach (Lineas l in lineas)
                {
                    if (l.getCiudad0() == s)
                    {
                            l.setId(contador);
                           
                    }
                    if (l.getCiudad1() == s)
                    {
                        l.setId1(contador);
                           
                    }
                }
                contador++;
            }

            //creo el grafo segun la cantidad de ciudades
            int[,] nuevograph = new int[tamanoMatrix, tamanoMatrix];
             
            //inicializo el grafo con cst y 0 en la diagonal
            for (int i = 0; i < tamanoMatrix; i++)
            {
                for (int j = 0; j < tamanoMatrix; j++)
                {
                    if(i ==j)
                    {
                     nuevograph[i, j] = 0;
                    }
                    else
                    {
                    nuevograph[i,j] = cst;
                    }
                }
            }

            //Asignar los pesos en cada valor de la matriz
            for (int i = 0; i < lineas.Count; i++)
            {
               nuevograph[lineas.ElementAt(i).getId(), lineas.ElementAt(i).getId1()] = lineas.ElementAt(i).getCosto2();    
            }


            FloydWarshallMain(nuevograph, tamanoMatrix);

            //antiguo grafo de prueba
            /* int[,] graph = {
                        { 0,   6,  cst, 11 },
                        { cst, 0,   4, cst },
                        { cst, cst, 0,   2 },
                        { cst, cst, cst, 0 }
                          };

              */
        }


    }
}
