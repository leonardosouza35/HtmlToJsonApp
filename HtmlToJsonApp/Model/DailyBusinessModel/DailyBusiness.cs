using HtmlToJsonApp.Model.DailyBusinessModelS;
using System.Collections.Generic;

namespace HtmlToJsonApp.Model.DailyBusinessModel
{
    public  class DailyBusiness
    {
        public BusinessModel BusinessModel { get; set; }
        public List<StatesPerAgentModel> StatesPerAgentModel { get; set; }
        public List<PaymentAggregatorModel> PaymentAggregatorModel { get; set; }
        public List<CountriesPerAgentModel> CountriesPerAgentModel { get; set; }
        public List<CountryAndStatePerAgentModel> CountryAndStatePerAgentModel { get; set; }


        public DailyBusiness()
        {
            BusinessModel = new BusinessModel();
            StatesPerAgentModel = new List<StatesPerAgentModel>();
            PaymentAggregatorModel = new List<PaymentAggregatorModel>();
            CountriesPerAgentModel = new List<CountriesPerAgentModel>();
            CountryAndStatePerAgentModel = new List<CountryAndStatePerAgentModel>();
        }

        public void SetBusinessModel(BusinessModel businessModel)
        {
            BusinessModel = businessModel;
        }
       
    }
}
