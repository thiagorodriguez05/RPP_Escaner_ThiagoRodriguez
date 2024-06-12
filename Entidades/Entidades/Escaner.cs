using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        #region Atributos
        List<Documento> listaDocumento;
        Departamento locacion;
        string marca;
        TipoDoc tipo;
        #endregion

        #region Constructor
        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumento = new List<Documento>();
            if (tipo == TipoDoc.mapa)
            {
                this.locacion = Departamento.mapoteca;
            }
            else if (tipo == TipoDoc.libro)
            {
                this.locacion = Departamento.procesosTecnicos;
            }
            else
            {
                this.locacion = Departamento.nulo;
            }
        }
        #endregion

        #region Propiedades
        public List<Documento> ListaDocumento { get => listaDocumento; set => listaDocumento = value; }
        public Departamento Locacion { get => locacion; set => locacion = value; }
        public string Marca { get => marca; set => marca = value; }
        public TipoDoc Tipo { get => tipo; set => tipo = value; }
        #endregion

        #region Sobrecarga de operadores
        public static bool operator ==(Escaner e, Documento d)
        {
            bool retorno = false;

            foreach (Documento doc in e.listaDocumento)
            {
                //verificamos si los dos documnetos son del mismo tipo
                //y verificamos si el escaner es de tipo mapa o libro al igual q el documento d 
                if (d.GetType() == doc.GetType() && ((e.Tipo == TipoDoc.mapa && d is Mapa) || (e.Tipo == TipoDoc.libro && d is Libro)))
                {

                    if (d.GetType() == typeof(Libro))
                    {
                        Libro aux1 = (Libro)doc;
                        Libro aux2 = (Libro)d;
                        if (aux1 == aux2)
                        {
                            retorno = true;
                        }
                    }
                    else
                    {
                        Mapa aux1 = (Mapa)doc;
                        Mapa aux2 = (Mapa)d;

                        if (aux1 == aux2)
                        {
                            retorno = true;
                        }
                    }
                }
                else
                {
                    throw new TipoIncorrectoException("Este escáner no acepta este tipo de documento", "Escaner.cs", "Sobrecarga ==(Escaner e, Documento d)");
                }

            }
            return retorno;
        }

        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        public static bool operator +(Escaner e, Documento d)
        {
            bool retorno = false;
            try
            {
                if (e != d && d.Estado == Documento.Paso.inicio)
                {
                    if (d.AvanzarEstado() && d.Estado == Documento.Paso.distribuido)
                    {
                        e.listaDocumento.Add(d);
                        retorno = true;
                    }
                }
            }
            catch (TipoIncorrectoException execp)
            {
                throw new TipoIncorrectoException("El documento no se pudo añadir a la lista", "Escaner.cs", "Sobrecarga +(Escaner e, Documento d)", execp);
            }


            return retorno;
        }
        #endregion

        #region Metodos
        public bool CambiarEstadoDocumento(Documento d)
        {
            return d.AvanzarEstado();
        }
        #endregion

        #region Enum
        public enum TipoDoc
        {
            libro,
            mapa
        }

        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }
        #endregion
    }
}
