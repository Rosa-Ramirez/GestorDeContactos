namespace managerContact;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;



public class ContactManager
{
    int id = 0;
    List<Contact> contacts = new List<Contact>();

    public void AddContact(Contact contact)
    {
        string datos = Console.ReadLine();
        string[] partes = datos.Split(',');
        try
        {
            id++;
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Id == id)
                {
                    id++;
                }
            }
            contacts.Add(contact);
            Console.WriteLine("\nContact agregado correctamente.");
        }
        catch (FormatException)
        {
            Console.WriteLine("\nError: Asegúrse de que el formato de los datos sea el correcto.");
        }
    }

    public Contact SearchContact(string parameter)
    {
        Console.WriteLine("\nIngrese el id del contact que busca:");
        int id = Convert.ToInt32(Console.ReadLine());

        Contact findContact = new Contact();

        foreach(Contact c in contacts)
        {
            if(c.Id == Convert.ToInt32(parameter)){
                findContact = c;
            }
        }

        return findContact;
    }
    public List<Contact> ListContact()
    {
        return contacts;
    }
    public void DeleteContact(int id)
    {
        Console.WriteLine("\nIngrese el id del contact que desea eliminar:");
       
        Contact? contactToDelete = contacts.FirstOrDefault(c => Convert.ToString(c.Id) == Convert.ToString(id));
        if (contactToDelete != null)
        {
            contacts.Remove(contactToDelete);
            Console.WriteLine("\nContact eliminado");
        }
        else
        {
            Console.WriteLine("\nContact no encontrado");
        }
    }

    public void SaveContacts()
    {
        string contactsFile = "contacts.json";
        string jsonContacts = JsonConvert.SerializeObject(contacts, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });
        
        File.WriteAllText($@"{contactsFile}", jsonContacts);

    }

    public void LoadContacts()
    {
        string contactsFile = "contacts.json";
        try
        {
            if (File.Exists(contactsFile))
            {
                contacts = JsonConvert.DeserializeObject<List<Contact>>(File.ReadAllText(contactsFile));

            }
            else
            {
                Console.WriteLine($"\nEl archivo '{contactsFile}' no existe.");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"\nError: {e.Message}");
        }
    }
}