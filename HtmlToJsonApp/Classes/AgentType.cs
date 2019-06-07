﻿using System.Collections.Generic;

namespace HtmlToJsonApp
{
    public class BusinessModel
    {
        public string AgentTypeDescription { get; set; }
        public List<Year> Years { get; set; }

        public BusinessModel()
        {
            Years = new List<Year>();
        }

    }
}