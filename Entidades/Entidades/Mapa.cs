using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Mapa : Documento
    {
        #region Atributos
        int alto;
        int ancho;
        #endregion

        #region Constructor
        public Mapa(string titulo, string autor, int año, string numNormalizado, string barcode,int alto, int ancho)
            :base(titulo,autor, año, numNormalizado, barcode)
        {
            this.alto = alto;
            this.ancho = ancho;
        }
        #endregion

        #region Operadores
        public static bool operator ==(Mapa m1, Mapa m2)
        {
            //verificamos si es el mismo mapa
            bool retorno = false;
            if (m1.Barcode == m2.Barcode || m1.Titulo == m2.Titulo && m1.Autor == m2.Autor && m1.Año == m2.Año && m1.Superficie == m2.Superficie)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Mapa m1, Mapa m2) 
        { 
            return !(m1 == m2); 
        }
        #endregion

        #region Propiedades
        public int Alto { get => alto; }
        public int Ancho { get => ancho; }
        public int Superficie { get => ancho * alto; }
        #endregion

        #region Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Autor: {Autor}");
            sb.AppendLine($"Año: {Año}");
            sb.AppendLine($"Cod. de barras: {Barcode}");
            sb.AppendLine($"Superficie: {Alto} * {Ancho} = {Superficie} cm");
            sb.AppendLine();

            return sb.ToString();
        }
        #endregion
    }
}
