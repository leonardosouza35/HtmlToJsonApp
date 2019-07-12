using HtmlToJsonApp.Model.DailyBusinessModel;
using System.Collections.Generic;

namespace HtmlToJsonApp.Model.DailyBusinessModelS
{
    public class CountryAndStatePerAgentModel
    {
        public string Model { get; set; }
        public List<CountryAndStatePerAgentItem> Item { get; set; }
        public CountryAndStatePerAgentTotal CountryAndStatePerAgentTotal { get; set; }

        public CountryAndStatePerAgentModel()
        {
            Item = new List<CountryAndStatePerAgentItem>();
            CountryAndStatePerAgentTotal = new CountryAndStatePerAgentTotal();
        }
    }
}
