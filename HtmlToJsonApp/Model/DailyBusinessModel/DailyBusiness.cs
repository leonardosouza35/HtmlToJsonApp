using System.Collections.Generic;

namespace HtmlToJsonApp.Model.DailyBusinessModel
{
    public  class DailyBusiness
    {
        public BusinessModel BusinessModel { get; set; }
        public List<StatesPerAgentModel> StatesPerAgentModel { get; set; }
        public List<PaymentAggregatorModel> PaymentAggregatorModel { get; set; }


        public DailyBusiness()
        {
            BusinessModel = new BusinessModel();
            StatesPerAgentModel = new List<StatesPerAgentModel>();
            PaymentAggregatorModel = new List<PaymentAggregatorModel>();
        }

        public void SetBusinessModel(BusinessModel businessModel)
        {
            BusinessModel = businessModel;
        }
       
    }
}
