using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionDeContactos;

public class Contacto
{
    [Key]
    public Guid Id {get;set;}
    public string Nombre {get;set;}
    public string Telefono {get;set;}
    public string Email {get;set;}

    public override string ToString()
    {
        return $"Id: {Id} \nNombre: {Nombre} \nTeléfono: {Telefono} \nEmail: {Email}";
    }
}