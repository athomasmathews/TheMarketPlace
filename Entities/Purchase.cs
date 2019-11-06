using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public partial class Purchase
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public int? ProductId { get; set; }
    }
}
