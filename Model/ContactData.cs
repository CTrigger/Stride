﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public record ContactData
    {
        [Key]
        public uint Id { get; set; }
        public Guid IdKey { get; set; }
        public uint ContactType { get; set; }

    }
}
