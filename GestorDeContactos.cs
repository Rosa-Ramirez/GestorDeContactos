using Microsoft.Data.Sqlite;
namespace managerContact;
public class ContactManager
{
    private string connectionString = "Data Source=contactos.db";
    public ContactManager()
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
    public void AddContact(Contact contact)
    {
        try
        {
            if (CheckPhone(contact.Phone))
            {
                Console.WriteLine("El teléfono que intentas agregar ya ha sido agregado anteriormente.");
                return;
            }
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string sqlAdd = "INSERT INTO contactos (Nombre, Telefono, Email) VALUES (@Nombre, @Telefono, @Email)";
                var command = new SqliteCommand(sqlAdd, connection);
                command.Parameters.AddWithValue("@Nombre", contact.Name);
                command.Parameters.AddWithValue("@Telefono", contact.Phone);
                command.Parameters.AddWithValue("@Email", contact.Email);
                command.ExecuteNonQuery();
                Console.WriteLine("\nContacto agregado correctamente.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("\nError: Asegúrese de que el formato de los datos sea el correcto.");
        }
    }
    public Contact SearchContact(string parameter)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string sqlSearch = "SELECT * FROM contactos WHERE Nombre LIKE @Criterio OR Telefono LIKE @Criterio";
            var command = new SqliteCommand(sqlSearch, connection);
            command.Parameters.AddWithValue("@Criterio", $"%{parameter}%");
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine("\n");
                    return new Contact
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Phone = reader.GetString(2),
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
    public List<Contact> ListContact()
    {
        List<Contact> contacts = new List<Contact>();
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
                        Console.WriteLine(new Contact
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Phone = reader.GetString(2),
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
        return contacts;
    }
    public void DeleteContact(int id)
    {
        using var connection = new SqliteConnection(connectionString);
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
    public void SaveContact()
    {
        Console.WriteLine("Los contactos ya se han guardado en la base de datos.");
    }
    public void UploadContact()
    {
        Console.WriteLine("Los contactos ya se han cargado de la base de datos.");
    }
    public bool CheckPhone(string telefono)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string sqlCheck = "SELECT COUNT(1) FROM contactos WHERE Telefono = @Telefono";
            var command = new SqliteCommand(sqlCheck, connection);
            command.Parameters.AddWithValue("@Telefono", telefono);
            long count = (long)command.ExecuteScalar();
            return count > 0;
        }
    }
}