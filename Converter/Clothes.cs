﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class Clothes
    {
        public string Name;
        public int Size;
        public int Price;
        
        public Clothes()
        {

        }
        public Clothes(string Name, int Size, int Price)
        {
            this.Name = Name;
            this.Size = Size;
            this.Price = Price;
        }
    }
}
