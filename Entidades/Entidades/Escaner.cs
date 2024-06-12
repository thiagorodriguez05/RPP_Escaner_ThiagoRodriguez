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
        public static bool operator !=(Escaner e, Documento d)
        {
            return !e.ListaDocumento.Contains(d);
        }

        public static bool operator ==(Escaner e, Documento d)
        {
            if ((e.tipo == TipoDoc.libro && d is Libro) || (e.tipo == TipoDoc.mapa && d is Mapa))
            {
                return e.ListaDocumento.Contains(d);
            }
            else
            {
                throw new TipoIncorrectoException("Este escáner no acepta este tipo de documento", nameof(Escaner), "operator ==");
            }
        }

        public static bool operator +(Escaner e, Documento d)
        {
            try
            {
                if (e != d && d.Estado == Documento.Paso.inicio)
                {
                    d.Estado = Documento.Paso.distribuido;
                    e.ListaDocumento.Add(d);
                    return true;
                }
            }
            catch (TipoIncorrectoException ex)
            {
                throw new Exception("El documento no se pudo añadir a la lista", ex);
            }
            return false;
        }
        #endregion

        #region Metodos
        public bool CambiarEstadoDocumento(Documento d)
        {
            if (d.AvanzarEstado())
            {
                return true;
            }
            return false;
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
