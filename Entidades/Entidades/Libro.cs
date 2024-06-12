using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        #region Atributos
        int numPaginas;
        #endregion

        #region Constructor
        public Libro(string titulo, string autor, int año, string numNormalizado, string barcode, int numPaginas) 
            :base(titulo, autor, año, numNormalizado, barcode)
        {
            this.numPaginas = numPaginas;
        }
        #endregion

        #region Propiedades
        public int NumPaginas { get => numPaginas;}

        public string ISBN { get => NumNormalizado;}
        #endregion

        #region Operadores
        public static bool operator ==(Libro l1, Libro l2)
        {
            bool resultado = false;
            if ((l1.Barcode == l2.Barcode) || (l1.ISBN == l2.ISBN) || ((l1.Titulo == l2.Titulo) && (l1.Autor == l2.Autor)))
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());

            sb.AppendLine($"Num de paginas: {this.numPaginas}");
            sb.AppendLine($"ISBN: {ISBN}");
            sb.AppendLine();

            return sb.ToString();
        }

        #endregion
    }
}
