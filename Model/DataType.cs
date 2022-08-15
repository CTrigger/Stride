﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public record DataTypes
    {
        [Key]
        public uint Id { get; set; }
        public string Name { get; set; }

    }
}
