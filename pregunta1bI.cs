
using System;
using System.Collections.Generic;

namespace Pregunta1bI
{
    public interface ISecuencia<T> 
    {
        void agregar(T elemento);
        T remover();
        bool vacio();
    }

    public class Pila<T> : ISecuencia<T>
    {
        private List<T> elementos =  new() List<T>();

        public void agregar(T elemento){
            elementos.Add(elemento);
        }

        public T remover(){
            if (elementos.Count == 0){
                throw new InvalidOperationException("La pila esta vacia");
            }

            // Obtenemos el ultimo elemento agregado a la pila
            T ultElem = elementos[elementos.Count - 1];

            // Lo eliminamos de la lista
            elementos.RemoveAt(elementos.Count - 1);

            return ultElem;
        }
        
        public bool vacio(){

            return elementos.Count == 0;
        }
    }

    public class Cola<T> : ISecuencia<T>
    {
        private List<T> elementos = new() List<T>();

        public void agregar(T elemento){
                elementos.Add(elemento);
        }
            
        public T remover(){
            if (elementos.Count == 0){
                throw new InvalidOperationException("La cola esta vacia");
            }

            // Obtenemos el primer elemento agregado a la cola
            T primElem = elementos[0];

            // Lo eliminamos de la lista
            elementos.RemoveAt(0);

            return primElem;
        }

        public bool vacio(){
            return elementos.Count == 0;
        }

    }
}