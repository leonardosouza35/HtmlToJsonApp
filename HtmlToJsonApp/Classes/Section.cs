using Newtonsoft.Json;
using System.Collections.Generic;

namespace HtmlToJsonApp
{
    public class Section
    {
        public string SectionName { get; set; }
        public List<BusinessModel> BusinessModels { get; set; }        
        [JsonIgnore]
        public List<Year> Years { get; set; }                
        public Section(string sectionName)
        {
            SectionName = sectionName;
            BusinessModels = new List<BusinessModel>();            
            Years = new List<Year>();
        }
    }
}
