namespace gestionDeContactos;

public class GestorDeContactos
{
    List<Contacto> contactos = new List<Contacto>();

    public void AgregarContacto()
    {
        Console.WriteLine("Ingrese los datos del contacto (separados por coma. Ej.: 7894, Luis, +50246962876, luis@gmail.com");
        string datos = Console.ReadLine();
        string[] partes = datos.Split(',');
        try
        {
            Contacto contacto = new Contacto
            {
                Id = int.Parse(partes[0]),
                Nombre = partes[1],
                Telefono = partes[2],
                Email = partes[3]
            };
            contactos.Add(contacto);
            Console.WriteLine("Contacto agregado correctamente.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Asegúrse de que el formato de los datos sea el correcto.");
        }
    }

    public void BuscarContacto()
    {
        Console.WriteLine("Ingrese el id del contacto que busca:");
        int id = Convert.ToInt32(Console.ReadLine());

        Contacto contacto = contactos.FirstOrDefault(c => Convert.ToInt32((c.Id)) == id);
        if (contacto != null)
        {
            Console.WriteLine(contacto);
        }
        else
        {
            Console.WriteLine("Contacto no encontrado");
        }
    }
    public void ListarContactos()
    {
        int count = 1;
        foreach (var contacto in contactos)
        {
            Console.WriteLine($"{count} Contacto:");
            count++;
            Console.WriteLine(contacto);
        }
    }
    public void EliminarContacto()
    {
        Console.WriteLine("Ingrese el id del contacto que desea eliminar:");
        string id = Console.ReadLine();

        Contacto contacto = contactos.FirstOrDefault(c => Convert.ToString(c.Id) == id);
        if (contacto != null)
        {
            contactos.Remove(contacto);
            Console.WriteLine("Contacto eliminado");
        }
        else
        {
            Console.WriteLine("Contacto no encontrado");
        }
    }

    public void GuardarContactos(string archivo)
    {
        StreamWriter writer = new StreamWriter(archivo);
        {
            foreach (var contacto in contactos)
            {
                writer.WriteLine($"{contacto.Id}, {contacto.Nombre}, {contacto.Telefono}, {contacto.Email}");
            }
        }
    }

    public void CargarContactos(string archivo)
    {
        if (File.Exists(archivo))
        {
            StreamReader reader = new StreamReader(archivo);
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    string[] partes = linea.Split(',');
                    Contacto contacto = new Contacto
                    {
                        Id = int.Parse(partes[0]),
                        Nombre = partes[1],
                        Telefono = partes[2],
                        Email = partes[3]
                    };
                    contactos.Add(contacto);
                }
            }
        }
    }
}