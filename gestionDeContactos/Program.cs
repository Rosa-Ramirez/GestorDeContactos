using gestionDeContactos;

GestorDeContactos gestor = new GestorDeContactos();

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
    int opcion = Convert.ToInt32(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            AgregarContacto(gestor);
            break;
        case 2:
            BuscarContacto(gestor);
            break;
        case 3:
            ListarContactos(gestor);
            break;
        case 4:
            EliminarContacto(gestor);
            break;
        case 5:
            gestor.GuardarContactos();
            break;
        case 6:
            gestor.CargarContactos();
            break;
        case 7:
            return;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }
}

static void AgregarContacto(GestorDeContactos gestor)
{
    Contacto contacto = new Contacto();

    Console.WriteLine("\nIngrese el nombre del contacto:");
    contacto.Nombre = Console.ReadLine();
    Console.WriteLine("\nIngrese el teléfono del contacto:");
    contacto.Telefono = Console.ReadLine();
    Console.WriteLine("\nIngrese el email del contacto:");
    contacto.Email = Console.ReadLine();

    gestor.AgregarContacto(contacto);
}

static void BuscarContacto(GestorDeContactos gestor)
{
    Console.WriteLine("\nIngrese el nombre o teléfono del contacto que desea buscar:");
    string busqueda = Console.ReadLine();
    Contacto contacto = gestor.BuscarContacto(busqueda);

    if (contacto != null)
    {
        Console.WriteLine(contacto);
    }
    else
    {
        return;
    }
}

static void ListarContactos(GestorDeContactos gestor)
{
    var contactos = gestor.ListarContactos();
    foreach (var contacto in contactos)
    {
        Console.WriteLine(contacto);
    }
}

static void EliminarContacto(GestorDeContactos gestor)
{
    Console.WriteLine("Ingrese el id del contacto que desea eliminar:");
    int id = Convert.ToInt32(Console.ReadLine());
    gestor.EliminarContacto(id);
}