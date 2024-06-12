using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entidades
{
    public class Documento
    {
        #region Atributos
        string titulo;
        string autor;
        int año;
        protected string numNormalizado;
        string barcode;
        Paso estado;
        #endregion

        #region Constructor
        public Documento(string titulo, string autor, int año, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.año = año;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.inicio;
        }
        #endregion

        #region Propiedades
        public string Titulo { get => titulo; }
        public string Autor { get => autor; }
        public int Año { get => año; }
        public string NumNormalizado { get => numNormalizado; }
        public string Barcode { get => barcode; }
        public Paso Estado { get => estado; set => estado = value; }
        #endregion
   
        #region Metodos
        public bool AvanzarEstado()
        {
            bool retorno = false;
            if (this.Estado != Paso.terminado)
            {
                this.estado++;
                retorno = true;
            }

            return retorno;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Titulo: {Titulo}");
            sb.AppendLine($"Autor: {Autor}");
            sb.AppendLine($"Año: {Año}");
            sb.AppendLine($"Numero: {NumNormalizado}"); 
            sb.AppendLine($"Barcode: {Barcode}");
            sb.AppendLine($"Estado: {Estado}");
            sb.AppendLine();

            return sb.ToString();
        }
        #endregion

        #region Enum
        public enum Paso
        {
            inicio,
            distribuido,
            enEscaner,
            enRevision,
            terminado
        }
        #endregion
    }

}
