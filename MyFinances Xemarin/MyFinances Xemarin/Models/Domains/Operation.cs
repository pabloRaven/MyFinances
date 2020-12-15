﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinances Xemarin.Models.Domains
{
    public class Operation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
    public int CategoryId { get; set; }

  
}
}
