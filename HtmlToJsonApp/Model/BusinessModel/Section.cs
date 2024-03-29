﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace HtmlToJsonApp
{
    public class Section
    {
        public string SectionName { get; set; }
        public string HeaderDescription { get; set; }
        [JsonIgnore]
        public List<Year> Years { get; set; }
        public List<SubSection> SubSection { get; set; }
        public List<Total> Total { get; set; }

        public Section(string sectionName)
        {
            SectionName = sectionName;
            HeaderDescription = string.Empty;
            SubSection = new List<SubSection>();
            Years = new List<Year>();
            Total = new List<Total>();
        }
    }
}
