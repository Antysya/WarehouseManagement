﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataModel
{
    public class Shelving : IEntity
    {
        [Key]
        public int Id { get; init; }
        public string Line { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        public int Level { get; set; }
        public int Capacity { get; set; }

        public override string ToString()
        {
            return (Line+'/'+Row+'/'+Number+'/'+Level).ToString();
        }
    }
}
