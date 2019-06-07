using System.Collections.Generic;

namespace HtmlToJsonApp
{
    public class AgentType
    {
        public string AgentTypeDescription { get; set; }
        public List<Year> Years { get; set; }

        public AgentType()
        {
            Years = new List<Year>();
        }

    }
}
