using System.Collections.Generic;

namespace HtmlToJsonApp
{
    public class Section
    {
        public List<AgentType> AgentType { get; set; }
        public List<Total> Total { get; set; }

        public Section()
        {
            AgentType = new List<AgentType>();
            Total = new List<Total>();
        }
    }
}
