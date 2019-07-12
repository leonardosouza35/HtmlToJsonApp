

using System.Collections.Generic;

namespace HtmlToJsonApp.Model.DailyBusinessModel
{
    public class StatesPerAgentModel
    {
        public string Title { get; set; }
        public List<StatesPerAgentItem> AgentType { get; set; }
        public StatesPerAgentTotal StatesPerAgentTotal { get; set; }

        public StatesPerAgentModel(string title)
        {
            AgentType = new List<StatesPerAgentItem>();
            StatesPerAgentTotal = new StatesPerAgentTotal();
            Title = title;
        }
    }
}
