using System;
using System.Reflection.Metadata;
using Entidades;
using static Entidades.Escaner;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // LIBROS
            // Caminos felices
            Libro l1 = new Libro("Yerma", "García Lorca, Federico", 1995, "11111", "22222", 100);
            Libro l2 = new Libro("Bodas de sangre", "García Lorca, Federico", 1997, "11112", "22223", 200);
            // Barcode repetido
            Libro l3 = new Libro("Codebar repetido", "García Lorca, Federico", 2003, "11113", "22222", 3);
            // ISBN repetido
            Libro l4 = new Libro("ISBN repetido", "García Lorca, Federico", 2003, "11112", "22224", 2);
            // Título-autor repetido
            Libro l5 = new Libro("Yerma", "García Lorca, Federico", 2003, "55555", "66666", 1);

            //MAPAS 
            // Caminos felices
            Mapa m1 = new Mapa("Buenos Aires", "Instituto Geográfico de Buenos Aires", 2005, "", "99999", 30, 15); //450
            Mapa m2 = new Mapa("Mendoza", "Instituto Geográfico de Mendoza", 2008, "", "99990", 100, 30); //300
            Mapa m3 = new Mapa("Santa Fe", "Instituto Geográfico de Santa Fe", 2010, "", "99991", 80, 30); //2400
            Mapa m4 = new Mapa("Corrientes", "Instituto Geográfico de Corrientes", 2013, "", "99992", 50, 25); //1250
            // Barcode repetido
            Mapa m5 = new Mapa("Barcode repetido", "Instituto Geográfico", 2015, "", "99999", 40, 15);//600


            // ESCANERS
            Escaner escanerLibros = new Escaner("HP", Escaner.TipoDoc.libro);
            Escaner escanerMapas = new Escaner("HP", Escaner.TipoDoc.mapa);
            Console.WriteLine("Añadimos los libros y mapas a sus respectivos escaneres:");
            AgregarDocumento(escanerLibros, l1);
            AgregarDocumento(escanerLibros, l2);
            AgregarDocumento(escanerLibros, l3);
            AgregarDocumento(escanerLibros, l4);
            AgregarDocumento(escanerLibros, l5);
            AgregarDocumento(escanerMapas, m1);
            AgregarDocumento(escanerMapas, m2);
            AgregarDocumento(escanerMapas, m3);
            AgregarDocumento(escanerMapas, m4);
            AgregarDocumento(escanerMapas, m5);

            Console.WriteLine($"Intento agregar un libro al escaner de mapas:");
            AgregarDocumento(escanerMapas, l1);

            Console.WriteLine($"\nIntento agregar un mapa al escaner de libros:");
            AgregarDocumento(escanerLibros, m1);


            Console.WriteLine();

            l1.AvanzarEstado();
            l1.AvanzarEstado();
            l2.AvanzarEstado();
            l2.AvanzarEstado();
            m2.AvanzarEstado();
            m3.AvanzarEstado();
            m3.AvanzarEstado();
            m3.AvanzarEstado();
            m4.AvanzarEstado();
            m4.AvanzarEstado();
            m4.AvanzarEstado();
            m4.AvanzarEstado();
            m4.AvanzarEstado();

            Informes.MostrarDistribuidos(escanerLibros, out int extensionLibroDistr, out int cantidadLibroDistr, out string resumenLibroDistr);
            Informes.MostrarEnEscaner(escanerLibros, out int extensionLibroEnEsc, out int cantidadLibroEnEsc, out string resumenLibroEnEsc);
            Informes.MostrarEnRevision(escanerLibros, out int extensionLibroEnRev, out int cantidadLibroEnRev, out string resumenLibroEnRev);
            Informes.MostrarTerminados(escanerLibros, out int extensionLibroTerminado, out int cantidadLibroTerminado, out string resumenLibroTerminado);

            Informes.MostrarDistribuidos(escanerMapas, out int extensionMapaDistr, out int cantidadMapaDistr, out string resumenMapaDistr);
            Informes.MostrarEnEscaner(escanerMapas, out int extensionMapaEnEsc, out int cantidadMapaEnEsc, out string resumenMapaEnEsc);
            Informes.MostrarEnRevision(escanerMapas, out int extensionMapaEnRev, out int cantidadMapaEnRev, out string resumenMapaEnRev);
            Informes.MostrarTerminados(escanerMapas, out int extensionMapaTerminado, out int cantidadMapaTerminado, out string resumenMapaTerminado);

            int puntos = 0;

            if (extensionLibroDistr == 0) { puntos += 3; }
            if (cantidadLibroDistr == 0) { puntos += 1; }
            if (resumenLibroDistr == "") { puntos += 1; }

            if (extensionLibroEnEsc == 0) { puntos += 3; }
            if (cantidadLibroEnEsc == 0) { puntos += 1; }
            if (resumenLibroEnEsc == "") { puntos += 1; }

            if (extensionLibroEnRev == l1.NumPaginas + l2.NumPaginas) { puntos += 3; }
            if (cantidadLibroEnRev == 2) { puntos += 1; }
            if (resumenLibroEnRev == l1.ToString() + l2.ToString()) { puntos += 1; }

            if (extensionLibroTerminado == 0) { puntos += 3; }
            if (cantidadLibroTerminado == 0) { puntos += 1; }
            if (resumenLibroTerminado == "") { puntos += 1; }

            if (extensionMapaDistr == m1.Superficie) { puntos += 3; }
            if (cantidadMapaDistr == 1) { puntos += 1; }
            if (resumenMapaDistr == m1.ToString()) { puntos += 1; }

            if (extensionMapaEnEsc == m2.Superficie) { puntos += 3; }
            if (cantidadMapaEnEsc == 1) { puntos += 1; }
            if (resumenMapaEnEsc == m2.ToString()) { puntos += 1; }

            if (extensionMapaEnRev == 0) { puntos += 3; }
            if (cantidadMapaEnRev == 0) { puntos += 1; }
            if (resumenMapaEnRev == "") { puntos += 1; }

            if (extensionMapaTerminado == m3.Superficie + m4.Superficie) { puntos += 3; }
            if (cantidadMapaTerminado == 2) { puntos += 1; }
            if (resumenMapaTerminado == m3.ToString() + m4.ToString()) { puntos += 1; }

            Console.WriteLine($"Puntos: {puntos} / 40");

            Console.WriteLine("LIBROS DISTRIBUIDOS");
            Console.WriteLine($"Cantidad de libros ya distribuidos: {cantidadLibroDistr}.");
            Console.WriteLine($"Cantidad de páginas ya distribuidas: {extensionLibroDistr}.");
            Console.WriteLine(resumenLibroDistr);
            Console.WriteLine("---------------------");

            Console.WriteLine("LIBROS EN ESCANER");
            Console.WriteLine($"Cantidad de libros en el escáner: {cantidadLibroEnEsc}.");
            Console.WriteLine($"Cantidad de páginas en el escáner: {extensionLibroEnEsc}.");
            Console.WriteLine(resumenLibroEnEsc);
            Console.WriteLine("---------------------");

            Console.WriteLine("LIBROS EN REVISIÓN");
            Console.WriteLine($"Cantidad de libros en el escáner: {cantidadLibroEnRev}.");
            Console.WriteLine($"Cantidad de páginas en el escáner: {extensionLibroEnRev}.");
            Console.WriteLine();
            Console.WriteLine(resumenLibroEnRev);
            Console.WriteLine("---------------------");

            Console.WriteLine("LIBROS TERMINADOS");
            Console.WriteLine($"Cantidad de libros terminados: {cantidadLibroTerminado}.");
            Console.WriteLine($"Cantidad de páginas terminadas: {extensionLibroTerminado}.");
            Console.WriteLine(resumenLibroTerminado);
            Console.WriteLine("---------------------");

            Console.WriteLine("MAPAS DISTRIBUIDOS");
            Console.WriteLine($"Cantidad de mapas ya distribuidos: {cantidadMapaDistr}.");
            Console.WriteLine($"Cantidad de superficie ya distribuidas: {extensionMapaDistr}.");
            Console.WriteLine(resumenMapaDistr);
            Console.WriteLine("---------------------");

            Console.WriteLine("MAPAS EN ESCANER");
            Console.WriteLine($"Cantidad de mapas en el escáner: {cantidadMapaEnEsc}.");
            Console.WriteLine($"Cantidad de superficie en el escáner: {extensionMapaEnEsc}.");
            Console.WriteLine(resumenMapaEnEsc);
            Console.WriteLine("---------------------");

            Console.WriteLine("MAPAS EN REVISIÓN");
            Console.WriteLine($"Cantidad de mapas en el escáner: {cantidadMapaEnRev}.");
            Console.WriteLine($"Cantidad de superficie en el escáner: {extensionMapaEnRev}.");
            Console.WriteLine(resumenMapaEnRev);
            Console.WriteLine("---------------------");

            Console.WriteLine("MAPAS TERMINADOS");
            Console.WriteLine($"Cantidad de mapas terminados: {cantidadMapaTerminado}.");
            Console.WriteLine($"Cantidad de superficie terminadas: {extensionMapaTerminado}.");
            Console.WriteLine(resumenMapaTerminado);
            Console.WriteLine("---------------------");

            static void AgregarDocumento(Escaner escaner, Documento doc)
            {
                try
                {
                    bool pudo = escaner + doc;
                    Console.WriteLine($"Resultado -> {pudo}");
                }
                catch (TipoIncorrectoException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
