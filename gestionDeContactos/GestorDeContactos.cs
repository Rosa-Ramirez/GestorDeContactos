using Microsoft.Data.Sqlite;
namespace gestionDeContactos;

public class GestorDeContactos
{
    private string connectionString = "Data Source=contactos.db";

    public GestorDeContactos()
    {
        SQLitePCL.Batteries.Init();
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string table = "CREATE TABLE IF NOT EXISTS contactos (Id INTEGER PRIMARY KEY AUTOINCREMENT, Nombre TEXT NOT NULL, Telefono TEXT NOT NULL, Email TEXT NOT NULL)";
            var command = new SqliteCommand(table, connection);
            command.ExecuteNonQuery();
        }
    }
    int id = 0;
    List<Contacto> contactos = new List<Contacto>();

    public void AgregarContacto(Contacto contacto)
    {
        try
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string sqlAdd = "INSERT INTO contactos (Nombre, Telefono, Email) VALUES (@Nombre, @Telefono, @Email)";
                var command = new SqliteCommand(sqlAdd, connection);
                command.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                command.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                command.Parameters.AddWithValue("@Email", contacto.Email);
                command.ExecuteNonQuery();
                Console.WriteLine("\nContacto agregado correctamente.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("\nError: Asegúrese de que el formato de los datos sea el correcto.");
        }
    }

    public Contacto BuscarContacto(string criterio)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string sqlSearch = "SELECT * FROM contactos WHERE Nombre LIKE @Criterio OR Telefono LIKE @Criterio";
            var command = new SqliteCommand(sqlSearch, connection);
            command.Parameters.AddWithValue("@Criterio", $"%{criterio}%");
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Contacto
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Telefono = reader.GetString(2),
                        Email = reader.GetString(3)
                    };
                }
                else
                {
                    Console.WriteLine("\n Contacto no encontrado.");
                    return null;
                }
            }
        }
    }
    public List<Contacto> ListarContactos()
    {
        List<Contacto> contactos = new List<Contacto>();
        try
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string sqlList = "SELECT * FROM contactos";
                var command = new SqliteCommand(sqlList, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine(new Contacto
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Telefono = reader.GetString(2),
                            Email = reader.GetString(3)
                        });
                    }
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("No hay contactos registrados en la base de datos.");
        }
        return contactos;
    }
    public void EliminarContacto(int id)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string sqlDelete = "DELETE FROM contactos WHERE Id = @Id";
            var command = new SqliteCommand(sqlDelete, connection);
            command.Parameters.AddWithValue("@Id", id);
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("\nContacto eliminado");
            }
            else
            {
                Console.WriteLine("\nContacto no encontrado");

            }
        }
    }

    public void GuardarContactos()
    {
        Console.WriteLine("Los contactos ya se han guardado en la base de datos.");
    }

    public void CargarContactos()
    {
        Console.WriteLine("Los contactos ya se han cargado de la base de datos.");
    }
}