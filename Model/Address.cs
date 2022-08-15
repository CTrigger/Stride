using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public record Address
    {
        [Key]
        public int Id { get; set; }
        public Guid ActorId { get; set; }
        public int ContactDataId { get; set; }
        public int AddressType { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string AddressLocation { get; set; }
        public string AddressInfo { get; set; }
        public int VAT  { get; set; }
    }
}
