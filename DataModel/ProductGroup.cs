﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ProductGroup
    {
        public int Id { get; init; }
        public string Name { get; set; }

        public ICollection<Products> Products { get; set; }

    }
}