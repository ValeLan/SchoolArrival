using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client : User
    {
        public List<Passenger> Passengers { get; set; } = new List<Passenger>();
    }
}
