using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace Lab02_ED1.DataBase
{
    public class JsonReader<T>
    {
        /// <summary>
        /// Datos en Archivo
        /// </summary>
        /// <param name="rutaOrigen">Ruta de Origen de Archivo</param>
        /// <returns></returns>
        public List<T> Datos(string rutaOrigen)
        {
            try
            {
                List<T> datos;
                StreamReader lector = new StreamReader(rutaOrigen);
                string temp = lector.ReadToEnd();
                datos = JsonConvert.DeserializeObject<List<T>>(temp);
                lector.Close();
                return datos;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}