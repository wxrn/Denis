﻿using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Limit
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int UsersId { get; set; }
        public string Names { get; set; } = null!;
        public decimal StartingBalance { get; set; }
        public DateTime DateOpened { get; set; }
        public int CategoriesId { get; set; }

        public virtual CategoryType Categories { get; set; } = null!;
        public virtual User Users { get; set; } = null!;
    }
}
