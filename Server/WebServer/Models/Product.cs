﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServer.Models
{
  public class Product
  {
    public int Id { get; set; }

    public ProductType Category { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public bool InBasket { get; set; }
  }
}