using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageProjetFinal.Models
{
    public class ReservationFolderState : ReservationFolder
    {
        public enum ReservationFolderState : byte { EnAttente = 0, EnCours, Refusee, Acceptee }
    }
}