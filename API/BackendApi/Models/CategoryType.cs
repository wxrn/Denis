using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class CategoryType
    {
        public CategoryType()
        {
            Limits = new HashSet<Limit>();
            Operations = new HashSet<Operation>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Names { get; set; } = null!;

        public virtual ICollection<Limit> Limits { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
