using ArbolBinarioBu;
using Lab02_ED1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab02_ED1.DataBase
{
   /* public class DataInt : IComparable
    {
        public int valor;
        public int id;

        public DataInt(int valor)
        {
            this.valor = valor;
            id = 0;
        }

        public int CompareTo(object obj)
        {
            try
            {
                DataInt Objeto = obj as DataInt;
                return valor.CompareTo(Objeto.valor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public class DataString
    {
        public string valor;
        public int id;

    }
    */
    public class DataAdmin
    { 

        private static volatile DataAdmin Instance;
        private static object syncRoot = new object();

        public Arbol<Country> ArbolBinario = new Arbol<Country>();
        public List<Country> ListaPaises = new List<Country>();
        public int CountryId = 1;


        public Arbol<string> sArbolBinario = new Arbol<string>();
        public List<string> ListaString = new List<string>();
        public int StringId = 1;


        public Arbol<int> iArbolBinario = new Arbol<int>();
        public List<int> ListaInt = new List<int>();
        public int IntId = 1;

        private DataAdmin()
        {

        }

        public static DataAdmin getInstance
        {
            get
            {
                if (Instance == null)
                {
                    lock (syncRoot)
                    {
                        if (Instance == null)
                        {
                            Instance = new DataAdmin();
                        }
                    }
                }
                return Instance;
            }
        }
    }
}