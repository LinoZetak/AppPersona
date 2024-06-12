using appDocente;
class cControl
{
    // Atributos
    public cDocente[] Arreglo = new cDocente[10];

    // Constructor
    public cControl()
    {
        cDocente d1 = new cDocNombrado(1, "Javier", "IN", "PRINCIPAL", "TC");
        cDocente d2 = new cDocContratado(2, "Manuel", "IN", "A1");

        Arreglo[0] = d1;
        Arreglo[1] = d2;
    }

    public void IngrsarDocente()
    {
        Console.WriteLine("\nDigite el numero:");
        Console.WriteLine("1. Nombrado");
        Console.WriteLine("2. Contratado");
        Console.Write("Opcion --> ");
        int opcion = int.Parse(Console.ReadLine());

        if (opcion == 1)
        {
            cDocente a = new cDocNombrado();
            a.Leer();
            bool registrado = false;
            for (int i = 0; i < Arreglo.Length; i++)
            {
                if (Arreglo[i] != null)
                {
                    if (a.Equals(Arreglo[i].Codigo))
                    {
                        registrado = true;
                        Console.WriteLine("Ya se registró una vez");
                        break;
                    }

                }
            }
            if (!registrado)
            {
                for (int i = 0; i < Arreglo.Length; i++)
                {
                    if (Arreglo[i] == null)
                    {
                        Arreglo[i] = a;
                        registrado = true;
                        Console.WriteLine("Registrado :)");
                        break;
                    }
                }
            }
            if (!registrado)
            {
                Console.WriteLine("Error: No hay espacio para registrar más docentes.");
            }

        }
        else if (opcion == 2)
        {
            cDocente a = new cDocContratado();
            a.Leer();
            bool registrado = false;
            for (int i = 0; i < Arreglo.Length; i++)
            {
                if (Arreglo[i] != null)
                {
                    if (a.Equals(Arreglo[i].Codigo))
                    {
                        registrado = true;
                        Console.WriteLine("Ya se registró una vez");
                        break;
                    }
                }
            }
            if (!registrado)
            {
                for (int i = 0; i < Arreglo.Length; i++)
                {
                    if (Arreglo[i] == null)
                    {
                        Arreglo[i] = a;
                        registrado = true;
                        Console.WriteLine("Registrado :)");
                        break;
                    }
                }
            }
            if (!registrado)
            {
                Console.WriteLine("Error: No hay espacio para registrar más docentes.");
            }

        }
    }
    int Ubicacion(int pCodigo)
    {
        int U = -1;
        for (int i = 0; i < Arreglo.Length; i++)
        {
            if ((Arreglo[i] != null))
            {
                if (Arreglo[i].Codigo == pCodigo)
                {
                    U = i;
                    break;
                }
            }
        }
        return U;
    }
    public void BuscarDocente()
    {
        Console.WriteLine("Ingrese codigo del docente a buscar");
        int Codigo = int.Parse(Console.ReadLine());
        int Ubi = Ubicacion(Codigo);
        if (Ubi >= 0)
        {
            Arreglo[Ubi].Mostrar();
        }
        else
        {
            Console.WriteLine("No existe en el arreglo");
        }
    }

    public void CalcularPago()
    {
        int totalnom = 0;
        int totalcon = 0;

        for (int i = 0; i < Arreglo.Length; i++)
        {
            if (Arreglo[i] != null)
            {
                if (Arreglo[i] is cDocNombrado)
                {
                    totalnom += Arreglo[i].CalcularSueldo();
                }
                else
                {
                    totalcon += Arreglo[i].CalcularSueldo();

                }
                Arreglo[i].Mostrar();
            }


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
            for (int i = Ubi; i < Arreglo.Length - 1; i++)
            {
                Arreglo[i] = Arreglo[i + 1];
            }
            Arreglo[Arreglo.Length - 1] = null;
            Console.WriteLine("Docente eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("No existe en el arreglo.");
        }
    }

    public void CantidadDocentes()
    {
        int nroAutos = 0;
        int nroCamiones = 0;

        for (int i = 0; i < Arreglo.Length; i++)
        {
            if (Arreglo[i] != null)
            {
                if (Arreglo[i] is cDocContratado) { nroAutos++; }
                else { nroCamiones++; }
            }
        }
        Console.WriteLine($"\n--- CANTIDAD ---");
        Console.WriteLine($"Doc Conratados: {nroAutos}");
        Console.WriteLine($"Doc Nombrados: {nroCamiones}");
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
                    Console.WriteLine("\nIngrese un número entre 1 y .");
                    break;
            }
            Console.WriteLine("\nPresione [ENTER] para continuar...");
            Console.ReadLine(); // Esperar hasta que el usuario presione Enter
        }
    }
}