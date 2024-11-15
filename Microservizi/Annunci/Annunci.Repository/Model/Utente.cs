﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annunci.Repository.Model
{
    public class Utente
    {
        public string Username { get; set; }
        public string Id { get; set; }
        public ICollection<Inserzione> Inserzioni { get; set; } = new List<Inserzione>();
    }
}
