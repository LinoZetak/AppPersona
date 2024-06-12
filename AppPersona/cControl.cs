using System;
using BibliotecaTDA;

namespace appDocente
{
    class cControl
    {
        // Atributos
        private cListai listaDocentes;

        // Constructor
        public cControl()
        {
            listaDocentes = new cListai();
            cDocente d1 = new cDocNombrado(1, "Javier", "IN", "PRINCIPAL", "TC");
            cDocente d2 = new cDocContratado(2, "Manuel", "IN", "A1");

            listaDocentes.Agregar(d1);
            listaDocentes.Agregar(d2);
        }

        public void IngrsarDocente()
        {
            Console.WriteLine("\nDigite el numero:");
            Console.WriteLine("1. Nombrado");
            Console.WriteLine("2. Contratado");
            Console.Write("Opcion --> ");
            int opcion = int.Parse(Console.ReadLine());

            cDocente a;
            if (opcion == 1)
            {
                a = new cDocNombrado();
            }
            else if (opcion == 2)
            {
                a = new cDocContratado();
            }
            else
            {
                Console.WriteLine("Opción inválida.");
                return;
            }

            a.Leer();
            if (listaDocentes.ubicacion(a.Codigo) != -1)
            {
                Console.WriteLine("Ya se registró una vez");
            }
            else
            {
                listaDocentes.Agregar(a);
                Console.WriteLine("Registrado :)");
            }
        }

        private int Ubicacion(int pCodigo)
        {
            return listaDocentes.ubicacion(pCodigo);
        }

        public void BuscarDocente()
        {
            Console.WriteLine("Ingrese codigo del docente a buscar");
            int Codigo = int.Parse(Console.ReadLine());
            int Ubi = Ubicacion(Codigo);
            if (Ubi >= 0)
            {
                ((cDocente)listaDocentes.Iesimo(Ubi).Info).Mostrar();
            }
            else
            {
                Console.WriteLine("No existe en la lista");
            }
        }

        public void CalcularPago()
        {
            int totalnom = 0;
            int totalcon = 0;

            for (int i = 0; i < listaDocentes.Longitud(); i++)
            {
                cDocente docente = (cDocente)listaDocentes.Iesimo(i).Info;
                if (docente is cDocNombrado)
                {
                    totalnom += docente.CalcularSueldo();
                }
                else
                {
                    totalcon += docente.CalcularSueldo();
                }
                docente.Mostrar();
            }

            Console.WriteLine("\n--- Pago total ---");
            Console.WriteLine($"El sueldo total de nombrados es S/.{totalnom}");
            Console.WriteLine($"El sueldo total de contratados es S/.{totalcon}");
        }

        public void EliminarDocente()
        {
            Console.WriteLine("Ingrese codigo del docente a eliminar");
            int Codigo = int.Parse(Console.ReadLine());
            int Ubi = Ubicacion(Codigo);

            if (Ubi >= 0)
            {
                listaDocentes.eEliminar(Ubi);
                Console.WriteLine("Docente eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("No existe en la lista.");
            }
        }

        public void CantidadDocentes()
        {
            int nroContratados = 0;
            int nroNombrados = 0;

            for (int i = 0; i < listaDocentes.Longitud(); i++)
            {
                if (listaDocentes.Iesimo(i).Info is cDocContratado) { nroContratados++; }
                else { nroNombrados++; }
            }

            Console.WriteLine($"\n--- CANTIDAD ---");
            Console.WriteLine($"Doc Contratados: {nroContratados}");
            Console.WriteLine($"Doc Nombrados: {nroNombrados}");
        }

        public static void Menu()
        {
            Console.WriteLine(" Menu Principal ");
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Ingresar Docente");
            Console.WriteLine("2. Buscar Docente");
            Console.WriteLine("3. Pago Total");
            Console.WriteLine("4. Eliminar Docente");
            Console.WriteLine("5. Salir");
            Console.WriteLine("Ingrese la opcion deseada..");
        }

        public void Ejecutar()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Menu();
                // Leer opción
                Console.Write("\nIngrese Opcion: ");
                int op;
                if (!int.TryParse(Console.ReadLine(), out op))
                {
                    Console.WriteLine("Ingrese un número válido.");
                    continue;
                }
                switch (op)
                {
                    case 1:
                        IngrsarDocente();
                        break;
                    case 2:
                        BuscarDocente();
                        break;
                    case 3:
                        CalcularPago();
                        break;
                    case 4:
                        EliminarDocente();
                        break;
                    case 5:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("\nIngrese un número entre 1 y 5.");
                        break;
                }
                Console.WriteLine("\nPresione [ENTER] para continuar...");
                Console.ReadLine(); // Esperar hasta que el usuario presione Enter
            }
        }
    }
}
