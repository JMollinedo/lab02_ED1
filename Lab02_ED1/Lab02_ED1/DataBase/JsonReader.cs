using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Lab02_ED1.Models;
using ArbolBinarioBu;

namespace Lab02_ED1.DataBase
{
    public class JsonReader<T>
    {
        /// <summary>
        /// Datos en Archivo
        /// </summary>
        /// <param name="rutaOrigen">Ruta de Origen de Archivo</param>
        /// <returns></returns>
        public Nodo<Country> Datos(Stream rutaOrigen)
        {
            try
            {
                Nodo<Country> datos;
                StreamReader lector = new StreamReader(rutaOrigen);
                string temp = lector.ReadToEnd();
                datos = JsonConvert.DeserializeObject<Nodo<Country>>(temp);
                lector.Close();
                return datos;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Nodo<int> DatosI(Stream rutaOrigen)
        {
            try
            {
                Nodo<int> datos;
                StreamReader lector = new StreamReader(rutaOrigen);
                string temp = lector.ReadToEnd();
                datos = JsonConvert.DeserializeObject<Nodo<int>>(temp);
                lector.Close();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Nodo<string> DatosS(Stream rutaOrigen)
        {
            try
            {
                Nodo<string> datos;
                StreamReader lector = new StreamReader(rutaOrigen);
                string temp = lector.ReadToEnd();
                datos = JsonConvert.DeserializeObject<Nodo<string>>(temp);
                lector.Close();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}