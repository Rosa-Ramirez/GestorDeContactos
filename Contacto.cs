namespace gestionDeContactos;

public class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} \nNombre: {Nombre} \nTeléfono: {Telefono} \nEmail: {Email}";
    }
}