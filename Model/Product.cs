using Model.InternalMessage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public record Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100,ErrorMessage = Message.MaxLengthExceeded)]
        public string Name { get; set; }
        [MaxLength(200,ErrorMessage = Message.MaxLengthExceeded)]
        public string Description { get; set; }

        [NotMapped]
        public ICollection<Midia> Images { get; set; }
    }
}
