using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Operation
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public string Type { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public decimal Sums { get; set; }
        public string Comment { get; set; } = null!;
        public int CategoriesId { get; set; }

        public virtual CategoryType Categories { get; set; } = null!;
        public virtual User Users { get; set; } = null!;
    }
}
