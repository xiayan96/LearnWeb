﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWeb.Entites.Dtos
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public string Account { get; set; }
        public string AccountType { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
