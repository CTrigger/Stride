using Microsoft.AspNetCore.Http;
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
    public record Midia
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(300, ErrorMessage = Message.MaxLengthExceeded)]
        public string Path { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}
