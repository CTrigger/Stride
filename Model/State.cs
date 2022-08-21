﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public record State
    {
        public uint Id { get; set; }
        public uint CountryId { get; set; }
        public string Name { get; set; }
        public int VAT { get; set; }
    }
}
