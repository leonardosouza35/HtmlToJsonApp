using Newtonsoft.Json;
using System.Collections.Generic;

namespace HtmlToJsonApp
{
    public class SubSection
    {        
        public string Name { get; set; }

        public List<BusinessModel> BusinessModels { get; set; }        
        [JsonIgnore]
        public List<Year> Years { get; set; }                
        public SubSection(string sectionName)
        {
            Name = sectionName;
            BusinessModels = new List<BusinessModel>();            
            Years = new List<Year>();
        }
    }
}
