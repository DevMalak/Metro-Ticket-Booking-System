using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public string PassengerName { get; set; }

        public decimal Price { get; set; }

        public DateTime TravelDate { get; set; }


        // Foreign Key
        public int TrainId { get; set; }

        public Train Train { get; set; }


        // Foreign Key
        public int StationId { get; set; }

        public Station Station { get; set; }
    }
}
