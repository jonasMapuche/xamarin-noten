﻿using System;

namespace Noten.Models
{
    public class ValueModel
    {
        public string sigla { get; set; }
        public string nome { get; set; }
        public string acidente { get; set; }
        public Boolean constrita { get; set; }
        public int casa { get; set; }
        public float frequencia { get; set; }
        public int oitava { get; set; }
    }
}