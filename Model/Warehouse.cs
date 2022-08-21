using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public record Warehouse
    {
        [Key]
        public uint Id { get; set; }
        public uint ActorId { get; set; }
        public string Name { get; set; }
    }
}
