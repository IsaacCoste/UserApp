using System;
using System.Linq;
using UserApp;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Crear usuario");
            Console.WriteLine("2. Listar usuarios");
            Console.WriteLine("3. Salir");
            Console.Write("Opción: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateUser();
                    break;
                case "2":
                    ListUsers();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
            Console.WriteLine();
        }
    }

    static void CreateUser()
    {
        Console.Write("Ingrese el nombre del usuario: ");
        var name = Console.ReadLine();
        Console.Write("Ingrese el email del usuario: ");
        var email = Console.ReadLine();

        using (var context = new UserContext())
        {
            var user = new User { Name = name!, Email = email! };
            context.Users.Add(user);
            context.SaveChanges();
        }

        Console.WriteLine("Usuario creado exitosamente.");
    }

    static void ListUsers()
    {
        using (var context = new UserContext())
        {
            var users = context.Users.ToList();
            Console.WriteLine("Usuarios en la base de datos:");
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
            }
        }
    }
}
