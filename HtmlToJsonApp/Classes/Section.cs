using Newtonsoft.Json;
using System.Collections.Generic;

namespace HtmlToJsonApp
{
    public class Section
    {
        public string SectionName { get; set; }
        public List<AgentType> Agents { get; set; }        
        [JsonIgnore]
        public List<Year> Years { get; set; }                
        public Section(string sectionName)
        {
            SectionName = sectionName;
            Agents = new List<AgentType>();            
            Years = new List<Year>();
        }
    }
}
