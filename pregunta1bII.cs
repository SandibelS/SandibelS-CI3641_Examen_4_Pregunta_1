using System;
using System.Collections.Generic;

namespace Pregunta1bII 
{
    public class GrafoListaAdyacencia
    {
        public List<List<int>> listaAdyacencia;

        public GrafoListaAdyacencia(int numNodos)
        {
            listaAdyacencia = new List<List<int>>(numNodos);
            for (int i = 0; i < numNodos; i++)
            {
                listaAdyacencia.Add(new List<int>());
            }
        }

         public void AgregarArista(int origen, int destino)
        {
            listaAdyacencia[origen].Add(destino);
        }

        public bool ExisteArista(int origen, int destino)
        {
            return listaAdyacencia[origen].Contains(destino);
        }
        
        public int cantidad_nodos(){
            return listaAdyacencia.Count;
        }
    }

    public abstract class Busqueda
    {
        public abstract int buscar(GrafoListaAdyacencia grafo, int D, int H);
    }

    public class BSF : Busqueda
    {
        public override int  buscar(GrafoListaAdyacencia grafo, int D, int H)
        {
            int nodosExplorados = 0;
            Queue<int> cola = new Queue<int>();
            bool[] visitados = new bool[grafo.cantidad_nodos()];

            cola.Enqueue(D);
            visitados[D] = true;

            while (cola.Count > 0)
            {
                int nodoActual = cola.Dequeue();
                nodosExplorados++;

                if (nodoActual == H)
                {
                    return nodosExplorados;
                }

                foreach (int vecino in grafo.listaAdyacencia[nodoActual])
                {
                    if (!visitados[vecino])
                    {
                        cola.Enqueue(vecino);
                        visitados[vecino] = true;
                    }
                }
            }

            return -1;
                
        }

    }

    public class DFS : Busqueda
    {
        public override int buscar(GrafoListaAdyacencia grafo, int D, int H)
        {
            int nodosExplorados = 0;
            Stack<int> pila = new Stack<int>();
            bool[] visitados = new bool[grafo.cantidad_nodos()];

            pila.Push(D);
            visitados[D] = true;

            while (pila.Count > 0)
            {
                int nodoActual = pila.Pop();
                nodosExplorados++;

                if (nodoActual == H)
                {
                    return nodosExplorados;
                }

                foreach (int vecino in grafo.listaAdyacencia[nodoActual])
                {
                    if (!visitados[vecino])
                    {
                        pila.Push(vecino);
                        visitados[vecino] = true;
                    }
                }
            }
        }
    }
}