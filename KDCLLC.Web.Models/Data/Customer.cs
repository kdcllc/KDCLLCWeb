﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDCLLC.Web.Models.Data
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
