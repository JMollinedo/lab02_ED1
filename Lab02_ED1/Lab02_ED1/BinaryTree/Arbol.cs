using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinarioBu
{
    /// <summary>
    /// Arbol BB
    /// </summary>
    /// <typeparam name="T">Tipo de Dato en Arbol</typeparam>
    public class Arbol<T> where T : IComparable
    {
        /// <summary>
        /// Nodo Raiz
        /// </summary>
        public Nodo<T> root;

        /// <summary>
        /// Constructor de Arbol BB
        /// </summary>
        public Arbol()
        {
            root = null;
        }

        /// <summary>
        /// Inserta un Nuevo Nodo en Arbol
        /// </summary>
        /// <param name="valor">Valor Nodo Nuevo</param>
        public void Insertar(T valor)
        {
            Nodo<T> nuevo = new Nodo<T>(valor, null, null);
            if (root == null)
            {
                root = nuevo;
            }
            else
            {
                InsertarHijo(nuevo, root);
            }
        }

        /// <summary>
        /// Metodo Recursivo de Insercion
        /// </summary>
        /// <param name="nuevo">Nodo Nuevo</param>
        /// <param name="padre">Nodo Padre del Nodo Nuevo</param>
        private void InsertarHijo(Nodo<T> nuevo, Nodo<T> padre)
        {
            if (padre != null)
            {
                if (nuevo.valor.CompareTo(padre.valor) < 0)
                {
                    if (padre.izquierdo == null)
                    {
                        padre.izquierdo = nuevo;
                    }
                    else
                    {
                        InsertarHijo(nuevo, padre.izquierdo);
                    }
                }
                else if (nuevo.valor.CompareTo(padre.valor) > 0)
                {
                    if (padre.derecho == null)
                    {
                        padre.derecho = nuevo;
                    }
                    else
                    {
                        InsertarHijo(nuevo, padre.derecho);
                    }
                }
                else
                {
                    throw new Exception("Valor ya Ingresado");
                }
                
            }
        }

        /// <summary>
        /// Eliminar la primera apracición de un valor en el Arbol
        /// </summary>
        /// <param name="valor">Valor a Eliminar</param>
        /// <returns>Nodo Eliminado</returns>
        public Nodo<T> Eliminar(T valor)
        {
            Nodo<T> auxiliar = root;
            Nodo<T> padre = root;
            bool esHijoIzquierdo = true;
            while (auxiliar.valor.CompareTo(valor) != 0)
            {
                padre = auxiliar;
                if (valor.CompareTo(auxiliar.valor) <= 0)
                {
                    esHijoIzquierdo = true;
                    auxiliar = auxiliar.izquierdo;
                }
                else
                {
                    esHijoIzquierdo = false;
                    auxiliar = auxiliar.derecho;
                }
                if (auxiliar == null)
                {
                    return null;
                }
            }// Fin ciclo inicial

            if (auxiliar.izquierdo == null && auxiliar.derecho == null)
            {
                if (auxiliar == root)
                {
                    root = null;
                }
                else if (esHijoIzquierdo)
                {
                    padre.izquierdo = null;
                }
                else
                {
                    padre.derecho = null;
                }
            }
            else if (auxiliar.derecho == null)
            {
                if (auxiliar == root)
                {
                    root = auxiliar.izquierdo;
                }
                else if (esHijoIzquierdo)
                {
                    padre.izquierdo = auxiliar.izquierdo;
                }
                else
                {
                    padre.derecho = auxiliar.izquierdo;
                }
            }
            else if (auxiliar.izquierdo == null)
            {
                if (auxiliar == root)
                {
                    root = auxiliar.derecho;
                }
                else if (esHijoIzquierdo)
                {
                    padre.izquierdo = auxiliar.derecho;
                }
                else
                {
                    padre.derecho = auxiliar.derecho;
                }
            }
            else
            {
                Nodo<T> reemplazo = Reemplazar(auxiliar);
                if (auxiliar == root)
                {
                    root = reemplazo;
                }
                else if (esHijoIzquierdo)
                {
                    padre.izquierdo = reemplazo;
                }
                else
                {
                    padre.derecho = reemplazo;
                }
                reemplazo.izquierdo = auxiliar.izquierdo;

            }
            return auxiliar;
        }

        /// <summary>
        /// Elimina un Nodo mediante sustitucion
        /// </summary>
        /// <param name="NodoEliminar">Nodo a Eliminar </param>
        /// <returns>Nodo de Reemplazo</returns>
        private Nodo<T> Reemplazar(Nodo<T> NodoEliminar)
        {
            Nodo<T> remplazoPadre = NodoEliminar;
            Nodo<T> reemplazo = NodoEliminar;
            Nodo<T> auxiliar = NodoEliminar.derecho;
            while (auxiliar != null)
            {
                remplazoPadre = reemplazo;
                reemplazo = auxiliar;
                auxiliar = auxiliar.izquierdo;
            }
            if (reemplazo != NodoEliminar.derecho)
            {
                remplazoPadre.izquierdo = reemplazo.derecho;
                reemplazo.derecho = NodoEliminar.derecho;
            }
            return reemplazo;
        }

        /// <summary>
        /// Encuentra Nodo con la primera aparicion de un valor en el Arbol
        /// </summary>
        /// <param name="value">Valor buscado</param>
        /// <returns>Nodo con valor buscado</returns>
        Nodo<T> Encontrar(T value)
        {
            Nodo<T> auxiliar = root;
            while (auxiliar.valor.CompareTo(value) != 0)
            {
                if (value.CompareTo(auxiliar.valor) < 0)
                {
                    auxiliar = auxiliar.izquierdo;
                }
                else
                {
                    auxiliar = auxiliar.derecho;
                }
                if (auxiliar == null)
                {
                    return null;
                }
            }
            return auxiliar;
        }

        /// <summary>
        /// Determina si el arbol tiene datos
        /// </summary>
        /// <returns></returns>
        bool IsEmpty()
        {
            return root == null;
        }

        private void PreOrder(Nodo<T> Aux, ref List<T> Elements)
        {
            if (Aux != null)
            {
                Elements.Add(Aux.valor);
                PreOrder(Aux.izquierdo, ref Elements);
                PreOrder(Aux.derecho, ref Elements);
            }
        }
        private void InOrder(Nodo<T> Aux, ref List<T> Elements)
        {
            if (Aux != null)
            {
                InOrder(Aux.izquierdo, ref Elements);
                Elements.Add(Aux.valor);
                InOrder(Aux.derecho, ref Elements);
            }
        }
        private void PostOrder(Nodo<T> Aux, ref List<T> Elements)
        {
            if (Aux != null)
            {
                PostOrder(Aux.izquierdo, ref Elements);
                PostOrder(Aux.derecho, ref Elements);
                Elements.Add(Aux.valor);
            }
        }

        public List<T> Orders(string Order)
        {
            List<T> Elements = new List<T>();
            switch (Order)
            {
                case "PreOrder":
                    PreOrder(root, ref Elements);
                    break;
                case "InOrder":
                    InOrder(root, ref Elements);
                    break;
                case "PostOrder":
                    PostOrder(root, ref Elements);
                    break;
            }
            return Elements;
        }

        /// <summary>
        /// Altura del Arbol
        /// </summary>
        public int Altura
        {
            get
            {
                return setAltura(root);
            }
        }

        /// <summary>
        /// Funcion recursiva que determina la altura de del Arbol
        /// </summary>
        /// <param name="actual">Nodo Raiz</param>
        /// <returns>Altura de Arbol con Nodo Raiz</returns>
        private int setAltura(Nodo<T> actual)
        {
            return 0;
        }
    }
}
