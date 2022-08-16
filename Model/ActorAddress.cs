using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public record ActorAddress
    {
        public uint Id { get; set; }
        public Guid ActorId { get; set; }
    }
}
