using System;

public abstract class cDocente
{
    // Atributos
    private int aCodigo;
    private string aNombre;
    private string aDepartamento;

    // Constructores
    public cDocente()
    {
        aCodigo = 0;
        aNombre = "";
        aDepartamento = "";
    }

    public cDocente(int pCodigo, string pNombre, string pDepartamento)
    {
        aCodigo = pCodigo;
        aNombre = pNombre;
        aDepartamento = pDepartamento;
    }
    // Propiedades
    public int Codigo
    {
        get { return aCodigo; }
        set { aCodigo = value; }
    }
    public string Nombre
    {
        get { return aNombre; }
        set { aNombre = value; }
    }
    public string Departamento
    {
        get { return aDepartamento; }
        set { aDepartamento = value; }
    }
    // Metodos
    public virtual void Leer()
    {
        Console.Write("Codigo: ");
        Codigo = int.Parse(Console.ReadLine());
        Console.Write("Nombre: ");
        Nombre = Console.ReadLine();
        Console.Write("Departamento: ");
        Departamento = Console.ReadLine();
    }
    public virtual void Mostrar()
    {
        Console.WriteLine("informacion del docente: ");
        Console.WriteLine($"codigo: {Codigo}");
        Console.WriteLine($"nombre: {Nombre}");
        Console.WriteLine($"departamento: {Departamento}");
    }

    public abstract int CalcularSueldo();

    public override bool Equals(object pCodigo)
    {
        return Codigo.Equals(pCodigo);
    }
}