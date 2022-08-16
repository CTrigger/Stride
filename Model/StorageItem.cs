using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public record StorageItem
    {
        [Key]
        public uint Id { get; set; }

        public uint StorageId { get; set; }

        public uint ProductId { get; set; }

        public uint ProductAttributeId { get; set; }

        public int Quantity { get; set; }
    }
}
