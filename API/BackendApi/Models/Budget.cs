using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Budget
    {
        public int Id { get; set; }
        public DateTime StartsDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UsersId { get; set; }
        public decimal Size { get; set; }

        public virtual User Users { get; set; } = null!;
    }
}
