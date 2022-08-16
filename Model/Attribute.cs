using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public record Attribute
    {
        [Key]
        public uint Id { get; set; }

        public uint ProductAttributeId { get; set; }

        public string Description { get; set; }

    }
}
