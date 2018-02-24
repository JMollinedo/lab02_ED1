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