﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
   public class PropertyDto
    {
        
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Location { get; set; }
            public string Contact { get; set; }
        
    }
}
