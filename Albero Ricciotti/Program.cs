using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albero_Ricciotti
{
    class Program
    {
        static void Main(string[] args)
        {

            AlberoBinarioIntero radice = new AlberoBinarioIntero();

            radice.inserisci(69);
            radice.inserisci(89);
            radice.inserisci(28);
            radice.inserisci(39);
            radice.inserisci(66);
            radice.inserisci(44);
            radice.inserisci(12);
            radice.inserisci(2);
            radice.inserisci(71);

            Console.WriteLine(radice);

            Console.ReadKey();
        }

        public class AlberoBinarioIntero
        {
            private int val;
            private AlberoBinarioIntero dx;
            private AlberoBinarioIntero sx;
            private int depth;
            private static int depthMax = 0;

            public AlberoBinarioIntero()
            {
                this.val = 0;

            }

            public bool inserisci(int n)
            {


                if (this.val == 0)
                {
                    this.val = n;

                    return true;
                }
                else if (this.val > n)
                {
                    if (dx == null)
                    {
                        dx = new AlberoBinarioIntero();
                        sx = new AlberoBinarioIntero();
                    }
                    sx.depth = this.depth + 1;
                    if (sx.depth > depthMax)
                    {
                        depthMax = sx.depth;
                    }
                    return sx.inserisci(n);
                }
                else if (this.val <= n)
                {
                    if (dx == null)
                    {
                        dx = new AlberoBinarioIntero();
                        sx = new AlberoBinarioIntero();
                    }
                    dx.depth = this.depth + 1;
                    if (dx.depth > depthMax)
                    {
                        depthMax = dx.depth;
                    }
                    return dx.inserisci(n);
                }
                return false;
            }

            public override string ToString()
            {

                Stack<AlberoBinarioIntero> pila = new Stack<AlberoBinarioIntero>();
                AlberoBinarioIntero testa = this;
                AlberoBinarioIntero prec = null;
                pila.Push(testa);
                string s = "";
                int conta = 0;
                while (pila.Count > 0)
                {

                    testa = pila.Pop();
                    if (testa.sx == null && prec.sx!=testa && s!="")
                    {
                        s += testa.val + ")";
                        for (int i = 0; i < conta-1 && pila.Count<2 ; i++)
                        {
                            s += ")";
                        }
                        conta = 0;
                    }
                    else
                    {
                        s += testa.val + " ";
                    }
                    if (testa.dx != null)
                    {
                        
                        pila.Push(testa.dx);
                        prec = testa;
                        conta++;

                    }
                    if (testa.sx != null)
                    {
                        s += "(";
                        pila.Push(testa.sx);
                    }
                    s += "";

                }

                return  s+")";



                //if (dx != null && sx != null)
                //{
                //    return this.val + "(" + sx + "," + dx + ")";

                //}
                //else if (sx == null && dx == null)
                //{
                //    return this.val + "";
                //}
                //else if (sx != null && dx == null)
                //{
                //    return this.val + "(" + sx + "," + 0 + ")";
                //}
                //else
                //{
                //    return this.val + "(" + 0 + "," + dx + ")";
                //}
            }
        }
    }
}
