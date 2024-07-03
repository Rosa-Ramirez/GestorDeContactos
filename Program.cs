using managerContact;

ContactManager manager = new ContactManager();

while (true)
{
    Console.WriteLine("\nMenú de Contactos");
    Console.WriteLine("1. Agregar contacto");
    Console.WriteLine("2. Buscar contacto");
    Console.WriteLine("3. Listar contacto");
    Console.WriteLine("4. Eliminar contacto");
    Console.WriteLine("5. Guardar contactos");
    Console.WriteLine("6. Cargar contactos");
    Console.WriteLine("7. Salir");
    int option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            AddContact(manager);
            break;
        case 2:
            SearchContact(manager);
            break;
        case 3:
            ListContact(manager);
            break;
        case 4:
            DeleteContact(manager);
            break;
        case 5:
            manager.SaveContact();
            break;
        case 6:
            manager.UploadContact();
            break;
        case 7:
            return;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }
}

static void AddContact(ContactManager manager)
{
    Contact contact = new Contact();

    Console.WriteLine("\nIngrese el nombre del contacto:");
    contact.Name = Console.ReadLine();
    Console.WriteLine("\nIngrese el teléfono del contacto:");
    contact.Phone = Console.ReadLine();
    Console.WriteLine("\nIngrese el email del contacto:");
    contact.Email = Console.ReadLine();

    manager.AddContact(contact);
}

static void SearchContact(ContactManager manager)
{
    Console.WriteLine("\nIngrese el nombre o teléfono del contacto que desea buscar:");
    string search = Console.ReadLine();
    Contact contact = manager.SearchContact(search);

    if (contact != null)
    {
        Console.WriteLine(contact);
    }
    else
    {
        return;
    }
}

static void ListContact(ContactManager manager)
{
    var contacts = manager.ListContact();
    foreach (var contact in contacts)
    {
        Console.WriteLine(contact);
    }
}

static void DeleteContact(ContactManager manager)
{
    Console.WriteLine("Ingrese el id del contacto que desea eliminar:");
    int id = Convert.ToInt32(Console.ReadLine());
    manager.DeleteContact(id);
}