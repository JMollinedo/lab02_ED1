using ArbolBinarioBu;
using Lab02_ED1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab02_ED1.DataBase
{
    public class DataAdmin
    {
        private static volatile DataAdmin Instance;
        private static object syncRoot = new object();

        public Arbol<Country> ArbolBinario = new Arbol<Country>();
        public List<Country> ListaPaises = new List<Country>();

        public Arbol<string> sArbolBinario = new Arbol<string>();
        public List<string> ListaString = new List<string>();

        public Arbol<int> iArbolBinario = new Arbol<int>();
        public List<int> ListaInt = new List<int>();

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