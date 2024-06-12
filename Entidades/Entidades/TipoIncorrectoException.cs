using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoIncorrectoException : Exception
    {
        string nombreClase;
        string nombreMetodo;

        public TipoIncorrectoException(string mensaje, string clase, string metodo)
          : this(mensaje, clase, metodo, new Exception()) { }

        public TipoIncorrectoException(string mensaje, string clase, string metodo, Exception innerException)
           : base(mensaje, innerException)
        {
            this.nombreMetodo = metodo;
            this.nombreClase = clase;
        }


        public string NombreClase { get => nombreClase; set => nombreClase = value; }
        public string NombreMetodo { get => nombreMetodo; set => nombreMetodo = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Excepción en el metodo {0} de la clase {1}\n", NombreMetodo, NombreClase);
            sb.AppendLine("Algo salió mal, revisa los detalles.");
            sb.AppendLine($"Detalles: {this.InnerException}");

            return sb.ToString();
        }
    }
}
