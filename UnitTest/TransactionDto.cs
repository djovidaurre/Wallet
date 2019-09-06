﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class TransactionDto
    {
        public bool Response { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public List<Error> Messages { get; set; }

        public TransactionDto()
        {
            Messages = new List<Error>();
        }
    }
}
