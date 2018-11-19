using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFormPrueba
{

    class Prim
    {
        List<Lineas> Q;
        List<Lineas> lineasFull;
        readonly int kInfinite = int.MaxValue - 1;

        /*public static List<Lineas> GetNeighbors(List<Lineas> Q)
        {
            return Q.ConvertAll(e => e.getCosto2());
        }*/

        public void prim(List<Lineas> xd, Lineas r, ref Dictionary<Lineas, Lineas> tree)
            {
            List<Lineas> Q = xd;
            List<Lineas> lineasFull = xd;
                var d = new Dictionary<Lineas, int>();
                foreach (var u in Q)
                {
                    d[u] = kInfinite;
                }
                d[r] = 0;

                while (Q.Count > 0)
                {
                    var u = deleteMin(Q, d);
                    foreach (var v in lineasFull)
                    {
                        if (Q.Contains(v) && (u.getCosto2() < d[v]))
                        {
                            d[(v)] = u.getCosto2();
                            tree[v] = u;
                        }
                    }
                }
            }

            private Lineas deleteMin(List<Lineas> Q, Dictionary<Lineas, int> d)
            {
                Lineas min_node = null;
                int min_weight = kInfinite;
                foreach (var n in Q)
                {
                    if (d[n] <= min_weight)
                    {
                        min_weight = d[n];
                        min_node = n;
                    }
                }
                Q.Remove(min_node);
                return min_node;
            }

        }
    
}
