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
                if ((doc is Libro libro && d is Libro) || (doc is Mapa mapa && d is Mapa))
                {
                    if (doc is Libro aux1 && d is Libro aux2 && aux1 == aux2)
                    {
                        retorno = true;
                    }
                    else if (doc is Mapa aux3 && d is Mapa aux4 && aux3 == aux4)
                    {
                        retorno = true;
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
