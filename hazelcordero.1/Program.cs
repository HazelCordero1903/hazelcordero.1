using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hazelcordero._1
{
    internal class Program
    {
        static readonly int N = 16;
        static string[] nombre = new string[N];
        static string[] cedula = new string[N];

        static int index = -1;

        static void agregarPacientes()
        {
            for (int i = 0; i < N; i++)
            {
                if (nombre[i] == null)
                {
                    Console.Write("Ingrese el nombre del paciente: ");
                    nombre[i] = Console.ReadLine();

                    Console.Write("Ingrese la cedula del paciente: ");
                    string ced = Console.ReadLine();

                    if (BuscarPaciente(ced))
                    {
                        Console.WriteLine("La cedula ya se encuentra registrada.");
                        nombre[i] = null;
                    }
                    else
                    {
                        cedula[i] = ced;
                        Console.WriteLine("Paciente registrado correctamente.");
                    }

                    return;
                }
            }

            Console.WriteLine("No hay espacios disponibles.");
        }

        static bool BuscarPaciente(string ced)
        {
            index = -1;

            for (int i = 0; i < N; i++)
            {
                if (ced.Equals(cedula[i]))
                {
                    index = i;
                    return true;
                }
            }

            return false;
        }

        static void consultarPaciente()
        {
            Console.Write("Ingrese la cedula del paciente: ");
            string ced = Console.ReadLine();

            if (BuscarPaciente(ced))
            {
                Console.WriteLine("Paciente encontrado.");
                Console.WriteLine("Nombre: " + nombre[index]);
                Console.WriteLine("Cedula: " + cedula[index]);
            }
            else
            {
                Console.WriteLine("El paciente no se encuentra registrado.");
            }
        }

        static void borrarPaciente()
        {
            Console.Write("Ingrese la cedula del paciente: ");
            string ced = Console.ReadLine();

            if (BuscarPaciente(ced))
            {
                nombre[index] = null;
                cedula[index] = null;

                Console.WriteLine("Paciente dado de baja correctamente.");
            }
            else
            {
                Console.WriteLine("El paciente no se encuentra registrado.");
            }
        }
        static void modificarPaciente()
        {
            Console.Write("Ingrese la cedula del paciente: ");
            string ced = Console.ReadLine();

            if (BuscarPaciente(ced))
            {
                Console.WriteLine("Nombre actual: " + nombre[index]);

                Console.Write("Ingrese el nuevo nombre: ");
                nombre[index] = Console.ReadLine();

                Console.WriteLine("Paciente modificado correctamente.");
            }
            else
            {
                Console.WriteLine("El paciente no se encuentra registrado.");
            }
        }

        static void Reporte()
        {
            Console.WriteLine("Reportes de pacientes");


            for (int i = 0; i < N; i++)
            {
                if (nombre[i] != null)
                {
                    Console.WriteLine("Nombre: " + nombre[i]);
                    Console.WriteLine("Cedula: " + cedula[i]);

                }
            }
        }

        static void menu()
        {
            int opcion = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("1. Agregar paciente");
                Console.WriteLine("2. Consultar paciente");
                Console.WriteLine("3. Modificar paciente");
                Console.WriteLine("4. Dar de baja paciente");
                Console.WriteLine("5. Reporte de pacientes");
                Console.WriteLine("6. Salir");


                Console.Write("Ingrese una opcion (1-6): ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        agregarPacientes();
                        break;

                    case 2:
                        consultarPaciente();
                        break;

                    case 3:
                        modificarPaciente();
                        break;

                    case 4:
                        borrarPaciente();
                        break;

                    case 5:
                        Reporte();
                        break;

                    case 6:
                        Console.WriteLine("Salir");
                        break;

                    default:
                        Console.WriteLine("Opcion invalida.");
                        break;
                        break;
                }

                Console.ReadKey();

            } while (opcion != 5);
        }

        static void Main(string[] args)
        {
            menu();
        }
    }
}
