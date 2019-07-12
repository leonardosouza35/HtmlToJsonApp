using System.Collections.Generic;

namespace HtmlToJsonApp.Model.DailyBusinessModel
{
    public class CountriesPerAgentModel
    {
        public string Model { get; set; }
        public List<CountriesPerAgentItem> Item { get; set; }
        public CountriesPerAgentTotal CountriesPerAgentTotal { get; set; }

        public CountriesPerAgentModel()
        {
            Item = new List<CountriesPerAgentItem>();
        }
    }
}
