using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class cDocContratado : cDocente
{
    // Atributos
    private string aNivel;

    // Constructores
    public cDocContratado() : base()
    {
        aNivel = "";
    }
    public cDocContratado(int pCodigo, string pNombre, string pDepartamento, string pNivel) : base(pCodigo, pNombre, pDepartamento)
    {
        aNivel = pNivel;
    }

    // Propiedades
    public string Nivel
    {
        get { return aNivel; }
        set { aNivel = value; }
    }

    // Metodos
    public override void Leer()
    {
        base.Leer();
        Console.Write("Nivel: ");
        Nivel = Console.ReadLine();
        Console.WriteLine();
    }
    public override void Mostrar()
    {
        base.Mostrar();
        Console.WriteLine($"nivel: {Nivel}");
    }

    public override int CalcularSueldo()
    {
        int Sueldo = 0;
        if (Nivel == "A1")
        {
            Sueldo = 4000;
        }
        else if (Nivel == "B1")
        {
            Sueldo = 2000;
        }
        else
        {
            Sueldo = 1000;
        }
        return Sueldo;

    }
}

