using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class User
    {
        public User()
        {
            Budgets = new HashSet<Budget>();
            Limits = new HashSet<Limit>();
            Operations = new HashSet<Operation>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string UsersName { get; set; } = null!;
        public int Age { get; set; }
        public string Passwords { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<Limit> Limits { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
