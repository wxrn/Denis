using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int Income { get; set; }
        public int Expenses { get; set; }
        public DateTime DateTime { get; set; }
        public int CategoriesId { get; set; }

        public virtual CategoryType Categories { get; set; } = null!;
        public virtual User Users { get; set; } = null!;
    }
}
