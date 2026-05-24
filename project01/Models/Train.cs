using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Train
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public int Capacity { get; set; }


        // Navigation Property
        public List<Ticket> Tickets { get; set; }
            = new List<Ticket>();
    }

}
