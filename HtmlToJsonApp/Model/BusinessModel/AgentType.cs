using System.Collections.Generic;

namespace HtmlToJsonApp.Model
{
    public class AgentType
    {
        public string Description { get; set; }
        public List<Year> Years { get; set; }

        public AgentType()
        {
            Years = new List<Year>();
        }

    }
}
