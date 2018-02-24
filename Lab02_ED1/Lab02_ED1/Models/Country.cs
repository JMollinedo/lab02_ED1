using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab02_ED1.Models
{
    public class Country : IComparable
    {
        /*[Key]
         *public int Id { get; set; }
         */
        
        /// <summary>
        /// Nombre de Pais
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        /// <summary>
        /// Grupo en Campeonato
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Requerido")]
        [Display(Name = "Grupo")]
        public char Grupo { get; set; }

        /// <summary>
        /// Comparador por Nombre
        /// </summary>
        /// <param name="country">Pais para comparar</param>
        /// <returns>Valor de Comparacion</returns>
        public int CompareByName(Country country)
        {
            return country.nombre.CompareTo(nombre);
        }

        /// <summary>
        /// Comparador por Grupo
        /// </summary>
        /// <param name="country">Pais para comparar</param>
        /// <returns>Valor de Comparacion</returns>
        public int CompareByGroup(Country country)
        {
            return country.Grupo.CompareTo(Grupo);
        }

        /// <summary>
        /// Delegado de Comparadores
        /// </summary>
        /// <param name="country">Pais para comparar</param>
        /// <returns>Valor de Comparacion</returns>
        public delegate int Comparers(Country country);

        /// <summary>
        /// Comparador con Objeto
        /// </summary>
        /// <param name="obj">Objeto</param>
        /// <returns>Valor de Comparacion</returns>
        public int CompareTo(object obj)
        {
            try
            {
                Country country = obj as Country;
                return CompareByName(country);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}