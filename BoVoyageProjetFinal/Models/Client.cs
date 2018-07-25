using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageProjetFinal.Models
{
    [Table(name: "Clients")]
    public class Client : User
    {
    }
}