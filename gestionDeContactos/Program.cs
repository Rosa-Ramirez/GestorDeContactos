// See https://aka.ms/new-console-template for more information
using gestionDeContactos;

GestorDeContactos gestor = new GestorDeContactos();
string archivo = "contactos.txt";

while(true)
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

    switch(opcion)
    {
        case 1:
            gestor.AgregarContacto();
            break;
        case 2:
            gestor.BuscarContacto();
            break;
        case 3:
            gestor.ListarContactos();
            break;
        case 4:
            gestor.EliminarContacto();
            break;
        case 5:
            gestor.GuardarContactos(archivo);
            break;
        case 6:
            gestor.CargarContactos(archivo);
            break;
        case 7:
            return;
    }
}