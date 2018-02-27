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
        /// <param name="value">Valor Nodo Nuevo</param>
        public void Insertar(T value)
        {
            Nodo<T> newnode = new Nodo<T>(value, null, null, 0);
            if (root == null)
            {
                root = newnode;
            }
            else
            {
                InsertarHijo(newnode, root);
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
                if (nuevo.valor.CompareTo(padre.valor) <= 0)
                {
                    if (padre.izquierdo == null)
                    {
                        nuevo.nivel = padre.nivel + 1;
                        padre.izquierdo = nuevo;
                    }
                    else
                    {
                        InsertarHijo(nuevo, padre.izquierdo);
                    }
                }
                else
                {
                    if (nuevo.valor.CompareTo(padre.valor) > 0)
                    {
                        if (padre.derecho == null)
                        {
                            nuevo.nivel = padre.nivel + 1;
                            padre.derecho = nuevo;
                        }
                        else
                        {
                            InsertarHijo(nuevo, padre.derecho);
                        }
                    }
                }
            }
        }

        /* 
         * - Añadir la forma en la que cambia la propiedad Nivel en los 
         *   nodos del arbol al ejeutar la eliminacion de un nodo
         * - Esta Propiedad se utiliza para determinar la altura del Arbol
         * - Si hay una mejor implementacion para determinar la altura del
         *   Arbol, modificar el metodo y la Propiedad
         */
        /// <summary>
        /// Eliminar la primera apracición de un valor en el Arbol
        /// </summary>
        /// <param name="valor">Valor a Eliminar</param>
        /// <returns>Nodo Eliminado</returns>
        public Nodo<T> Eliminar(T valor)
        {
            Nodo<T> auxiliar = root;
            Nodo<T> padre = root;
            bool esHijoIz = true;
            while (auxiliar.valor.CompareTo(valor) != 0)
            {
                padre = auxiliar;
                if (valor.CompareTo(auxiliar.valor) <= 0)
                {
                    esHijoIz = true;
                    auxiliar = auxiliar.izquierdo;
                }
                else
                {
                    esHijoIz = false;
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
                else if (esHijoIz)
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
                else if (esHijoIz)
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
                else if (esHijoIz)
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
                else if (esHijoIz)
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
        /// <param name="Nodoelmiminar">Nodo a Eliminar </param>
        /// <returns>Nodo de Reemplazo</returns>
        private Nodo<T> Reemplazar(Nodo<T> Nodoelmiminar)
        {
            Nodo<T> reemplazopadre = Nodoelmiminar;
            Nodo<T> reemplazo = Nodoelmiminar;
            Nodo<T> auxiliar = Nodoelmiminar.derecho;
            while (auxiliar != null)
            {
                reemplazopadre = reemplazo;
                reemplazo = auxiliar;
                auxiliar = auxiliar.izquierdo;
            }
            if (reemplazo != Nodoelmiminar.derecho)
            {
                reemplazopadre.izquierdo = reemplazo.derecho;
                reemplazo.derecho = Nodoelmiminar.derecho;
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
        #region Eliminaré esto
        /*
        /// <summary>
        /// Recorre el arbol siguiendo el orden infijo
        /// </summary>
        /// <returns>Contenido del arbol como una cadena de caracteres</returns>
        public string Infijo()
        {
            string contenido = string.Empty;
            Infijo(root, ref contenido);
            return contenido;
        }

        /// <summary>
        /// Funcion recursiva que recorre el arbol en orden infijo
        /// </summary>
        /// <param name="raiz">Nodo Raiz</param>
        /// <param name="contenido">Cadena de caracteres con el contenido del arbol</param>
        private void Infijo(Nodo<T> raiz, ref string contenido)
        {
            if (raiz != null)
            {
                Infijo(raiz.izquierdo, ref contenido);
                contenido += raiz.valor.ToString() + "\n";
                Infijo(raiz.derecho, ref contenido);
            }
        }

        /// <summary>
        /// Recorre el arbol siguendo el orden postfijo
        /// </summary>
        /// <returns>Contenido del arbol como una cadena de caracteres</returns>
        public string Postfijo()
        {
            string contenido = string.Empty;
            Postfijo(root, ref contenido);
            return contenido;
        }

        /// <summary>
        /// Funcion recursiva que recorre el arbol en orden postfijo
        /// </summary>
        /// <param name="raiz">Nodo Raiz</param>
        /// <param name="contenido">Cadena de caracteres con el contenido del arbol</param>
        private void Postfijo(Nodo<T> raiz, ref string contenido)
        {
            if (raiz != null)
            {
                Postfijo(raiz.izquierdo, ref contenido);
                Postfijo(raiz.derecho, ref contenido);
                contenido += raiz.valor.ToString() + "\n";
            }
        }

        /// <summary>
        /// Recorre el arbol siguiendo el orden prefijo
        /// </summary>
        /// <returns>Contenido del arbol como una cadena de caracteres</returns>
        public string Prefijo()
        {
            string contenido = string.Empty;

            return contenido;
        }

        /// <summary>
        /// Funcion recursiva que recore el arbol en orden prefijo
        /// </summary>
        /// <param name="raiz">Nodo Raiz</param>
        /// <param name="contenido">Cadena de caracteres con el contenido del arbol</param>
        private void Prefijo(Nodo<T> raiz, ref string contenido)
        {
            contenido += raiz.valor.ToString() + "\n";
            Prefijo(raiz.izquierdo, ref contenido);
            Prefijo(raiz.derecho, ref contenido);
        }*/
        #endregion

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
                    /*case "LeafNodes":
                        GetLeafNodes(Root, ref Elements);
                        break;
                    case "OnlyChild":
                        OnlyChild(Root, ref Elements);
                        break;*/


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
            if (actual != null)
            {
                return Math.Max
                    (actual.nivel,
                    Math.Max(setAltura(actual.izquierdo), setAltura(actual.derecho)));
            }
            else
            {
                return 0;
            }
        }
    }
}
