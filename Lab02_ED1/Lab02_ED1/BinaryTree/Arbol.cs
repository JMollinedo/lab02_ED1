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

        // Devuelve una exepción si el valor ya existe en el arbol
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
                if (valor.CompareTo(auxiliar.valor) < 0)
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
            if (auxiliar.EsHoja)
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
                Nodo<T> temp = auxiliar.izquierdo;
                if (auxiliar == root)
                {
                    root = temp;
                }
                else if (esHijoIzquierdo)
                {
                    padre.izquierdo = temp;
                }
                else
                {
                    padre.derecho = temp;
                }
            }
            else if (auxiliar.izquierdo == null)
            {
                Nodo<T> temp = auxiliar.derecho;
                if (auxiliar == root)
                {
                    root = temp;
                }
                else if (esHijoIzquierdo)
                {
                    padre.izquierdo = temp;
                }
                else
                {
                    padre.derecho = temp;
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
        /// <param name="NodoAEliminar">Nodo a Eliminar </param>
        /// <returns>Nodo de Reemplazo</returns>
        private Nodo<T> Reemplazar(Nodo<T> NodoAEliminar)
        {
            Nodo<T> remplazoPadre = NodoAEliminar;
            Nodo<T> reemplazo = NodoAEliminar;
            Nodo<T> auxiliar = NodoAEliminar.derecho;
            while (auxiliar != null)
            {
                remplazoPadre = reemplazo;
                reemplazo = auxiliar;
                auxiliar = auxiliar.izquierdo;
            }
            if (reemplazo != NodoAEliminar.derecho)
            {
                remplazoPadre.izquierdo = reemplazo.derecho;
                reemplazo.derecho = NodoAEliminar.derecho;
            }
            return reemplazo;
        }

        /// <summary>
        /// Encuentra Nodo con la primera aparicion de un valor en el Arbol
        /// </summary>
        /// <param name="value">Valor buscado</param>
        /// <returns>Nodo con valor buscado</returns>
        public Nodo<T> Encontrar(T value)
        {
            Nodo<T> auxiliar = root;
            while (auxiliar.valor.CompareTo(value) != 0)
            {
                if (auxiliar == null)
                {
                    return null;
                }
                if (value.CompareTo(auxiliar.valor) < 0)
                {
                    auxiliar = auxiliar.izquierdo;
                }
                else
                {
                    auxiliar = auxiliar.derecho;
                }
            }
            return auxiliar;
        }

        /// <summary>
        /// Determina si el arbol tiene datos
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return root == null;
        }

        /// <summary>
        /// Metodo Recursivo que recorre el arbol
        /// </summary>
        /// <param name="Aux">Nodo Raiz</param>
        /// <param name="Elements">Lista de Datos en Orden</param>
        private void PreOrder(Nodo<T> Aux, ref List<T> Elements)
        {
            if (Aux != null)
            {
                Elements.Add(Aux.valor);
                PreOrder(Aux.izquierdo, ref Elements);
                PreOrder(Aux.derecho, ref Elements);
            }
        }
        /// <summary>
        /// Metodo Recursivo que recorre el arbol
        /// </summary>
        /// <param name="Aux">Nodo Raiz</param>
        /// <param name="Elements">Lista de Datos en Orden</param>
        private void InOrder(Nodo<T> Aux, ref List<T> Elements)
        {
            if (Aux != null)
            {
                InOrder(Aux.izquierdo, ref Elements);
                Elements.Add(Aux.valor);
                InOrder(Aux.derecho, ref Elements);
            }
        }
        /// <summary>
        /// Metodo Recursivo que recorre el arbol
        /// </summary>
        /// <param name="Aux">Nodo Raiz</param>
        /// <param name="Elements">Lista de Datos en Orden</param>
        private void PostOrder(Nodo<T> Aux, ref List<T> Elements)
        {
            if (Aux != null)
            {
                PostOrder(Aux.izquierdo, ref Elements);
                PostOrder(Aux.derecho, ref Elements);
                Elements.Add(Aux.valor);
            }
        }

        /// <summary>
        /// Recorrido en PreOrden del Arbol
        /// </summary>
        /// <param name="Elements">Datos ordenados</param>
        public void PreOrder(ref List<T> Elements)
        {
            PreOrder(root, ref Elements);
        }
        /// <summary>
        /// Recorrido en Orden del Arbol
        /// </summary>
        /// <param name="Elements">Datos ordenados</param>
        public void InOrder(ref List<T> Elements)
        {
            InOrder(root, ref Elements);
        }
        /// <summary>
        /// Recorrido en PostOrden del Arbol
        /// </summary>
        /// <param name="Elements">Datos ordenados</param>
        public void PostOrder(ref List<T> Elements)
        {
            PostOrder(root, ref Elements);
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
        /// Delegado para Realizar Ordenes
        /// </summary>
        /// <param name="temp">Nodo Raiz</param>
        /// <param name="valores">Lista de Datos Ordenados</param>
        public delegate void Ordenes(ref List<T> valores);

        /// <summary>
        /// Metodo que extrae los datos del arbol en un orden
        /// </summary>
        /// <param name="valores">Datos Ordenados</param> 
        /// <param name="orden">Orden de Salida</param>
        public void Orders(ref List<T> valores, Ordenes orden)
        {
            valores = new List<T>();
            orden(ref valores);
        }

        /// <summary>
        /// Crea un subarbol del arbol actual
        /// </summary>
        /// <param name="valor">Valor de Raiz</param>
        /// <returns>Subarbol</returns>
        public Arbol<T> SubArbol(T valor)
        {
            Arbol<T> nuevo = new Arbol<T>();
            Nodo<T> nuevaRaiz = Encontrar(valor);
            if (nuevaRaiz == null)
                return null;
            nuevo.root = nuevaRaiz;
            return nuevo;
        }

        /// <summary>
        /// Altura del Arbol
        /// </summary>
        public int Altura
        {
            get
            {
                return setAltura(root, 0);
            }
        }

        /// <summary>
        /// Funcion recursiva que determina la altura del Arbol
        /// </summary>
        /// <param name="actual">Nodo Raiz</param>
        /// <paramname="nivelActual">Nivel del nodo raiz</param>
        /// <returns>Altura de Arbol con Nodo Raiz</returns>
        private int setAltura(Nodo<T> actual, int nivelActual)
        {
            if (actual == null)
            {
                return nivelActual;
            }
            int altI = setAltura(actual.izquierdo, nivelActual + 1);
            int altD = setAltura(actual.derecho, nivelActual + 1);
            return Math.Max(altI, altD);
        }

        /// <summary>
        /// El arbol esta balanceado
        /// </summary>
        public bool Balancedo
        {
            get
            {
                int altI = 0;
                int altD = 0;
                if (root.izquierdo != null)
                    altI = SubArbol(root.izquierdo.valor).Altura;
                if (root.derecho != null)
                    altD = SubArbol(root.derecho.valor).Altura;
                return Math.Abs(altI - altD) <= 1;
            }
        }

        public Nodo<T> Desbalanceado()
        {
            return setDesbalanceado(root);
        }

        /// <summary>
        /// Funcion Recursiva que devuelve el nodo de más alto nivel que este desbalanceado
        /// </summary>
        /// <param name="actual">Nodo Actual</param>
        /// <returns>Nodo Desbalanceado</returns>
        private Nodo<T> setDesbalanceado(Nodo<T> actual)
        {
            bool izq = true;
            bool der = true;
            if (actual.izquierdo != null)
                izq = SubArbol(actual.izquierdo.valor).Balancedo;
            if (actual.derecho != null)
                der = SubArbol(actual.derecho.valor).Balancedo;
            if (!izq)
            {
                return setDesbalanceado(actual.izquierdo);
            }
            else if (!der)
            {
                return setDesbalanceado(actual.derecho);
            }
            else
            {
                if (SubArbol(actual.valor).Balancedo)
                {
                    return null;
                }
                return actual;
            }
        }


        /// <summary>
        /// El arbol esta degenerado
        /// </summary>
        public bool Degenerado
        {
            get
            {
                return setDegenerado(root);
            }
        }

        /// <summary>
        /// Funcion recursiva que determina si el arbol esta degenerado
        /// </summary>
        /// <param name="actual">Nodo Raiz</param>
        /// <returns>Si el arbol esta degenerado</returns>
        private bool setDegenerado(Nodo<T> actual)
        {
            if (actual.Lleno)
            {
                return false;
            }
            if (actual.izquierdo != null)
            {
                return setDegenerado(actual.izquierdo);
            }
            else if(actual.derecho != null)
            {
                return setDegenerado(actual.derecho);
            }
            else
            {
                return true;
            }
        }
    }
}
