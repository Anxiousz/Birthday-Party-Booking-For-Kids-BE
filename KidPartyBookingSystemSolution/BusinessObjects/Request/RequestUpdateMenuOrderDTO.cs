﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Request
{
    public class RequestUpdateMenuOrderDTO
    {
        public int MenuOrderId { get; set; }
        public int? FoodOrderId { get; set; }
        public int Quantity { get; set; }
    }
}
