﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wx.Infra.Entity;

namespace Wx.Data.Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
    }
}
