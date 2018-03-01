using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinarioBu
{
    /// <summary>
    /// Nodo de Arbol BB
    /// </summary>
    /// <typeparam name="T">Tipo de Dato </typeparam>
    public class Nodo<T>
    {
        /// <summary>
        /// Nodo Hijo Derecho
        /// </summary>
        public Nodo<T> derecho;
        /// <summary>
        /// Nodo Hijo Izquierdo
        /// </summary>
        public Nodo<T> izquierdo;
        /// <summary>
        /// Valor del Nodo
        /// </summary>
        public T valor;

        /// <summary>
        /// Constructor de Nodo de Arbol BB
        /// </summary>
        /// <param name="value">Valor del Nodo</param>
        /// <param name="izquierdo">Nodo Hijo Izquierdo</param>
        /// <param name="derecho">Nodo Hijo Derecho</param>
        public Nodo(T value, Nodo<T> izquierdo, Nodo<T> derecho)
        {
            this.derecho = derecho;
            this.izquierdo = izquierdo;
            this.valor = value;
        }

        /// <summary>
        /// Determina si el nodo es un Nodo Hoja
        /// </summary>
        /// <returns></returns>
        public bool EsHoja()
        {
            return derecho == null && izquierdo == null;
        }

        /// <summary>
        /// Determina si un nodo tiene 2 hijos
        /// </summary>
        /// <returns></returns>
        public bool Lleno()
        {
            return derecho != null && izquierdo != null;
        }
    }
}