using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appDocente
{
    internal class cDocNombrado : cDocente
    {
        // Atributos
        private string aCategoria;
        private string aRegimen;

        // Constructores
        public cDocNombrado() : base()
        {
            aCategoria = "";
            aRegimen = "";
        }

        public cDocNombrado(int pCodigo, string pNombre, string pDepartamento, string pCategoria, string pRegimen) : base(pCodigo, pNombre, pDepartamento)
        {
            aCategoria = pCategoria;
            aRegimen = pRegimen;
        }
        // Propiedades
        public string Categoria
        {
            get { return aCategoria; }
            set { aCategoria = value; }
        }
        public string Regimen
        {
            get { return aRegimen; }
            set { aRegimen = value; }
        }

        // Metodos
        public override void Leer()
        {
            base.Leer();
            Console.Write("Categoria: ");
            Categoria = Console.ReadLine();
            Console.Write("Regimen: ");
            Regimen = Console.ReadLine();
            Console.WriteLine();
        }
        public override void Mostrar()
        {
            base.Mostrar();
            Console.WriteLine($"Categoria: {Categoria}");
            Console.WriteLine($"Regimen: {Regimen}");
        }

        public override int CalcularSueldo()
        {
            int Sueldo = 0;
            if (Regimen == "TC")
            {
                if (Categoria == "PRINCIPAL")
                {
                    Sueldo = 8000;
                }
                else if (Categoria == "ASOCIADO")
                {
                    Sueldo = 6000;
                }
                else
                {
                    Sueldo = 8000;
                }
            }
            else
            {
                if (Categoria == "PRINCIPAL")
                {
                    Sueldo = 4000;

                }
                else if (Categoria == "ASOCIADO")
                {
                    Sueldo = 3000;
                }
                else { Sueldo = 1500; }
            }
            return Sueldo;
        }
    }
}