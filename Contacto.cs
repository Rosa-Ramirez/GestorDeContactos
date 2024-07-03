namespace managerContact;

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} \nNombre: {Name} \nTeléfono: {Phone} \nEmail: {Email}";
    }
}