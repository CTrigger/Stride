using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public record Warehouse
    {
        public int Id { get; set; }
        public Guid ActorAddressId { get; set; }
        public string Name { get; set; }
    }
}
