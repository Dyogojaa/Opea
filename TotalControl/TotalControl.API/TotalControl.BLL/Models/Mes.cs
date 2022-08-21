﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalControl.BLL.Models
{
    public class Mes 
    {
        public int MesId { get; set; } 
        public string Nome { get; set; } = string.Empty;

        public virtual ICollection<Despesa>? Despesas { get; set; }
        public virtual ICollection<Ganho>? Ganhos { get; set; }

    }
}