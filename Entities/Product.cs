using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public decimal? Price { get; set; }
        public bool? Checked { get; set; }
    }
}
