using System.Collections.Generic;

namespace HtmlToJsonApp
{
    public class AgentType
    {
        public string AgentTypeDescription { get; set; }
        public List<Year> Year { get; set; }

        public AgentType()
        {
            Year = new List<Year>();
        }

    }
}
