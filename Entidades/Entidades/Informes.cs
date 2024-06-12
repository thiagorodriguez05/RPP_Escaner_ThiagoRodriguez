using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Informes
    {
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.distribuido, out extension, out cantidad, out resumen);
        }
        private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";
            if (e.Tipo == Escaner.TipoDoc.libro) //verificamos si el el escaner del documento es de tipo libro
            {
                foreach (Libro libro in e.ListaDocumento)
                {
                    if (libro.Estado == estado)
                    {
                        extension += (int)libro.NumPaginas;
                        cantidad++;
                        resumen = resumen + libro.ToString();
                    }
                }
            }
            else
            {
                foreach (Mapa mapa in e.ListaDocumento)
                {
                    if (mapa.Estado == estado)
                    {
                        extension += (int)mapa.Superficie;
                        cantidad++;
                        resumen = resumen + mapa.ToString();
                    }
                }
            }

        }


        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.enEscaner, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.enRevision, out extension, out cantidad, out resumen);
        }

        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.terminado, out extension, out cantidad, out resumen);
        }

    }
}

