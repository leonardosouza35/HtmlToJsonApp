using System.Collections.Generic;

namespace HtmlToJsonApp.Model.DailyBusinessModel
{
    public class StateAndAgentsModel
    {
        public List<StateAndAgentsItem> Item { get; set; }
        public StateAndAgentsTotal StateAndAgentsTotal { get; set; }

        public StateAndAgentsModel()
        {
            Item = new List<StateAndAgentsItem>();
        }
    }
}
