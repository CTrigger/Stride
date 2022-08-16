using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public record Data
    {
        [Key]
        public uint Id { get; set; }

        public uint ContactDataId{ get; set; }

        public string Info { get; set; }
    }
}
