using System;
using System.Data.SqlClient;

namespace SucursalesABM
{
    class Program
    {
        static string connectionString = "Server=your_server_name;Database=SucursalesDB;User Id=your_username;Password=your_password;";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Alta de Sucursal");
                Console.WriteLine("2. Baja de Sucursal");
                Console.WriteLine("3. Modificación de Sucursal");
                Console.WriteLine("4. Listar Sucursales");
                Console.WriteLine("5. Salir");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AltaSucursal();
                        break;
                    case "2":
                        BajaSucursal();
                        break;
                    case "3":
                        ModificarSucursal();
                        break;
                    case "4":
                        ListarSucursales();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
        }

        static void AltaSucursal()
        {
            Console.WriteLine("Ingrese el nombre de la sucursal:");
            var nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la dirección:");
            var direccion = Console.ReadLine();
            Console.WriteLine("Ingrese la ciudad:");
            var ciudad = Console.ReadLine();
            Console.WriteLine("Ingrese la provincia:");
            var provincia = Console.ReadLine();
            Console.WriteLine("Ingrese el código postal:");
            var codigoPostal = Console.ReadLine();
            Console.WriteLine("Ingrese el teléfono:");
            var telefono = Console.ReadLine();
            Console.WriteLine("Ingrese el email:");
            var email = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de apertura (YYYY-MM-DD):");
            var fechaApertura = Console.ReadLine();
            var estado = "Activo";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Sucursales (Nombre, Direccion, Ciudad, Provincia, CodigoPostal, Telefono, Email, FechaApertura, Estado) VALUES (@Nombre, @Direccion, @Ciudad, @Provincia, @CodigoPostal, @Telefono, @Email, @FechaApertura, @Estado)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Direccion", direccion);
                    command.Parameters.AddWithValue("@Ciudad", ciudad);
                    command.Parameters.AddWithValue("@Provincia", provincia);
                    command.Parameters.AddWithValue("@CodigoPostal", codigoPostal);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@FechaApertura", fechaApertura);
                    command.Parameters.AddWithValue("@Estado", estado);
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Sucursal agregada exitosamente.");
        }

        static void BajaSucursal()
        {
            Console.WriteLine("Ingrese el ID de la sucursal a dar de baja:");
            var sucursalID = Console.ReadLine();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE Sucursales SET Estado = 'Inactivo' WHERE SucursalID = @SucursalID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SucursalID", sucursalID);
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Sucursal dada de baja exitosamente.");
        }

        static void ModificarSucursal()
        {
            Console.WriteLine("Ingrese el ID de la sucursal a modificar:");
            var sucursalID = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo nombre de la sucursal:");
            var nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la nueva dirección:");
            var direccion = Console.ReadLine();
            Console.WriteLine("Ingrese la nueva ciudad:");
            var ciudad = Console.ReadLine();
            Console.WriteLine("Ingrese la nueva provincia:");
            var provincia = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo código postal:");
            var codigoPostal = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo teléfono:");
            var telefono = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo email:");
            var email = Console.ReadLine();
            Console.WriteLine("Ingrese la nueva fecha de apertura (YYYY-MM-DD):");
            var fechaApertura = Console.ReadLine();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE Sucursales SET Nombre = @Nombre, Direccion = @Direccion, Ciudad = @Ciudad, Provincia = @Provincia, CodigoPostal = @CodigoPostal, Telefono = @Telefono, Email = @Email, FechaApertura = @FechaApertura WHERE SucursalID = @SucursalID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SucursalID", sucursalID);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Direccion", direccion);
                    command.Parameters.AddWithValue("@Ciudad", ciudad);
                    command.Parameters.AddWithValue("@Provincia", provincia);
                    command.Parameters.AddWithValue("@CodigoPostal", codigoPostal);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@FechaApertura", fechaApertura);
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Sucursal modificada exitosamente.");
        }

        static void ListarSucursales()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Sucursales WHERE Estado = 'Activo'";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["SucursalID"]}, Nombre: {reader["Nombre"]}, Dirección: {reader["Direccion"]}, Ciudad: {reader["Ciudad"]}, Provincia: {reader["Provincia"]}, Código Postal: {reader["CodigoPostal"]}, Teléfono: {reader["Telefono"]}, Email: {reader["Email"]}, Fecha de Apertura: {reader["FechaApertura"]}, Estado: {reader["Estado"]}");
                        }
                    }
                }
            }
        }
    }
}

