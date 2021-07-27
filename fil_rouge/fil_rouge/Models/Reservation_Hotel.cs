using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fil_rouge.Models
{
    public class Reservation_Hotel
    {
        [Key]
        public int Id { get; set; }
        public DateTime Datedebut { get; set; }
        public DateTime Datefin { get; set; }
        public float Price { get; set; }
        public bool IsValid { get; set; }
        [ForeignKey("Idhotel,IdClient")]
        public int Idhotel { get; set; }
        public Hotel hotel { get; set; }
        public int IdClient { get; set; }
        public Client client { get; set; }
    }
}
