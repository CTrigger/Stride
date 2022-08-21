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
        public uint Id { get; set; }
        public Guid IdKey { get; set; }
        public uint AddressType { get; set; }
        public uint CountryId { get; set; }
        public uint StateId { get; set; }
        public string PostalCode { get; set; }
        public string AddressLocation { get; set; }
        public string AddressInfo { get; set; }
    }
}
